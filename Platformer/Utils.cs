using System;
using System.Runtime.InteropServices;

namespace Platformer
{
    //public struct Vector2
    //{
    //    public float x;
    //    public float y;

    //    public Vector2(float x, float y)
    //    {
    //        this.x = x;
    //        this.y = y;
    //    }


    //    // legnths
    //    public float Length()
    //    {
    //        return MathF.Sqrt(x * x + y * y);
    //    }
    //    public float LegnthSquared()
    //    {
    //        return x * x + y * y;
    //    }

    //    // normalization
    //    public Vector2 Normalized()
    //    {
    //        if (LegnthSquared() == 0)
    //        {
    //            return Zero();
    //        }
    //        return this / Length();
    //    }
    //    //public Vector2 Multiplied(float num)
    //    //{
    //    //    return new Vector2(num * x, num * y);
    //    //}
    //    //public Vector2 Divided(float num)
    //    //{
    //    //    return new Vector2(num / x, num / y);
    //    //}


    //    // multipication
    //    public static Vector2 operator *(Vector2 vec, float a)
    //    {
    //        return new Vector2(vec.x * a, vec.y * a);
    //    }
    //    public static Vector2 operator *(float a, Vector2 vec)
    //    {
    //        return new Vector2(vec.x * a, vec.y * a);
    //    }
    //    public static Vector2 operator *(Vector2 vec1, Vector2 vec2)
    //    {
    //        return new Vector2(vec1.x * vec2.x, vec1.y * vec2.y);
    //    }


    //    // division
    //    public static Vector2 operator /(Vector2 vec, float a)
    //    {
    //        if (a == 0)
    //        {
    //            throw new DivideByZeroException();
    //        }
    //        return new Vector2(vec.x / a, vec.y / a);
    //    }
    //    public static Vector2 operator /(Vector2 vec1, Vector2 vec2)
    //    {
    //        if (vec2.x == 0 || vec2.y == 0) // cant divide a vector with a zero in it
    //        {
    //            throw new DivideByZeroException("cant divide by a vector that one of its values it zero");
    //        }
    //        return new Vector2(vec1.x / vec2.x, vec1.y / vec2.y);
    //    }


    //    // addition
    //    public static Vector2 operator +(Vector2 vec, float a)
    //    {
    //        return new Vector2(vec.x + a, vec.y + a);
    //    }
    //    public static Vector2 operator +(float a, Vector2 vec)
    //    {
    //        return new Vector2(vec.x + a, vec.y + a);
    //    }
    //    public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
    //    {
    //        return new Vector2(vec1.x + vec2.x, vec1.y + vec2.y);
    //    }


    //    // subtraction
    //    public static Vector2 operator -(Vector2 vec, float a)
    //    {
    //        return new Vector2(vec.x - a, vec.y - a);
    //    }
    //    public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
    //    {
    //        return new Vector2(vec1.x - vec2.x, vec1.y - vec2.y);
    //    }



    //    public static Vector2 Zero()
    //    {
    //        return new Vector2(0, 0);
    //    }
    //}
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