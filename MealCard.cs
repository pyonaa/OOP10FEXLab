using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FINAL_LAB_EXAM_OOP10.Properties;

namespace OOP10FEXLab
{
    // One tappable meal tile on the kiosk. Its look is set in the Designer (MealCard.Designer.cs).
    // This file only fills in the name, price and picture, and handles hover and click.
    public partial class MealCard : UserControl
    {
        private readonly Image photo;
        private bool hovering;

        public MealPackage Meal { get; private set; }
        public event EventHandler MealClicked;

        public MealCard(MealPackage meal, string imageFolder)
        {
            InitializeComponent();

            Meal = meal;
            nameLabel.Text = meal.Name;
            priceLabel.Text = AppTheme.Money(meal.Price);

            // Use the photo from the images folder if there is one,
            // otherwise use a built-in food picture that matches the meal name.
            photo = TryLoadImage(imageFolder, meal.Code);
            if (photo == null) photo = FoodImageFor(meal.Name);
            foodPicture.Image = photo;

            string tipText = meal.Description.Length == 0 ? meal.Name : meal.Name + "\n" + meal.Description;
            Wire(this, tipText);
            Wire(innerPanel, tipText);
            foreach (Control child in innerPanel.Controls) Wire(child, tipText);

            // Free the picture when the card is removed from the screen.
            Disposed += (s, e) => photo.Dispose();
        }

        protected virtual void OnMealClicked()
        {
            EventHandler handler = MealClicked;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        // Every part of the card is clickable and shows the description on hover.
        private void Wire(Control control, string tipText)
        {
            control.Cursor = Cursors.Hand;
            control.Click += (s, e) => OnMealClicked();
            control.MouseEnter += (s, e) => SetHover(true);
            control.MouseLeave += (s, e) => SetHover(ClientRectangle.Contains(PointToClient(MousePosition)));
            tip.SetToolTip(control, tipText);
        }

        // The card's own background is the border color, and the white inner panel sits inside it.
        // On hover the border turns red and gets 1px thicker (Padding 2 instead of 1).
        private void SetHover(bool value)
        {
            if (hovering == value) return;
            hovering = value;
            BackColor = hovering ? AppTheme.Primary : AppTheme.Line;
            Padding = new Padding(hovering ? 2 : 1);
        }

        // Picks a built-in food picture by looking for keywords in the meal name.
        // "family"/"bucket" and "pasta"/"spaghetti" are checked first so that
        // e.g. "Spaghetti & Chicken" shows pasta and "Bucket of 6 Chicken" shows the bucket.
        private static Image FoodImageFor(string mealName)
        {
            string name = mealName.ToLowerInvariant();
            if (name.Contains("family") || name.Contains("bucket")) return Resources.food_family;
            if (name.Contains("pasta") || name.Contains("spaghetti")) return Resources.food_pasta;
            if (name.Contains("burger")) return Resources.food_burger;
            if (name.Contains("chicken")) return Resources.food_chicken;
            if (name.Contains("rice")) return Resources.food_rice;
            return Resources.food_default;
        }

        private static Image TryLoadImage(string folder, string code)
        {
            foreach (string extension in new[] { ".png", ".jpg", ".jpeg" })
            {
                string path = Path.Combine(folder, code + extension);
                if (!File.Exists(path)) continue;

                try
                {
                    // Copy into memory so the file isn't locked while the app runs.
                    using (FileStream stream = File.OpenRead(path))
                    using (Image original = Image.FromStream(stream))
                    {
                        return new Bitmap(original);
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
    }
}
