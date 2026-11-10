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

            // Notepad files beside the .exe (bin\Debug): meals.txt (prices if the DB has none)
            // and a local copy of each order so the order numbers continue after a restart.
            TextFileDataStore textFiles = new TextFileDataStore(AppDomain.CurrentDomain.BaseDirectory);

            // Package meals + transaction record = Prof. Raymond's MySQL database (lab network).
            // Testing outside the lab with no database? Use this line instead:
            // IDataStore store = textFiles;
            IDataStore store = new DatabaseDataStore(textFiles);

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