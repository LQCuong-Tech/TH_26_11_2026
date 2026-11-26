using System;
using System.Windows.Forms;
using _6_7_PowerGridScadaSystem.GUI;

namespace _6_7_PowerGridScadaSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPowerGridMonitor());
        }
    }
}