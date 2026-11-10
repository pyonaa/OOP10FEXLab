using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OOP10FEXLab
{
    // UI #2 - Self-order kiosk: pick package meals, review, then pay.
    public class KioskForm : Form
    {
        private const string AllMeals = "All Meals";

        private readonly OrderManager manager;
        private readonly Cart cart = new Cart();
        private readonly List<Button> categoryButtons = new List<Button>();
        private readonly string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
        private List<MealPackage> menu = new List<MealPackage>();

        private FlowLayoutPanel categoryPanel;
        private FlowLayoutPanel mealGrid;
        private Label categoryTitle;
        private Label sourceLabel;
        private ListView cartList;
        private Label itemCountLabel;
        private Label totalLabel;
        private Button cancelButton;
        private PictureBox pictureBox1;
        private Button payButton;

        public KioskForm(OrderManager manager)
        {
            this.manager = manager;
            BuildLayout();
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

        // ------------------------------------------------------------ layout

        private void BuildLayout()
        {
            Text = AppTheme.StoreName + " - Self-Order Kiosk";
            ClientSize = new Size(1020, 660);
            MinimumSize = new Size(880, 600);
            BackColor = AppTheme.Background;
            Font = AppTheme.MakeFont(10F);

            Panel header = new Panel { Dock = DockStyle.Top, Height = 74, BackColor = AppTheme.Primary, Padding = new Padding(0, 0, 16, 0) };

            // Shows where the meals come from and whether it connected.
            sourceLabel = new Label
            {
                Dock = DockStyle.Right,
                Width = 300,
                Font = AppTheme.MakeFont(9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleRight
            };
            header.Controls.Add(sourceLabel);

            header.Controls.Add(new Label
            {
                Text = AppTheme.StoreName,
                ForeColor = Color.White,
                Font = AppTheme.MakeFont(22F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(16, 4)
            });
            header.Controls.Add(new Label
            {
                Text = "Order and Pay here  \u2022  Tap a meal to add it to your order",
                ForeColor = AppTheme.Accent,
                Font = AppTheme.MakeFont(10F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 46)
            });

            categoryPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                Width = 170,
                BackColor = Color.White,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10, 12, 10, 12)
            };

            Panel center = new Panel { Dock = DockStyle.Fill, Padding = new Padding(14, 10, 8, 10) };
            mealGrid = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
            categoryTitle = new Label
            {
                Dock = DockStyle.Top,
                Height = 40,
                Font = AppTheme.MakeFont(16F, FontStyle.Bold),
                ForeColor = AppTheme.TextDark,
                UseMnemonic = false
            };
            center.Controls.Add(mealGrid);
            center.Controls.Add(categoryTitle);

            // Fill control first, then the edges (WinForms docks the last-added first).
            Controls.Add(center);
            Controls.Add(BuildCartPanel());
            Controls.Add(categoryPanel);
            Controls.Add(header);
        }

        private Panel BuildCartPanel()
        {
            Panel panel = new Panel { Dock = DockStyle.Right, Width = 310, BackColor = Color.White, Padding = new Padding(12) };

            Label title = new Label
            {
                Text = "My Order",
                Dock = DockStyle.Top,
                Height = 38,
                Font = AppTheme.MakeFont(15F, FontStyle.Bold),
                ForeColor = AppTheme.TextDark
            };

            cartList = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                MultiSelect = false,
                HideSelection = false,
                HeaderStyle = ColumnHeaderStyle.Nonclickable,
                BorderStyle = BorderStyle.FixedSingle
            };
            cartList.Columns.Add("Qty", 36);
            cartList.Columns.Add("Item", 166);
            cartList.Columns.Add("Amount", 80, HorizontalAlignment.Right);

            Button plus = AppTheme.MakeButton("+ Add", AppTheme.Success, Color.White);
            Button minus = AppTheme.MakeButton("\u2212 Less", AppTheme.Accent, AppTheme.TextDark);
            Button remove = AppTheme.MakeButton("Remove", Color.Gainsboro, AppTheme.TextDark);
            plus.Click += (s, e) => ChangeSelected(1);
            minus.Click += (s, e) => ChangeSelected(-1);
            remove.Click += (s, e) => RemoveSelected();
            TableLayoutPanel quantityRow = MakeButtonRow(46, plus, minus, remove);

            Panel totals = new Panel { Dock = DockStyle.Bottom, Height = 74 };
            itemCountLabel = new Label
            {
                Dock = DockStyle.Top,
                Height = 24,
                ForeColor = AppTheme.Muted,
                TextAlign = ContentAlignment.BottomLeft
            };
            Label totalCaption = new Label
            {
                Text = "Order Total",
                Dock = DockStyle.Left,
                Width = 110,
                Font = AppTheme.MakeFont(11F, FontStyle.Bold),
                ForeColor = AppTheme.TextDark,
                TextAlign = ContentAlignment.MiddleLeft
            };
            totalLabel = new Label
            {
                Dock = DockStyle.Fill,
                Font = AppTheme.MakeFont(20F, FontStyle.Bold),
                ForeColor = AppTheme.Primary,
                TextAlign = ContentAlignment.MiddleRight
            };
            totals.Controls.Add(totalLabel);
            totals.Controls.Add(totalCaption);
            totals.Controls.Add(itemCountLabel);

            cancelButton = AppTheme.MakeButton("Cancel Order", Color.Gainsboro, AppTheme.TextDark);
            payButton = AppTheme.MakeButton("Review && Pay", AppTheme.Primary, Color.White);
            payButton.Font = AppTheme.MakeFont(12F, FontStyle.Bold);
            cancelButton.Click += (s, e) => CancelOrder();
            payButton.Click += (s, e) => ReviewAndPay();
            TableLayoutPanel actionRow = MakeButtonRow(60, cancelButton, payButton);

            panel.Controls.Add(cartList);
            panel.Controls.Add(title);
            panel.Controls.Add(quantityRow);
            panel.Controls.Add(totals);
            panel.Controls.Add(actionRow);
            return panel;
        }

        private static TableLayoutPanel MakeButtonRow(int height, params Button[] buttons)
        {
            TableLayoutPanel row = new TableLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = height,
                ColumnCount = buttons.Length,
                RowCount = 1,
                Padding = new Padding(0, 6, 0, 0)
            };
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            for (int i = 0; i < buttons.Length; i++)
            {
                row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / buttons.Length));
                buttons[i].Dock = DockStyle.Fill;
                buttons[i].Margin = new Padding(i == 0 ? 0 : 3, 0, i == buttons.Length - 1 ? 0 : 3, 0);
                row.Controls.Add(buttons[i], i, 0);
            }
            return row;
        }

        // ------------------------------------------------------------ menu

        private void LoadMenu()
        {
            try
            {
                menu = manager.GetMenu();
                sourceLabel.Text = "\u25CF Connected: " + manager.DataSourceName;
                sourceLabel.ForeColor = Color.FromArgb(180, 245, 200);
            }
            catch (Exception ex)
            {
                menu = new List<MealPackage>();
                sourceLabel.Text = "\u25CF Not connected: " + manager.DataSourceName;
                sourceLabel.ForeColor = AppTheme.Accent;
                MessageBox.Show(this, "The package meals could not be loaded from " + manager.DataSourceName + ".\n\n" + ex.Message,
                    "Menu Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (Button old in categoryButtons) old.Dispose();
            categoryButtons.Clear();
            categoryPanel.Controls.Clear();

            categoryPanel.Controls.Add(new Label
            {
                Text = "MENU",
                Size = new Size(144, 30),
                Font = AppTheme.MakeFont(11F, FontStyle.Bold),
                ForeColor = AppTheme.Muted
            });

            List<string> categories = new List<string> { AllMeals };
            categories.AddRange(menu.Select(m => m.Category).Distinct());

            foreach (string category in categories)
            {
                Button button = AppTheme.MakeButton(category, Color.White, AppTheme.TextDark);
                button.Size = new Size(144, 46);
                button.Margin = new Padding(0, 0, 0, 6);
                button.Padding = new Padding(8, 0, 0, 0);
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.UseMnemonic = false;
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.BorderColor = AppTheme.Line;
                button.Tag = category;
                button.Click += (s, e) => ShowCategory((string)((Button)s).Tag);

                categoryButtons.Add(button);
                categoryPanel.Controls.Add(button);
            }

            ShowCategory(AllMeals);
        }

        private void ShowCategory(string category)
        {
            categoryTitle.Text = category;
            foreach (Button button in categoryButtons)
            {
                bool selected = (string)button.Tag == category;
                button.BackColor = selected ? AppTheme.Primary : Color.White;
                button.ForeColor = selected ? Color.White : AppTheme.TextDark;
            }

            List<MealPackage> meals = category == AllMeals
                ? menu
                : menu.Where(m => m.Category == category).ToList();

            mealGrid.SuspendLayout();
            while (mealGrid.Controls.Count > 0) mealGrid.Controls[0].Dispose();

            foreach (MealPackage meal in meals)
            {
                MealCard card = new MealCard(meal, imageFolder);
                card.MealClicked += MealCard_Clicked;
                mealGrid.Controls.Add(card);
            }

            if (meals.Count == 0)
            {
                mealGrid.Controls.Add(new Label
                {
                    Text = "No meals to show. Check meals.txt, then press F5.",
                    AutoSize = true,
                    ForeColor = AppTheme.Muted,
                    Margin = new Padding(8)
                });
            }

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

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = FINAL_LAB_EXAM_OOP10.Properties.Resources.Screenshot_2026_11_10_130319;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1022, 989);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // KioskForm
            // 
            ClientSize = new Size(1022, 989);
            Controls.Add(pictureBox1);
            Name = "KioskForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

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
                        order.Dining.ToDisplay() + "  \u2022  " + paymentNote + "\n" +
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