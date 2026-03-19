namespace BulletSystem;

using Bullet;
using Raylib_cs;
using System.Numerics;
using GunEntity;

public class BulletSystem
{
    public readonly List<Bullet> bullet_list = new List<Bullet>();
    public void Update(float dt, float playerposx, float playerposy, Vector2 dir, GunEntity gun)
    {
        if (bullet_list.Count > 0) bullet_list.ForEach(b => b.Update(dt)); // move

        if (gun.GunShootUpdate(dt))
        {
            List<Bullet> list = gun.Shoot(dir, new Vector2(playerposx, playerposy));
            foreach (Bullet i in list) bullet_list.Add(i);
        }

        bullet_list.RemoveAll(b => !b.Is_Active); // clean
    }
    public void Draw()
    {
        foreach (Bullet i in bullet_list)
        {
            i.Draw();
            DrawTrail(i);
        }
    }
    public void DrawTrail(Bullet bullet)
    {
        Color color = bullet.color;
        color.A = 128;
        
        Raylib.DrawRectanglePro(new Rectangle(bullet.position, bullet.Size.X, bullet.Size.Y*1.5f), Vector2.Zero, 0f, color);
        color.A = 64;
        Raylib.DrawRectanglePro(new Rectangle(bullet.position, bullet.Size.X, bullet.Size.Y*3), Vector2.Zero, 0f, color);

    }
}