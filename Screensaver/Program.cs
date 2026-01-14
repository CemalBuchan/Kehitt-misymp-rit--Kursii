using Raylib_cs;
using System.Numerics;
namespace Screensaver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int screen_width = 800;
            int screen_height = 800;
            

            Raylib.InitWindow(screen_width, screen_height, "Screensaver");
            Vector2 A = new Vector2(screen_width / 2, 40);
            Vector2 B = new Vector2(40, screen_height / 2);
            Vector2 C = new Vector2(screen_width - 40, screen_height * 0.75f);

            Vector2 dirA = new Vector2(1, 1);
            Vector2 dirB = new Vector2(1, -1);
            Vector2 dirC = new Vector2(-1, 1);

            while (Raylib.WindowShouldClose() == false)
            {   

                A = A + dirA * 200 * Raylib.GetFrameTime(); 
                B = B + dirB * 200 * Raylib.GetFrameTime();
                C = C + dirC * 200 * Raylib.GetFrameTime();


                // Koska en ymmärtänyt mitä piti tehdä, kysyin apua tekoälyltä ja sen jälkeen ymmärsin.
                // Alla olevat if-lauseet tarkistavat, osuuko jokin kulmista näytön reunaan,
                // ja jos osuu, liikesuunta käännetään täysin vastakkaiseksi.

                if (A.X <= 0 || A.X >= screen_width)
                    dirA.X *= -1;

                if (A.Y <= 0 || A.Y >= screen_height)
                    dirA.Y *= -1;

                if (B.X <= 0 || B.X >= screen_width)
                    dirB.X *= -1;

                if (B.Y <= 0 || B.Y >= screen_height)
                    dirB.Y *= -1;

                if (C.X <= 0 || C.X >= screen_width)
                    dirC.X *= -1;

                if (C.Y <= 0 || C.Y >= screen_height)
                    dirC.Y *= -1;

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                Raylib.DrawLineV(A, B, Color.Green);
                Raylib.DrawLineV(B, C, Color.Yellow);
                Raylib.DrawLineV(C, A, Color.Red);

               Raylib.EndDrawing();


            }

            Raylib.CloseWindow();
        }
    }
}
