using System.Runtime.InteropServices;
namespace Platformer
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int i = 0;
            while (true)
            {
                List<InputManager.InputType> il = InputManager.GetInput(InputManager.InputListType.movement);
                foreach (var input in il)
                {
                    Console.WriteLine(i + ", " + input);
                }
                i++;
                Thread.Sleep(50);
            }
        }
    }

}
