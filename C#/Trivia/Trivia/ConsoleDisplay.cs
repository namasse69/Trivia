using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    public class ConsoleDisplay : IDispatchEvent
    {
        void IDispatchEvent.Display(String texte)
        {
            Console.WriteLine(texte);
        }

        public void Dispatch<TEvent>(TEvent @event)
        {
            if (@event.GetType() == typeof(PlayerRolledDice))
            {
                Console.WriteLine(@event. + " is the current player");
                Console.WriteLine("They have rolled a " + @event.);
            }
        }
    }
}
