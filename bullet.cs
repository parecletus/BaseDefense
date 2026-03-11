namespace Bullet;
using Entity;
using System.Numerics;
public class Bullet : Entity
{
    public Vector2 dir;
    protected float timer_con;
    public Bullet(int _MoveSpeed, Vector2 _position, Vector2 _dir, float _timer_con=2, int width = 2, int height = 2) : base(_MoveSpeed, _position, width, height)
    {
        dir = _dir;
        timer_con = _timer_con;
    }
    public void Update(float dt)
    {
        Move(dir, dt);
        Update_Timer(dt);
    }
    void Update_Timer(float dt)
    {
        if (timer_con <= 0) Is_Active = false;
        else timer_con -= dt;
    }
}