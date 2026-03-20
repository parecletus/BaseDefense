namespace Entity;

using System.Numerics;
using Raylib_cs;
using windowsetting;
public abstract class Entity
{
    protected static Vector2 windowsize => windowsetting.windowsize;

    protected float Move_speed;
    public Vector2 position;
    public bool Is_Active;
    int width;
    int height;
    public Color color;
    public Vector2 Size => new(width, height);
    Dictionary<int, Color> Base_Colors = new Dictionary<int, Color> { [0] = Color.Green, [1] = Color.Red, [2] = Color.White };
    public Entity(float _ms, Vector2 _pos, int _width, int _height, int color_index = 0)
    {
        Move_speed = _ms;
        position = _pos;
        Is_Active = true;
        width = _width;
        height = _height;
        color = Base_Colors[color_index];
    }
    public void Draw()
    {
        if (Is_Active)
            Raylib.DrawRectanglePro(
     new Rectangle(position.X, position.Y, width, height),
     Vector2.Zero, 0f, color);
    }
    public void Move(Vector2 dir, float dt)
    {
        // add offline Const.
        if (Is_Active && position.X  < windowsize.X && position.Y  < windowsize.Y)
        {
            position.X += dir.X * Move_speed * dt;
            position.Y += dir.Y * Move_speed * dt;
        }
    }
}