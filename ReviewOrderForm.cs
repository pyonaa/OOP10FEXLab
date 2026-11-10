using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace OOP10FEXLab
{
    // Shown after "Review & Pay": order summary, dine in / take out, and payment method.
    // The screen layout is made in the Designer (ReviewOrderForm.Designer.cs).
    public partial class ReviewOrderForm : Form
    {
        public DiningOption Dining
        {
            get { return takeOutRadio.Checked ? DiningOption.TakeOut : DiningOption.DineIn; }
        }

        public PaymentMethod Payment
        {
            get
            {
                if (cardRadio.Checked) return PaymentMethod.Card;
                if (eWalletRadio.Checked) return PaymentMethod.EWallet;
                return PaymentMethod.CashAtCounter;
            }
        }

        public ReviewOrderForm(Cart cart)
        {
            InitializeComponent();

            // Fill the order list and the total.
            foreach (CartItem item in cart.Items)
            {
                ListViewItem row = new ListViewItem(item.Quantity.ToString());
                row.SubItems.Add(item.Meal.Name);
                row.SubItems.Add(AppTheme.Money(item.Subtotal));
                orderList.Items.Add(row);
            }
            totalAmountLabel.Text = AppTheme.Money(cart.Total);
        }
    }
}
