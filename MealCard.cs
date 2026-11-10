using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace OOP10FEXLab
{
    // One tappable meal tile on the kiosk. Inherits Panel and raises MealClicked.
    public class MealCard : Panel
    {
        private readonly ToolTip tip = new ToolTip();
        private readonly Image photo;
        private bool hovering;

        public MealPackage Meal { get; private set; }
        public event EventHandler MealClicked;

        public MealCard(MealPackage meal, string imageFolder)
        {
            Meal = meal;
            Size = new Size(164, 200);
            Margin = new Padding(6);
            BackColor = Color.White;
            DoubleBuffered = true;

            PictureBox picture = new PictureBox
            {
                Location = new Point(10, 10),
                Size = new Size(144, 100),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            photo = TryLoadImage(imageFolder, meal.Code);
            if (photo != null) picture.Image = photo;
            else picture.Paint += DrawPlaceholder;

            Label name = new Label
            {
                Text = meal.Name,
                Location = new Point(6, 114),
                Size = new Size(152, 46),
                Font = AppTheme.MakeFont(9.5F, FontStyle.Bold),
                ForeColor = AppTheme.TextDark,
                TextAlign = ContentAlignment.TopCenter,
                UseMnemonic = false
            };

            Label price = new Label
            {
                Text = AppTheme.Money(meal.Price),
                Location = new Point(6, 162),
                Size = new Size(152, 28),
                Font = AppTheme.MakeFont(12F, FontStyle.Bold),
                ForeColor = AppTheme.Primary,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(picture);
            Controls.Add(name);
            Controls.Add(price);

            string tipText = meal.Description.Length == 0 ? meal.Name : meal.Name + "\n" + meal.Description;
            Wire(this, tipText);
            foreach (Control child in Controls) Wire(child, tipText);
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

        private void SetHover(bool value)
        {
            if (hovering == value) return;
            hovering = value;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color color = hovering ? AppTheme.Primary : AppTheme.Line;
            int width = hovering ? 3 : 1;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                color, width, ButtonBorderStyle.Solid,
                color, width, ButtonBorderStyle.Solid,
                color, width, ButtonBorderStyle.Solid,
                color, width, ButtonBorderStyle.Solid);
        }

        // Drawn "plate" with the meal code, used when there is no photo.
        private void DrawPlaceholder(object sender, PaintEventArgs e)
        {
            Control box = (Control)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle plate = new Rectangle(22, 4, box.Width - 44, box.Height - 8);
            Rectangle food = Rectangle.Inflate(plate, -16, -14);

            using (Brush plateBrush = new SolidBrush(Color.FromArgb(240, 236, 230)))
            using (Brush foodBrush = new SolidBrush(AppTheme.ForCategory(Meal.Category)))
            using (Font font = AppTheme.MakeFont(14F, FontStyle.Bold))
            using (StringFormat center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.FillEllipse(plateBrush, plate);
                g.FillEllipse(foodBrush, food);
                g.DrawString(Meal.Code, font, Brushes.White, food, center);
            }
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                tip.Dispose();
                if (photo != null) photo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}