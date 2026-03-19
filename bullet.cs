namespace Bullet;

using Entity;
using System.Numerics;
public class Bullet : Entity
{
    public Vector2 dir;
    public float Damage; 
    private float timer_con;
    protected int penetrationCount;
    private Vector2 trailPosition;
    
    public Bullet(float _MoveSpeed, Vector2 _position, Vector2 _dir, float _bulletdmg,int _penetrationCount = 1
    , float _timer_con = 2, int width = 5, int height = 5) : base(_MoveSpeed, _position, width, height)
    {
        dir = _dir;
        timer_con = _timer_con;
        penetrationCount = _penetrationCount;
        Damage = _bulletdmg;
    }
    
    public void Update(float dt)
    {
        trailPosition  = position;  
        Move(dir, dt);
        Update_Timer(dt);
    }
    void Update_Timer(float dt)
    {
        if (timer_con <= 0) Is_Active = false;
        else timer_con -= dt;
    }

    public void GotHit()
    {
        penetrationCount -= 1;
        if (penetrationCount <= 0) Is_Active = false;
    }
}