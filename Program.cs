using Raylib_cs;
namespace HelloWorld;
using Game; 

internal static class Program
{
        // STAThread is required if you deploy using NativeAOT on Windows - See https://github.com/raylib-cs/raylib-cs/issues/301
    [System.STAThread]
    
    public static void Main()
    {
        
        Raylib.InitWindow(300,600, "Default");
        Raylib.SetTargetFPS(60);
        Game game = new Game ();
        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();
            game.Update(dt);
            Raylib.BeginDrawing();
            game.Draw();
            Raylib.ClearBackground(Color.Black);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}