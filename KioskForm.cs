using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FINAL_LAB_EXAM_OOP10.Properties;

namespace OOP10FEXLab
{
    // UI #2 - Self-order kiosk: pick package meals, review, then pay.
    // The screen layout is made in the Designer (KioskForm.Designer.cs).
    public partial class KioskForm : Form
    {
        private const string AllMeals = "All Meals";

        private readonly OrderManager manager;
        private readonly Cart cart = new Cart();
        private readonly List<Button> categoryButtons = new List<Button>();
        private readonly string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
        private List<MealPackage> menu = new List<MealPackage>();

        public KioskForm(OrderManager manager)
        {
            InitializeComponent();
            this.manager = manager;

            plusButton.Click += (s, e) => ChangeSelected(1);
            minusButton.Click += (s, e) => ChangeSelected(-1);
            removeButton.Click += (s, e) => RemoveSelected();
            cancelButton.Click += (s, e) => CancelOrder();
            payButton.Click += (s, e) => ReviewAndPay();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadMenu();
            RefreshCart(null);
        }

        // F5 reloads meals.txt without restarting the app.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                LoadMenu();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ------------------------------------------------------------ menu

        private void LoadMenu()
        {
            try
            {
                menu = manager.GetMenu();
                sourceLabel.Text = "● Connected: " + manager.DataSourceName;
                sourceLabel.ForeColor = Color.FromArgb(180, 245, 200);
            }
            catch (Exception ex)
            {
                menu = new List<MealPackage>();
                sourceLabel.Text = "● Not connected: " + manager.DataSourceName;
                sourceLabel.ForeColor = AppTheme.Accent;
                MessageBox.Show(this, "The package meals could not be loaded from " + manager.DataSourceName + ".\n\n" + ex.Message,
                    "Menu Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Remove the old category buttons (the hidden templates stay).
            foreach (Button old in categoryButtons) old.Dispose();
            categoryButtons.Clear();

            List<string> categories = new List<string> { AllMeals };
            categories.AddRange(menu.Select(m => m.Category).Distinct());

            foreach (string category in categories)
            {
                Button button = new Button();
                CopyLook(categoryTemplate, button);
                button.Text = category;
                button.Tag = category;
                button.UseMnemonic = false;
                button.Cursor = Cursors.Hand;
                button.Click += (s, e) => ShowCategory((string)((Button)s).Tag);

                categoryButtons.Add(button);
                categoryPanel.Controls.Add(button);
            }

            ShowCategory(AllMeals);
        }

        // Copies the look of a hidden template button (made in the Designer) onto a new button,
        // so the category buttons can be restyled in the Designer without touching this code.
        private static void CopyLook(Button template, Button target)
        {
            target.Size = template.Size;
            target.Margin = template.Margin;
            target.Padding = template.Padding;
            target.BackColor = template.BackColor;
            target.ForeColor = template.ForeColor;
            target.Font = template.Font;
            target.FlatStyle = template.FlatStyle;
            target.FlatAppearance.BorderColor = template.FlatAppearance.BorderColor;
            target.FlatAppearance.BorderSize = template.FlatAppearance.BorderSize;
            target.FlatAppearance.MouseOverBackColor = template.FlatAppearance.MouseOverBackColor;
            target.FlatAppearance.MouseDownBackColor = template.FlatAppearance.MouseDownBackColor;
            target.TextAlign = template.TextAlign;
            target.ImageAlign = template.ImageAlign;
            target.TextImageRelation = template.TextImageRelation;
        }

        // "All Meals" gets the grid icon, every other category gets the family icon.
        // Red icons are for normal buttons, white icons for the selected (red) button.
        private static Image CategoryIcon(string category, bool selected)
        {
            if (category == AllMeals)
            {
                return selected ? Resources.icon_cat_all_white : Resources.icon_cat_all_red;
            }
            return selected ? Resources.icon_cat_family_white : Resources.icon_cat_family_red;
        }

        private void ShowCategory(string category)
        {
            categoryTitle.Text = category;
            foreach (Button button in categoryButtons)
            {
                bool selected = (string)button.Tag == category;
                CopyLook(selected ? selectedCategoryTemplate : categoryTemplate, button);
                button.Image = CategoryIcon((string)button.Tag, selected);
            }

            List<MealPackage> meals = category == AllMeals
                ? menu
                : menu.Where(m => m.Category == category).ToList();

            mealCountLabel.Text = meals.Count == 1 ? "1 meal" : meals.Count + " meals";

            mealGrid.SuspendLayout();
            while (mealGrid.Controls.Count > 0) mealGrid.Controls[0].Dispose();

            foreach (MealPackage meal in meals)
            {
                MealCard card = new MealCard(meal, imageFolder);
                card.MealClicked += MealCard_Clicked;
                mealGrid.Controls.Add(card);
            }

            // The "No meals to show" message is a hidden label made in the Designer.
            noMealsLabel.Visible = meals.Count == 0;

            mealGrid.ResumeLayout();
            mealGrid.AutoScrollPosition = new Point(0, 0);
        }

        private void MealCard_Clicked(object sender, EventArgs e)
        {
            MealPackage meal = ((MealCard)sender).Meal;
            cart.Add(meal);
            RefreshCart(meal);
        }

        // ------------------------------------------------------------ cart

        private void RefreshCart(MealPackage selectMeal)
        {
            cartList.BeginUpdate();
            cartList.Items.Clear();
            foreach (CartItem item in cart.Items)
            {
                ListViewItem row = new ListViewItem(item.Quantity.ToString());
                row.SubItems.Add(item.Meal.Name);
                row.SubItems.Add(AppTheme.Money(item.Subtotal));
                row.Tag = item.Meal;
                row.Selected = selectMeal != null && item.Meal.Code == selectMeal.Code;
                cartList.Items.Add(row);
            }
            cartList.EndUpdate();

            if (cartList.SelectedItems.Count > 0) cartList.SelectedItems[0].EnsureVisible();

            int count = cart.ItemCount;
            itemCountLabel.Text = count == 1 ? "1 item" : count + " items";
            totalLabel.Text = AppTheme.Money(cart.Total);
            payButton.Enabled = !cart.IsEmpty;
            cancelButton.Enabled = !cart.IsEmpty;
        }

        private MealPackage SelectedMeal()
        {
            if (cartList.SelectedItems.Count > 0) return (MealPackage)cartList.SelectedItems[0].Tag;

            MessageBox.Show(this, "Tap an item under My Order first.", "My Order",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        private void ChangeSelected(int delta)
        {
            MealPackage meal = SelectedMeal();
            if (meal == null) return;

            if (delta > 0) cart.Add(meal);
            else cart.Decrease(meal);
            RefreshCart(meal);
        }

        private void RemoveSelected()
        {
            MealPackage meal = SelectedMeal();
            if (meal == null) return;

            cart.Remove(meal);
            RefreshCart(null);
        }

        private void CancelOrder()
        {
            if (cart.IsEmpty) return;

            DialogResult answer = MessageBox.Show(this, "Cancel this order and remove all items?",
                "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            cart.Clear();
            RefreshCart(null);
            ShowCategory(AllMeals);
        }

        private void ReviewAndPay()
        {
            if (cart.IsEmpty) return;

            using (ReviewOrderForm review = new ReviewOrderForm(cart))
            {
                if (review.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    Order order = manager.PlaceOrder(cart, review.Dining, review.Payment);

                    string paymentNote = order.Payment == PaymentMethod.CashAtCounter
                        ? "Please pay " + AppTheme.Money(order.Total) + " at the counter."
                        : "Paid by " + order.Payment.ToDisplay() + ". Thank you!";

                    MessageBox.Show(this,
                        "Your order number is  " + order.OrderNumber + "\n\n" +
                        order.Dining.ToDisplay() + "  •  " + paymentNote + "\n" +
                        "Watch the Claim Monitor for your number.\n\n" +
                        "Saved to the transaction record (" + manager.DataSourceName + ").",
                        "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cart.Clear();
                    RefreshCart(null);
                    ShowCategory(AllMeals);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "The order could not be saved.\n\n" + ex.Message,
                        "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
