namespace GunEntity;
// Lets me create gun 
using Timer;
using System.Numerics;
using Bullet;

public class GunEntity
{
    private delegate List<Bullet> Delegate_Update(Vector2 dir, Vector2 position);
    private readonly Delegate_Update tick;

    private float firerate;
    private float bullet_dmg;
    private  float bullet_speed;
    private  int bulletcount_pershot;
    private readonly float bullet_positionoffset;
    private Timer ShootRate;

    public GunEntity(float _firerate, int _bullet_dmg, float _bullet_speed,
    int _bcount_pershot = 1, int _spread_angle = 0, float _bullet_positionoffset = 1)
    {
        firerate = _firerate;
        bullet_speed = _bullet_speed;
        bullet_dmg = _bullet_dmg;
        bulletcount_pershot = _bcount_pershot;
        bullet_positionoffset = _bullet_positionoffset;
        ShootRate = new Timer(firerate);
        tick = _spread_angle == 0 ? StraightShot : SpreadShot;
    }
    public List<Bullet> Shoot(Vector2 dir, Vector2 pos) => tick(dir, pos);

    public void GunUpgrade(float percentfirerate = 1, float percentBulletDmg = 1, float percentBulletSpeed = 1,int _bulletcount=0)
    {
        firerate *= percentfirerate;
        ShootRate = new Timer(firerate); 
        bullet_dmg *= percentBulletDmg;
        bullet_speed *= percentBulletSpeed;
        bulletcount_pershot += _bulletcount; 
    }

    public bool GunShootUpdate(float dt)
    {
        if (ShootRate.Update(dt)) return true;
        else return false;
    }

    List<Bullet> SpreadShot(Vector2 direction, Vector2 position)
    {
        // TODO 
        return new List<Bullet>();
    }

    List<Bullet> StraightShot(Vector2 direction, Vector2 position)
    {
        List<Bullet> bullets = new();

        float start = -(bulletcount_pershot - 1) * bullet_positionoffset / 2f;

        for (int i = 0; i < bulletcount_pershot; i++)
        {
            float offset = start + i * bullet_positionoffset;
            Vector2 pos = new Vector2(position.X + offset, position.Y);

            bullets.Add(new Bullet(bullet_speed, pos, direction, bullet_dmg));
        }
        return bullets;
    }
}