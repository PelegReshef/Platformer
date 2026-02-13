using System.Runtime.InteropServices;
namespace Platformer
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                HashSet<InputManager.InputType> il = InputManager.GetInput();
                foreach (var input in il)
                {
                    Console.WriteLine(input);
                }
                Thread.Sleep(50);
            }
        }
    }

}
