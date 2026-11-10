
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP10FEXLab
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Package meals + transactions record = notepad files beside the .exe (bin\Debug).
            // When the prof's database code is ready, change only this line to:
            // IDataStore store = new DatabaseDataStore();
            IDataStore store = new TextFileDataStore(AppDomain.CurrentDomain.BaseDirectory);

            OrderManager manager;
            try
            {
                manager = new OrderManager(store);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the transactions record.\n\n" + ex.Message,
                    "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KioskForm kiosk = new KioskForm(manager);
            QueueMonitorForm monitor = new QueueMonitorForm(manager);
            ArrangeSideBySide(kiosk, monitor);

            monitor.Show(); // UI #1 - Queue / Claim Monitor
            Application.Run(kiosk); // UI #2 - Kiosk (closing it closes the app)
        }

        private static void ArrangeSideBySide(Form kiosk, Form monitor)
        {
            Rectangle area = Screen.PrimaryScreen.WorkingArea;
            int kioskWidth = Math.Max(kiosk.MinimumSize.Width, Math.Min(1040, (int)(area.Width * 0.62)));

            kiosk.StartPosition = FormStartPosition.Manual;
            kiosk.Bounds = new Rectangle(area.Left, area.Top, kioskWidth, area.Height);

            monitor.StartPosition = FormStartPosition.Manual;
            monitor.Bounds = new Rectangle(area.Left + kioskWidth, area.Top,
                Math.Max(monitor.MinimumSize.Width, area.Width - kioskWidth), area.Height);
        }
    }
}