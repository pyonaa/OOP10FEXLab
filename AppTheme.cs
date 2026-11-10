using System.Drawing;
using System.Windows.Forms;

namespace OOP10FEXLab
{
    // Colors, fonts and small helpers shared by all the forms.
    public static class AppTheme
    {
        public const string StoreName = "Kainan Express";

        public static readonly Color Primary = Color.FromArgb(200, 32, 38);
        public static readonly Color Accent = Color.FromArgb(255, 196, 37);
        public static readonly Color Success = Color.FromArgb(30, 132, 73);
        public static readonly Color Background = Color.FromArgb(255, 247, 237);
        public static readonly Color TextDark = Color.FromArgb(45, 36, 30);
        public static readonly Color Muted = Color.FromArgb(125, 112, 100);
        public static readonly Color Line = Color.FromArgb(232, 222, 210);

        public static readonly Color MonitorNavy = Color.FromArgb(14, 52, 120);
        public static readonly Color MonitorScreen = Color.FromArgb(214, 232, 255);
        public static readonly Color MonitorColumn = Color.FromArgb(190, 216, 250);
        public static readonly Color MonitorTile = Color.FromArgb(244, 249, 255);

        private static readonly Color[] CategoryColors =
        {
            Color.FromArgb(214, 93, 52), Color.FromArgb(200, 32, 38), Color.FromArgb(222, 150, 24),
            Color.FromArgb(120, 72, 40), Color.FromArgb(46, 125, 90), Color.FromArgb(160, 60, 120)
        };

        public static string Money(decimal amount)
        {
            return "₱ " + amount.ToString("#,##0.00");
        }

        public static Font MakeFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font("Segoe UI", size, style);
        }

        public static Color ForCategory(string category)
        {
            int sum = 0;
            foreach (char ch in category) sum += ch;
            return CategoryColors[sum % CategoryColors.Length];
        }

        public static Button MakeButton(string text, Color back, Color fore)
        {
            Button button = new Button
            {
                Text = text,
                BackColor = back,
                ForeColor = fore,
                FlatStyle = FlatStyle.Flat,
                Font = MakeFont(10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }
    }
}