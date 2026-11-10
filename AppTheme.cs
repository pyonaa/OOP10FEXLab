using System.Drawing;
using System.Windows.Forms;

namespace OOP10FEXLab
{
    // Colors, fonts and small helpers shared by all the forms.
    public static class AppTheme
    {
        public const string StoreName = "Kainan Express";

        public static readonly Color Primary = Color.FromArgb(228, 0, 43);       // Chili #E4002B
        public static readonly Color Accent = Color.FromArgb(255, 184, 28);      // Mango #FFB81C
        public static readonly Color Success = Color.FromArgb(43, 168, 74);      // Leaf green #2BA84A
        public static readonly Color Background = Color.FromArgb(255, 248, 236); // Cream #FFF8EC
        public static readonly Color TextDark = Color.FromArgb(31, 26, 23);      // Charcoal #1F1A17
        public static readonly Color Muted = Color.FromArgb(138, 127, 117);      // Muted #8A7F75
        public static readonly Color Line = Color.FromArgb(239, 228, 212);       // Line #EFE4D4

        public static string Money(decimal amount)
        {
            return "₱ " + amount.ToString("#,##0.00");
        }
    }
}
