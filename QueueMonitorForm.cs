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
    public class QueueMonitorForm : Form
    {
        private readonly OrderManager manager;
        private readonly System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer();
        private readonly Dictionary<int, DateTime> blinkUntil = new Dictionary<int, DateTime>();
        private bool blinkOn;

        private Label clockLabel;
        private Label preparingHeader;
        private Label servingHeader;
        private FlowLayoutPanel preparingPanel;
        private PictureBox pictureBox1;
        private FlowLayoutPanel servingPanel;

        public QueueMonitorForm(OrderManager manager)
        {
            this.manager = manager;
            BuildLayout();

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

        // ------------------------------------------------------------ layout

        private void BuildLayout()
        {
            Text = "Claim Monitor";
            ClientSize = new Size(560, 660);
            MinimumSize = new Size(380, 420);
            BackColor = AppTheme.MonitorScreen;
            Font = AppTheme.MakeFont(10F);

            Panel header = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = AppTheme.MonitorNavy, Padding = new Padding(16, 0, 16, 0) };
            clockLabel = new Label
            {
                Dock = DockStyle.Right,
                Width = 130,
                ForeColor = Color.White,
                Font = AppTheme.MakeFont(10F),
                TextAlign = ContentAlignment.MiddleRight
            };
            Label title = new Label
            {
                Text = "CLAIM MONITOR",
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = AppTheme.MakeFont(20F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            header.Controls.Add(title);
            header.Controls.Add(clockLabel);

            TableLayoutPanel board = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Padding = new Padding(8) };
            board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            board.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            preparingHeader = MakeColumnHeader("PREPARING", AppTheme.MonitorColumn, AppTheme.MonitorNavy);
            servingHeader = MakeColumnHeader("NOW SERVING", AppTheme.Success, Color.White);
            preparingPanel = MakeNumberArea();
            servingPanel = MakeNumberArea();
            board.Controls.Add(MakeColumn(preparingHeader, preparingPanel), 0, 0);
            board.Controls.Add(MakeColumn(servingHeader, servingPanel), 1, 0);

            Label hint = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 42,
                Text = "Staff: click a PREPARING number when the meal is ready.\nClick a NOW SERVING number once it has been claimed.",
                ForeColor = AppTheme.MonitorNavy,
                Font = AppTheme.MakeFont(8.5F),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(board);
            Controls.Add(hint);
            Controls.Add(header);
        }

        private static Label MakeColumnHeader(string text, Color back, Color fore)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Top,
                Height = 46,
                BackColor = back,
                ForeColor = fore,
                Font = AppTheme.MakeFont(14F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private static FlowLayoutPanel MakeNumberArea()
        {
            return new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(6),
                BackColor = AppTheme.MonitorTile
            };
        }

        private static Panel MakeColumn(Label header, FlowLayoutPanel area)
        {
            Panel column = new Panel { Dock = DockStyle.Fill, Margin = new Padding(4) };
            column.Controls.Add(area);
            column.Controls.Add(header);
            return column;
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

            preparingHeader.Text = "PREPARING (" + preparing.Count + ")";
            servingHeader.Text = "NOW SERVING (" + serving.Count + ")";
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

        private Label MakeNumberTile(Order order, bool serving)
        {
            Label tile = new Label
            {
                Text = order.OrderNumber.ToString(),
                Tag = order.OrderNumber,
                Size = serving ? new Size(150, 64) : new Size(104, 46),
                Margin = new Padding(5),
                Font = AppTheme.MakeFont(serving ? 26F : 18F, FontStyle.Bold),
                ForeColor = serving ? AppTheme.Success : AppTheme.MonitorNavy,
                BackColor = serving ? Color.White : AppTheme.MonitorScreen,
                BorderStyle = serving ? BorderStyle.FixedSingle : BorderStyle.None,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            tile.Click += NumberTile_Click;
            return tile;
        }

        private void NumberTile_Click(object sender, EventArgs e)
        {
            int orderNumber = (int)((Label)sender).Tag;
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
                tile.BackColor = blinking && blinkOn ? AppTheme.Accent : Color.White;
            }

            foreach (int number in blinkUntil.Where(p => p.Value <= now).Select(p => p.Key).ToList())
            {
                blinkUntil.Remove(number);
            }
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.Screenshot_2026_11_10_130410;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(862, 943);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // QueueMonitorForm
            // 
            ClientSize = new Size(862, 943);
            Controls.Add(pictureBox1);
            Name = "QueueMonitorForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }

        private void UpdateClock()
        {
            clockLabel.Text = DateTime.Now.ToString("h:mm:ss tt") + "\n" + DateTime.Now.ToString("ddd, MMM d");
        }
    }
}