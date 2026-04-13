using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    internal struct Vector2
    {
        float x;
        float y;

        public static readonly Vector2 Zero = new Vector2(0);
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(float f)
        {
            this.x = f;
            this.y = f;
        }
        public Vector2()
        {
            this.x = 0;
            this.y = 0;
        }

        public Vector2 Normalized()
        {
            float len = Legnth();
            return new Vector2(x / len, y / len);
        }
        public float Legnth()
        {
            return MathF.Sqrt(x * x + y * y);
        }
        public float LegnthSquared()
        {
            return (x * x + y * y);
        }
        public float Angle()
        {
            return MathF.Atan2(x, y);
        }

        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return (v1.x * v2.x + v1.y * v2.y);
        }
        
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        }
        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x / v2.x, v1.y / v2.y);
        }
        public static Vector2 operator +(Vector2 v1, float f)
        {
            return new Vector2(v1.x + f, v1.y + f);
        }
        public static Vector2 operator -(Vector2 v1, float f)
        {
            return new Vector2(v1.x - f, v1.y - f);
        }
        public static Vector2 operator *(Vector2 v1, float f)
        {
            return new Vector2(v1.x * f, v1.y * f);
        }
        public static Vector2 operator /(Vector2 v1, float f)
        {
            return new Vector2(v1.x / f, v1.y / f);
        }
    }
}
