using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace OOP10FEXLab
{
    // Shown after "Review & Pay": order summary, dine in / take out, and payment method.
    public class ReviewOrderForm : Form
    {
        private readonly RadioButton dineIn = new RadioButton { Text = "Dine In", Checked = true };
        private readonly RadioButton takeOut = new RadioButton { Text = "Take Out" };
        private readonly RadioButton cash = new RadioButton { Text = "Cash (pay at the counter)", Checked = true };
        private readonly RadioButton card = new RadioButton { Text = "Credit / Debit Card" };
        private readonly RadioButton eWallet = new RadioButton { Text = "E-wallet (GCash / Maya)" };

        public DiningOption Dining
        {
            get { return takeOut.Checked ? DiningOption.TakeOut : DiningOption.DineIn; }
        }

        public PaymentMethod Payment
        {
            get
            {
                if (card.Checked) return PaymentMethod.Card;
                if (eWallet.Checked) return PaymentMethod.EWallet;
                return PaymentMethod.CashAtCounter;
            }
        }

        public ReviewOrderForm(Cart cart)
        {
            Text = "Review Your Order";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(460, 580);
            BackColor = Color.White;
            Font = AppTheme.MakeFont(10F);

            Label title = new Label
            {
                Text = "Review Your Order",
                Font = AppTheme.MakeFont(16F, FontStyle.Bold),
                ForeColor = AppTheme.TextDark,
                AutoSize = true,
                Location = new Point(16, 12)
            };

            ListView list = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                HeaderStyle = ColumnHeaderStyle.Nonclickable,
                Location = new Point(16, 52),
                Size = new Size(428, 210)
            };
            list.Columns.Add("Qty", 46);
            list.Columns.Add("Item", 262);
            list.Columns.Add("Amount", 100, HorizontalAlignment.Right);
            foreach (CartItem item in cart.Items)
            {
                ListViewItem row = new ListViewItem(item.Quantity.ToString());
                row.SubItems.Add(item.Meal.Name);
                row.SubItems.Add(AppTheme.Money(item.Subtotal));
                list.Items.Add(row);
            }

            Label total = new Label
            {
                Text = "Total: " + AppTheme.Money(cart.Total),
                Font = AppTheme.MakeFont(15F, FontStyle.Bold),
                ForeColor = AppTheme.Primary,
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(16, 270),
                Size = new Size(428, 34)
            };

            GroupBox diningBox = new GroupBox { Text = "Dining option", Location = new Point(16, 312), Size = new Size(428, 62) };
            Place(diningBox, dineIn, 14, 26, 150);
            Place(diningBox, takeOut, 190, 26, 150);

            GroupBox paymentBox = new GroupBox { Text = "Payment method", Location = new Point(16, 384), Size = new Size(428, 100) };
            Place(paymentBox, cash, 14, 28, 300);
            Place(paymentBox, card, 14, 62, 180);
            Place(paymentBox, eWallet, 204, 62, 210);

            Button back = AppTheme.MakeButton("Back to Menu", Color.Gainsboro, AppTheme.TextDark);
            back.Location = new Point(16, 504);
            back.Size = new Size(150, 56);
            back.DialogResult = DialogResult.Cancel;

            Button confirm = AppTheme.MakeButton("Confirm Order", AppTheme.Success, Color.White);
            confirm.Font = AppTheme.MakeFont(12F, FontStyle.Bold);
            confirm.Location = new Point(176, 504);
            confirm.Size = new Size(268, 56);
            confirm.DialogResult = DialogResult.OK;

            AcceptButton = confirm;
            CancelButton = back;
            Controls.AddRange(new Control[] { title, list, total, diningBox, paymentBox, back, confirm });
        }

        private static void Place(GroupBox box, RadioButton radio, int x, int y, int width)
        {
            radio.Location = new Point(x, y);
            radio.Size = new Size(width, 26);
            box.Controls.Add(radio);
        }
    }
}