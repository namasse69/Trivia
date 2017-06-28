using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    public class ConsoleDisplay : IDisplay
    {
        void IDisplay.Display(String texte)
        {
            Console.WriteLine(texte);
        }
    }
}
