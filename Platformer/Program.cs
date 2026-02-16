using System.Runtime.InteropServices;
using System.Numerics;
using Raylib_cs ;

namespace Platformer
{
    internal class Program
    {
        static Random rnd = new();
        static void Main(string[] args)
        {
            Object rect = new Object(new Vector2(540, 270), new Vector2(30, 30));
            rect.speed = 400;
            Raylib.InitWindow(1080, 540, "jkjkkjkjjk");

            //Object dvds[i] = new Object(new Vector2(1, 1), new Vector2(30, 30));
            //dvds[i].speed = 300;
            //dvds[i].dir = Vector2.Normalize(new Vector2(1.1f, 1));

            //bool atCornerX = false;
            //bool atCornerY = false;

            Object[] dvds = new Object[10];

            for (int i = 0; i < dvds.Length; i++)
            {
                float rndAngle = (float)rnd.NextDouble() * MathF.PI * 2f;
                Vector2 rndDir = new Vector2(MathF.Cos(rndAngle), MathF.Sin(rndAngle));
                dvds[i] = new Object(new Vector2(2, 2), new Vector2(30, 30));
                dvds[i].dir =  rndDir;
                dvds[i].speed = rnd.Next(200, 401);
            }

            bool lost = false;
                        
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                Vector2 vel = Vector2.Zero;
                if (Raylib.IsKeyDown(KeyboardKey.W))
                {
                    vel.Y -= 1;
                }
                if (Raylib.IsKeyDown(KeyboardKey.S))
                {
                    vel.Y += 1;
                }
                if (Raylib.IsKeyDown(KeyboardKey.A))
                {
                    vel.X -= 1;
                }
                if (Raylib.IsKeyDown(KeyboardKey.D))
                {
                    vel.X += 1;
                }
                if (vel == Vector2.Zero)
                {
                    rect.dir = Vector2.Zero;
                }
                else
                {
                    rect.dir = Vector2.Normalize(vel);

                }
                rect.Move();
                for (int i = 0; i < dvds.Length; i++)
                {
                    
                    if ((dvds[i].pos.X < 0.01 || dvds[i].pos.X > 1049.99) && (!dvds[i].atCornerX))   // reaches right and left sizes
                    {
                        dvds[i].dir = Vector2.Normalize(new Vector2(-dvds[i].dir.X, dvds[i].dir.Y));
                        dvds[i].atCornerX = true;
                        //Console.WriteLine("x: " + atCornerX);
                    }
                    else 
                        dvds[i].atCornerX = false;


                    if ((dvds[i].pos.Y < 0.01 || dvds[i].pos.Y > 509.99) && (!dvds[i].atCornerY)) // reaches top and bottom sides
                    {
                        dvds[i].dir = Vector2.Normalize(new Vector2(dvds[i].dir.X, -dvds[i].dir.Y));
                        dvds[i].atCornerY = true;
                        //Console.WriteLine("y: " + atCornerY);
                    }
                    else 
                        dvds[i].atCornerY = false;
                
                    dvds[i].Move();

                    if (rect.GetCollision(dvds[i].pos, dvds[i].size))
                    {
                        Raylib.DrawText("you lost", 400, 200, 50, Color.Red);
                        lost = true;
                        break;
                    }

                    Raylib.DrawRectangle((int)dvds[i].pos.X, (int)dvds[i].pos.Y, (int)dvds[i].size.X, (int)dvds[i].size.Y, Color.Blue);
                }
                if (lost)
                {
                    Raylib.EndDrawing();
                    break;
                }
                Raylib.DrawRectangle((int)rect.pos.X, (int)rect.pos.Y, (int)rect.size.X, (int)rect.size.Y, Color.Red);

                Raylib.EndDrawing();

            }
            if (lost)
            {
                Thread.Sleep(1000);
            }
            Raylib.CloseWindow();
        }
    }
    class Object
    {
        public Vector2 pos;
        public Vector2 dir;
        public Vector2 size;
        public float speed;

        public bool atCornerX = false;
        public bool atCornerY = false;

        public Object(Vector2 pos, Vector2 size)
        {
            this.pos = pos;
            this.size = size;

            dir = Vector2.Zero;
            speed = 300;
        }
        public void Move()
        {
            pos += dir * speed * Raylib.GetFrameTime();
        }

        public bool GetCollision(Vector2 pos, Vector2 size)
        {
            //bool inX = ((pos.X >= this.pos.X) && (pos.X <= (this.pos.X + this.size.X)));
            //bool inY = ((pos.Y >= this.pos.Y) && (pos.Y <= (this.pos.Y + this.size.Y)));
            //if (inX)
            //{
            //    Console.WriteLine("collide X");
            //}
            //if (inY)
            //{
            //    Console.WriteLine("collide Y");
            //}
            return
                this.pos.X < pos.X + size.X &&
                this.pos.X + this.size.X > pos.X &&

                this.pos.Y < pos.Y + size.Y &&
                this.pos.Y + this.size.Y > pos.Y;



        }


    }

}
