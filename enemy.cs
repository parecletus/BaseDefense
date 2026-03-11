namespace Enemy;

using System.Numerics;
using Entity;
public class Enemy : Entity
{
    public Vector2 dir;
    public Enemy( Vector2 pos, Vector2 _dir,int ms =90, int width = 4, int height = 4)
     : base(ms, pos, width, height,1)
    {
        dir  = _dir;
    }
    public void Update(float dt){
        Move(dir, dt);
    }
}