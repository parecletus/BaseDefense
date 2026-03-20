namespace InputSystem;

using Raylib_cs;
using Input;
public class InputSystem
{
    public Input State ;
    public void Update()
    {
        State.MoveLeft = Raylib.IsKeyDown(KeyboardKey.Left);
        State.MoveRight = Raylib.IsKeyDown(KeyboardKey.Right);
        State.Up = Raylib.IsKeyPressed(KeyboardKey.Up);
        State.Down= Raylib.IsKeyPressed(KeyboardKey.Down);
        State.Click = Raylib.IsMouseButtonDown(MouseButton.Left);
        State.Q= Raylib.IsKeyPressed(KeyboardKey.Q);
        State.Enter= Raylib.IsKeyPressed(KeyboardKey.Enter);
    }
}
