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
            Raylib.SetTargetFPS(60);

            Object[] dvds = new Object[20];
            Console.WriteLine("start");
            Console.WriteLine("---------");

            for (int i = 0; i < dvds.Length; i++)
            {
                float rndAngle = (float)rnd.NextDouble() * MathF.PI * 2f;
                Vector2 rndDir = new Vector2(MathF.Cos(rndAngle), MathF.Sin(rndAngle));
                dvds[i] = new Object(new Vector2(1f), new Vector2(30, 30));
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
                    
                    if ((dvds[i].pos.X < 0.01 || dvds[i].pos.X > 1050) && (!dvds[i].atCornerX))   // reaches right and left sizes
                    {
                        dvds[i].dir = Vector2.Normalize(new Vector2(-dvds[i].dir.X, dvds[i].dir.Y));
                        dvds[i].atCornerX = true;
                        //Console.WriteLine("x collision");
                    }
                    else 
                        dvds[i].atCornerX = false; //Console.WriteLine("x");


                    if ((dvds[i].pos.Y < 0.01 || dvds[i].pos.Y > 510) && (!dvds[i].atCornerY)) // reaches top and bottom sides
                    {
                        dvds[i].dir = Vector2.Normalize(new Vector2(dvds[i].dir.X, -dvds[i].dir.Y));
                        dvds[i].atCornerY = true;
                        //Console.WriteLine("y collision");
                    }
                    else 
                        dvds[i].atCornerY = false; //Console.WriteLine("y");
                
                    dvds[i].Move();

                    if (rect.GetCollision(dvds[i].pos, dvds[i].size))
                    {
                        Raylib.DrawText("you lost", 400, 200, 50, Color.Red);
                        lost = true;
                        break;
                    }
                    Color color = Color.FromHSV((dvds[i].pos.Y/ 540.0f) * 255f , 1, 1);
                    //Console.WriteLine("pos: " + dvds[i].pos.Y / 540f);

                    //Console.WriteLine("dir: " + dvds[i].dir);
                    //Console.WriteLine(dvds[i].pos);
                    Raylib.DrawRectangle((int)dvds[i].pos.X, (int)dvds[i].pos.Y, (int)dvds[i].size.X, (int)dvds[i].size.Y, color);
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
            return // use AABB collision detection
                this.pos.X < pos.X + size.X &&
                this.pos.X + this.size.X > pos.X &&

                this.pos.Y < pos.Y + size.Y &&
                this.pos.Y + this.size.Y > pos.Y;



        }


    }

}
