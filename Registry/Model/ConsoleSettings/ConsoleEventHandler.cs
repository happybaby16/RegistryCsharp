using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Model.ConsoleSettings
{
    public enum ConsoleEvent { SetSettings = 0, GetSettings = 1, AcceptSettings = 2 }
    public delegate void ConsoleStateHandler(object sender, ConsoleEventArgs e);
    public class ConsoleEventArgs
    {
        public ConsoleEvent Event { get; set; }
        public ConsoleEventArgs(ConsoleEvent _Event)
        {
            Event = _Event;
        }
    }
}
