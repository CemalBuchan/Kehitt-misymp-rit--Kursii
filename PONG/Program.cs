using Raylib_cs;
using System.Numerics;

namespace PONG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int screen_width = 700;
            int screen_height = 450;

            Raylib.InitWindow(screen_width, screen_height, "PONG");

            
            Vector2 circlePos = new Vector2(screen_width / 2, screen_height / 2);
            Vector2 circleVel = new Vector2(200, 200); 

            Vector2 p1Position = new Vector2(10, 150);
            Vector2 p1Size = new Vector2(30, 150);

            Vector2 p2Position = new Vector2(screen_width - 40, 150);
            Vector2 p2Size = new Vector2(30, 150);

            int p1Score = 0;
            int p2Score = 0;

            while (!Raylib.WindowShouldClose())
            {

                
                if (Raylib.IsKeyDown(KeyboardKey.W) && p1Position.Y > 0)
                    p1Position.Y -= 300 * Raylib.GetFrameTime();
                if (Raylib.IsKeyDown(KeyboardKey.S) && p1Position.Y < screen_height - p1Size.Y)
                    p1Position.Y += 300 * Raylib.GetFrameTime();

                if (Raylib.IsKeyDown(KeyboardKey.Up) && p2Position.Y > 0)
                    p2Position.Y -= 300 * Raylib.GetFrameTime();
                if (Raylib.IsKeyDown(KeyboardKey.Down) && p2Position.Y < screen_height - p2Size.Y)
                    p2Position.Y += 300 * Raylib.GetFrameTime();

                circlePos += circleVel * Raylib.GetFrameTime();

                if (circlePos.Y < 10 || circlePos.Y > screen_height - 10)
                    circleVel.Y *= -1;

                if (circlePos.X - 10 < p1Position.X + p1Size.X &&
                    circlePos.X - 10 > p1Position.X &&
                    circlePos.Y > p1Position.Y &&
                    circlePos.Y < p1Position.Y + p1Size.Y)
                {
                    circleVel.X *= -1;
                }

                if (circlePos.X + 10 > p2Position.X &&
                    circlePos.X + 10 < p2Position.X + p2Size.X &&
                    circlePos.Y > p2Position.Y &&
                    circlePos.Y < p2Position.Y + p2Size.Y)
                {
                    circleVel.X *= -1;
                }

                if (circlePos.X < 0)
                {
                    p2Score++;
                    circlePos = new Vector2(screen_width / 2, screen_height / 2);
                    circleVel = new Vector2(200, 200);
                }
                else if (circlePos.X > screen_width)
                {
                    p1Score++;
                    circlePos = new Vector2(screen_width / 2, screen_height / 2);
                    circleVel = new Vector2(-200, 200);
                }

                
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                Raylib.DrawRectangleV(p1Position, p1Size, Color.Gray);
                Raylib.DrawRectangleV(p2Position, p2Size, Color.Gray);
                Raylib.DrawCircleV(circlePos, 10, Color.White);

                Raylib.DrawText(p1Score.ToString(), 200, 20, 40, Color.White);
                Raylib.DrawText(p2Score.ToString(), 500, 20, 40, Color.White);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
