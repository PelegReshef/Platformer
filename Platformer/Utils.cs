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
        public static List<InputType> GetInput()
        {
            throw new NotImplementedException();
            

        }
    }

}