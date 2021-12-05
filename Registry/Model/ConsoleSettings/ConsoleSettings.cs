using System;
using Microsoft.Win32;

namespace Registry.Model.ConsoleSettings
{
    public class ConsoleSettings
    {
        public event ConsoleStateHandler StateChangedEvent;
        public event ConsoleStateHandler AcceptSettingsEvent;
        private static RegistryKey currentKey = Microsoft.Win32.Registry.CurrentUser;
        private static string _SettingsPath {get=> "ConsoleSettings";}
        public int ColorForeground { get; set; }
        public int ColorBackground { get; set; }
        public ConsoleSettings()
        {
            GetSettings();
            AcceptSettings();
        }
        public void AcceptSettings()
        {

            Console.ForegroundColor = (ConsoleColor)ColorForeground;
            Console.BackgroundColor = (ConsoleColor)ColorBackground;
            if (AcceptSettingsEvent != null) AcceptSettingsEvent(this, new ConsoleEventArgs(ConsoleEvent.AcceptSettings));
        }
        public void SetSetting(ConsoleColor fGround, ConsoleColor bGround)
        {
            var subKey = currentKey.CreateSubKey(_SettingsPath, true);
            subKey.SetValue("Foreground", (int)fGround, RegistryValueKind.DWord);
            subKey.SetValue("Background", (int)bGround, RegistryValueKind.DWord);
            subKey.Close();
            ColorForeground = (int)fGround;
            ColorBackground = (int)bGround;
            if (StateChangedEvent != null) StateChangedEvent(this, new ConsoleEventArgs(ConsoleEvent.SetSettings));
        }
        public void GetSettings()
        {
            var subKey = currentKey.OpenSubKey(_SettingsPath, true);
            if (subKey != null)
            {
                ColorForeground = (int)subKey.GetValue("Foreground");
                ColorBackground = (int)subKey.GetValue("Background");
                subKey.Close();
            }
            else
            {
                ColorForeground = 15;
                ColorBackground = 0;
            }
            
            if (StateChangedEvent != null) StateChangedEvent(this, new ConsoleEventArgs(ConsoleEvent.GetSettings));
        }
    }
}
