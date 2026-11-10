using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace OOP10FEXLab
{
    // UI #1 - Claim monitor: PREPARING and NOW SERVING order numbers.
    // Updates by itself whenever the kiosk places an order (OrderManager events).
    // The screen layout is made in the Designer (QueueMonitorForm.Designer.cs).
    public partial class QueueMonitorForm : Form
    {
        private readonly OrderManager manager;
        private readonly System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer();
        private readonly Dictionary<int, DateTime> blinkUntil = new Dictionary<int, DateTime>();
        private bool blinkOn;

        public QueueMonitorForm(OrderManager manager)
        {
            InitializeComponent();
            this.manager = manager;

            manager.OrderPlaced += Manager_OrderChanged;
            manager.OrderStatusChanged += Manager_OrderChanged;

            clockTimer.Interval = 500;
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();

            RefreshBoard();
            UpdateClock();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            manager.OrderPlaced -= Manager_OrderChanged;
            manager.OrderStatusChanged -= Manager_OrderChanged;
            clockTimer.Stop();
            clockTimer.Dispose();
            base.OnFormClosed(e);
        }

        // ------------------------------------------------------------ board

        private void Manager_OrderChanged(object sender, Order order)
        {
            if (order.Status == OrderStatus.NowServing)
            {
                blinkUntil[order.OrderNumber] = DateTime.Now.AddSeconds(6);
                SystemSounds.Exclamation.Play();
            }
            else
            {
                blinkUntil.Remove(order.OrderNumber);
            }

            // BeginInvoke waits until the current click finishes, so we never
            // dispose a number tile while its own Click event is still running.
            if (IsHandleCreated && !IsDisposed) BeginInvoke(new MethodInvoker(RefreshBoard));
            else RefreshBoard();
        }

        private void RefreshBoard()
        {
            List<Order> preparing = manager.GetPreparingOrders();
            List<Order> serving = manager.GetServingOrders();

            preparingCountLabel.Text = preparing.Count.ToString();
            servingCountLabel.Text = serving.Count.ToString();
            FillArea(preparingPanel, preparing, false);
            FillArea(servingPanel, serving, true);
        }

        private void FillArea(FlowLayoutPanel area, List<Order> orders, bool serving)
        {
            area.SuspendLayout();
            while (area.Controls.Count > 0) area.Controls[0].Dispose();
            foreach (Order order in orders) area.Controls.Add(MakeNumberTile(order, serving));
            area.ResumeLayout();
        }

        // Makes one order-number tile. Its look is copied from the hidden template tiles in the Designer.
        private Control MakeNumberTile(Order order, bool serving)
        {
            if (!serving)
            {
                Label tile = new Label();
                CopyLook(preparingTileTemplate, tile);
                tile.Text = order.OrderNumber.ToString();
                tile.Tag = order.OrderNumber;
                tile.Cursor = Cursors.Hand;
                tile.Click += NumberTile_Click;
                return tile;
            }

            // A NOW SERVING tile is a green frame (Panel) with the number label inside it.
            Panel frame = new Panel();
            CopyLook(servingTileTemplate, frame);

            Label number = new Label();
            CopyLook(servingTileLabelTemplate, number);
            number.Location = servingTileLabelTemplate.Location;
            number.Text = order.OrderNumber.ToString();
            frame.Controls.Add(number);

            frame.Tag = order.OrderNumber;
            number.Tag = order.OrderNumber;
            frame.Cursor = Cursors.Hand;
            number.Cursor = Cursors.Hand;
            frame.Click += NumberTile_Click;
            number.Click += NumberTile_Click;
            return frame;
        }

        // Copies the look of a hidden template control (made in the Designer) onto a new tile,
        // so the tiles can be restyled in the Designer without touching this code.
        private static void CopyLook(Control template, Control target)
        {
            target.Size = template.Size;
            target.Margin = template.Margin;
            target.Padding = template.Padding;
            target.BackColor = template.BackColor;
            target.ForeColor = template.ForeColor;
            target.Font = template.Font;

            // Labels also copy their text alignment and border.
            if (template is Label templateLabel && target is Label targetLabel)
            {
                targetLabel.TextAlign = templateLabel.TextAlign;
                targetLabel.BorderStyle = templateLabel.BorderStyle;
            }

            // Panels also copy their border.
            if (template is Panel templatePanel && target is Panel targetPanel)
            {
                targetPanel.BorderStyle = templatePanel.BorderStyle;
            }
        }

        private void NumberTile_Click(object sender, EventArgs e)
        {
            int orderNumber = (int)((Control)sender).Tag;
            manager.Advance(orderNumber);
        }

        // ------------------------------------------------------------ clock + blink

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
            blinkOn = !blinkOn;

            DateTime now = DateTime.Now;
            foreach (Control tile in servingPanel.Controls)
            {
                DateTime until;
                bool blinking = blinkUntil.TryGetValue((int)tile.Tag, out until) && now < until;

                // Switch the number label between the blinking colors and the normal serving colors.
                Label number = (Label)tile.Controls[0];
                Label look = blinking && blinkOn ? blinkingTileTemplate : servingTileLabelTemplate;
                number.BackColor = look.BackColor;
                number.ForeColor = look.ForeColor;
            }

            foreach (int number in blinkUntil.Where(p => p.Value <= now).Select(p => p.Key).ToList())
            {
                blinkUntil.Remove(number);
            }
        }

        private void UpdateClock()
        {
            timeLabel.Text = DateTime.Now.ToString("h:mm:ss tt");
            dateLabel.Text = DateTime.Now.ToString("ddd, MMM d");
        }
    }
}
