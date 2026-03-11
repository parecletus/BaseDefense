namespace Entity;

using System.Numerics;
using Raylib_cs;
public abstract class Entity
{
    protected int Move_speed;
    public Vector2 position;
    public bool Is_Active;
    int width;
    int height;
    Color color;
    Dictionary<int, Color> Base_Colors = new Dictionary<int, Color> { [0]=Color.Green, [1]=Color.Red, [2]= Color.White };
    public Entity(int _ms, Vector2 _pos, int _width, int _height, int color_index=0)
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
        Raylib.DrawRectangle((int)position.X, (int)position.Y, width, height, color);
    }
    public void Move(Vector2 dir, float dt)
    {
        if (Is_Active)
        {
            position.X += dir.X * Move_speed * dt;
            position.Y += dir.Y * Move_speed * dt;
        }
    }
}