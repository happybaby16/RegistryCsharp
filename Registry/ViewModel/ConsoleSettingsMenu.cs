using System;
using System.Diagnostics;
using System.Threading;
using Registry.Model.ConsoleSettings;
using Registry.View;

namespace Registry.ViewModel
{
 
    public static class ConsoleSettingsMenu
    {
        public static ConsoleSettings cs = new ConsoleSettings();
        public static Thread ThreadMenu = new Thread(new ThreadStart(Worker));
        public static void Worker()
        {
            cs.AcceptSettingsEvent += Printer.Print;
            Printer.Print(null, null);
            while (true)
            {
                char Key = Console.ReadKey().KeyChar;
                Key = char.ToLower(Key);
                switch (Key)
                {
                    case 'y':
                        Printer.PrintColor();
                        string line = Console.ReadLine();
                        string[] colors = line.Split(' ');
                        cs.SetSetting((ConsoleColor)Convert.ToInt32(colors[0]), (ConsoleColor)Convert.ToInt32(colors[1]));
                        Printer.Clear();
                        cs.AcceptSettings();
                        break;
                    default:
                        Printer.Clear();
                        Printer.Print(null,null);
                        break;
                }
                if (Key == 'n')
                {
                    ThreadMenu.Abort();
                    Printer.Clear();
                    break;
                }
            }
        }
    }
}
