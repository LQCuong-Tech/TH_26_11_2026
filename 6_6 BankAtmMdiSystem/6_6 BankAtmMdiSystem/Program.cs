using System;
using System.Windows.Forms;
using _6_6_BankAtmMdiSystem.GUI;

namespace _6_6_BankAtmMdiSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmBankAtmMain());
        }
    }
}