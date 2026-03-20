using Raylib_cs;
namespace HelloWorld;

using Game;
using Menu;
using InputSystem;
internal static class Program
{
    // STAThread is required if you deploy using NativeAOT on Windows - See https://github.com/raylib-cs/raylib-cs/issues/301
    [System.STAThread]

    public static void Main()
    {
        Raylib.InitWindow(300, 600, "Default");
        Raylib.SetTargetFPS(60);
        InputSystem Input = new InputSystem();
        Game game = new Game();
        Menu menu = new Menu();
        menu.Start();
        bool IsGameOn = false;
        while (!Raylib.WindowShouldClose())
        {
            Input.Update();
            float dt = Raylib.GetFrameTime();
            if (Input.State.Q) IsGameOn = !IsGameOn;
                
            if (IsGameOn) game.Update(dt, Input.State);
            else menu.Update(Input.State);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            if (IsGameOn) game.Draw();
            else menu.Draw();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}