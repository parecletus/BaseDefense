namespace ExpCube;

using System.Numerics;
using Raylib_cs;

public class ExpCube
{
    public static Vector2 windowsize;
    public Vector2 position;
    protected int radius { get; private set; }
    protected int MoveSpeed;
    public bool is_Active;
    public ExpCube(int posx, int posy, int _radius = 1, int ms = 60)
    {
        position = new Vector2(posx, posy);
        radius = _radius;
        MoveSpeed = ms;
        is_Active = true;
    }
    public void Draw()
    {
        Raylib.DrawCircle((int)position.X, (int)position.Y, radius, Color.Gray);
    }
    public void MoveUp(float dt)
    {
        if (is_Active)
            position.Y -= dt * MoveSpeed * 1;
    }
}



