namespace Player;

using Raylib_cs;
using System.Numerics;
using Input;
public class Player
{
    public Vector2 position;
    private int MoveSpeed;
    public int radius;
    public Player(float posx, float posy,int _radius =4 , int _Movespeed=200)
    {
        position = new Vector2(posx, posy);
        MoveSpeed = _Movespeed;
        radius = _radius;
    }
    public void Update(float dt,Input input)
    {
        
        if (input.MoveLeft)
        {
            position.X += dt * MoveSpeed * -1;
        }
        if (input.MoveRight)
        {
            position.X += dt * MoveSpeed * 1;
        }
    }
    public void Draw()
    {
        Raylib.DrawCircle((int)position.X,(int) position.Y, radius, Color.Green);
    }
}