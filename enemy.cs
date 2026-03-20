namespace Enemy;

using System.Numerics;
using Entity;
using windowsetting;
public class Enemy : Entity
{
    public Vector2 dir;
    public float  hp;
    /// <summary>Initialize Enemy. Vector and Dir is mandotary.</summary>
    public Enemy(Vector2 pos, Vector2 _dir, int _colorindex,int _hp =40,  int ms = 15, int _width = 10, int _height = 10)
     : base(ms, pos, _width, _height, color_index: _colorindex)
    {
        dir = _dir;
        hp = _hp;
    }
    public void Update(float dt)
    {
        if (position.Y<windowsetting.windowsize.Y-60) Move(dir, dt);
    }
    public void GotHit(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
            Is_Active = false;
    }

}