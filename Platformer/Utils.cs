using System;
using System.Runtime.InteropServices;

namespace Platformer
{
    public static class InputManager
    {
        public enum InputType
        {
            Up,
            Down,
            Left,
            Right,
            Back
        }
        private static readonly Dictionary<ConsoleKey, InputType> consoleKeyToInputType = new()
        {
            [ConsoleKey.W] = InputType.Up,
            [ConsoleKey.UpArrow] = InputType.Up,

            [ConsoleKey.A] = InputType.Left,
            [ConsoleKey.LeftArrow] = InputType.Left,

            [ConsoleKey.D] = InputType.Right,
            [ConsoleKey.RightArrow] = InputType.Right,

            [ConsoleKey.S] = InputType.Down,
            [ConsoleKey.DownArrow] = InputType.Down,

            [ConsoleKey.Escape] = InputType.Back,

        };
        private static readonly ConsoleKey[] allowedKeys = 
        {
            ConsoleKey.W,
            ConsoleKey.UpArrow,
            ConsoleKey.A,
            ConsoleKey.LeftArrow,
            ConsoleKey.S,
            ConsoleKey.DownArrow,
            ConsoleKey.D,
            ConsoleKey.RightArrow,
            ConsoleKey.Escape,
        };
        // calling user32 for better input detection
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        public static HashSet<InputType> GetInput()
        {
            HashSet<InputType> inputList = new HashSet<InputType>();
            
            for (int i = 0; i < allowedKeys.Length; i++)
            {
                if ((GetAsyncKeyState((int)allowedKeys[i]) & 0x8000) != 0) // key is pressed
                {
                    InputType input = consoleKeyToInputType[allowedKeys[i]]; // get input type from a dictionary
                    inputList.Add(input);
                }
            }
            return inputList; 
        }
    }

}