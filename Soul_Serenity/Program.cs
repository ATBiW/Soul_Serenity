using System;
using System.Windows.Forms;
using AIMLbot;
using AIMLbot.AIMLTagHandlers;

namespace Soul_Serenity
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize and run the chat application
            Application.Run(new LoadingScreen());
        }
    }
}
