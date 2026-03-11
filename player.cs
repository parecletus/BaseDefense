namespace Player;

using Raylib_cs;
using System.Numerics;
using Gun;
public class Player
{
    public Vector2 position;
    public int MoveSpeed;
    public Player(Vector2 _position, int _Movespeed=200)
    {
        position = _position;
        MoveSpeed = _Movespeed;
    }
    public void Update(float dt)
    {
        CheckInput(dt);
    }
    void CheckInput(float dt)
    {
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            position.X += dt * MoveSpeed * -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            position.X += dt * MoveSpeed * 1;
        }
    }
    public void Draw()
    {
        Raylib.DrawCircle((int)position.X,(int) position.Y, 4, Color.Green);
    }
}