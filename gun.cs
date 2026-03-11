namespace Gun;
// Lets me create gun 
using Timer;
using System.Numerics;
using Bullet;
public class Gun
{
    private delegate List<Bullet> Delegate_Update(Vector2 dir, Vector2 position);
    private readonly Delegate_Update tick;

    private readonly float firerate;
    private readonly float bullet_dmg;
    private readonly int bullet_speed;
    private readonly int bulletcount_pershot;
    private readonly float bullet_positionoffset;
    public Timer bulletTimer;
    public Gun(float _firerate, int _bullet_dmg, int _bullet_speed,
    int _bcount_pershot = 1, int _spread_angle = 0, float _bullet_positionoffset = 2)
    {
        firerate = _firerate;
        bulletTimer = new Timer(firerate);
        bullet_speed = _bullet_speed;
        bullet_dmg = _bullet_dmg;
        bulletcount_pershot = _bcount_pershot;
        bullet_positionoffset = _bullet_positionoffset;
        tick = _spread_angle == 0 ? SingleShot : SpreadShot;
    }
    public List<Bullet> Get_Bulletposition(Vector2 dir, Vector2 pos) => tick(dir, pos);
    List<Bullet> SpreadShot(Vector2 direction, Vector2 position)
    {
        return new List<Bullet>() {

        new Bullet(bullet_speed,position,direction)
    };
    }
    List<Bullet> SingleShot(Vector2 direction, Vector2 position)
    {
        if (bulletcount_pershot == 1) //single bullet
            return [
            new Bullet(bullet_speed,position,direction)
        ];
        else
        {
            List<Bullet> b = new List<Bullet>() { };
            if (bulletcount_pershot % 2 == 0) // even number of bullets
            {
                float gaps = bullet_positionoffset / bulletcount_pershot;
                for (int i = -bulletcount_pershot / 2; i < bulletcount_pershot / 2; i++)
                {
                    b.Add(new Bullet(bullet_speed, new Vector2(position.X - ((bullet_positionoffset * i * gaps)+3 ), position.Y), direction));
                }
                return b;
            }
            else // odd number of bullets
            {
                float gaps = bullet_positionoffset / bulletcount_pershot;
                for (int i = (1- bulletcount_pershot) / 2; i <=( bulletcount_pershot-1)/2 ; i++)
                {
                    b.Add(new Bullet(bullet_speed, new Vector2(position.X - ((bullet_positionoffset * i * gaps)+1), position.Y), direction));
                }
                return b;
            }
        }
    }
}