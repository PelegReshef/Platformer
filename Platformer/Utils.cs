using System.Runtime.InteropServices;

namespace Platformer
{
    public struct Vector2
    {
        public double x;
        public double y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public Vector2 Normalized()
        {
            return this.Divided(Length());
        }
        public Vector2 Multiplied(double num)
        {
            return new Vector2(num * x, num * y);
        }
        public Vector2 Divided(double num)
        {
            return new Vector2(num / x, num / y);
        }
    }
    public static class InputManager
    {
        public enum InputType
        {
            None,
            Up,
            Down,
            Left,
            Right,
            Back
        }
        public enum InputListType
        {
            movement,
            navigation,
        }
        private static readonly ConsoleKey[] movementKeys = 
        {
            ConsoleKey.W,
            ConsoleKey.UpArrow,
            ConsoleKey.A,
            ConsoleKey.LeftArrow,
            ConsoleKey.S,
            ConsoleKey.DownArrow,
            ConsoleKey.D,
            ConsoleKey.RightArrow,
        };
        private static readonly ConsoleKey[] navKeys = 
        {
            ConsoleKey.UpArrow,
            ConsoleKey.DownArrow,
        };
        // calling user32 for better input detection
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        public static List<InputType> GetInput(InputListType ilt)
        {
            List<InputType> inputList = new List<InputType>();
            switch (ilt)
            {
                case InputListType.movement:
                    for (int i = 0; i < movementKeys.Length; i++)
                    {
                        if ((GetAsyncKeyState((int)movementKeys[i]) & 0x8000) != 0)
                        {
                            switch (i + 1)
                            {
                                case 1:
                                case 2:
                                    inputList.Add(InputType.Up);
                                    break;
                                case 3:
                                case 4:
                                    inputList.Add(InputType.Left);
                                    break;
                                case 5:
                                case 6:
                                    inputList.Add(InputType.Down);
                                    break;
                                case 7:
                                case 8:
                                    inputList.Add(InputType.Right);
                                    break;
                            }
                        }
                    }
                    break;

                case InputListType.navigation:
                    for (int i = 0; i <= movementKeys.Length; i++)
                    {
                        if ((GetAsyncKeyState((int)movementKeys[i]) & 0x8000) != 0)
                        {
                            switch (i + 1)
                            {
                                case 1:
                                    inputList.Add(InputType.Up);
                                    break;

                                case 2:
                                    inputList.Add(InputType.Down);
                                    break;
                            }
                        }
                    }
                    break;
            }
            return inputList; 
            

        }
    }

}