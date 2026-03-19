namespace Logic;

using BulletSystem;
using System.Numerics;
using Grid;
using Bullet;
using Enemy;
using FloatingTextSystem;
using CollectSystem;
public class Logic
{
    public Vector2 ClosestEnemy;
    public void CollisionCheck(FloatingTextSystem TextSystem, BulletSystem BSystem, CollectSystem CSystem, Grid grid)
    {
        if (BSystem.bullet_list.Count < 1) return;
        for (int x = 0; x < BSystem.bullet_list.Count; x++)
        {
            Bullet bullet = BSystem.bullet_list[x];
            List<Enemy> EList_InCell = grid.Get_EnemiesInRadius(bullet.position.X + bullet.Size.X / 2,
            bullet.position.Y + bullet.Size.Y / 2); 
            if (EList_InCell.Count > 0)
            {

                for (int y = 0; y < EList_InCell.Count; y++)
                {
                    if (!EList_InCell[y].Is_Active) { continue; }
                    if (AABB_CollisionCheck(bullet.position, bullet.Size, EList_InCell[y].position, EList_InCell[y].Size))
                    {
                        bullet.GotHit();
                        EList_InCell[y].GotHit(bullet.Damage);
                        
                        // if its dead
                        if (!EList_InCell[y].Is_Active)CSystem.Spawn(EList_InCell[y].position); 
                        TextSystem.CreateText(bullet.position.X, bullet.position.Y, bullet.Damage.ToString());
                        break;
                    }
                }
            }
        }
    }

    // It is biased. Searchs bottom row to top. 
    public void FindClosestEnemy(float playerposx, float playerposy, int playerradius, Grid grid)
    {

        List<Enemy> pool = new();
        int playerCellY = (int)playerposy / grid.Grid_scale;

        for (int row = playerCellY; row >= 0; row--) // go upward
        {
            for (int col = 0; col < grid.maxCellX; col++)
            {
                List<Enemy> list = grid.Get_Cell(
                    col * grid.Grid_scale,
                    row * grid.Grid_scale
                );

                if (list.Count > 0)
                {
                    foreach (var e in list)
                        pool.Add(e);
                }
            }

            if (pool.Count > 0)
                break;
        }

        if (pool.Count == 0)
        { ClosestEnemy = Vector2.Zero; return; }

        float dist = float.MaxValue;
        Enemy closest = pool[0];

        foreach (var e in pool)
        {
            float dx = e.position.X - playerposx;
            float dy = e.position.Y - playerposy;
            float d = dx * dx + dy * dy;

            if (d < dist)
            {
                dist = d;
                closest = e;
            }
        }
        Vector2 EneCenter = new Vector2(MathF.Round(closest.position.X + closest.Size.X / 2), MathF.Round(closest.position.Y + closest.Size.Y / 2));
        ClosestEnemy = Normalize(EneCenter - new Vector2(playerposx - playerradius / 2, playerposy - playerradius / 2));
    }

    // Vector2.Normalize function was not working so I wrote it myself
    private Vector2 Normalize(Vector2 vector)
    {
        float len = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        if (len == 0) return new Vector2(0, 0);
        return new Vector2(vector.X / len, vector.Y / len);
    }
    
    private bool AABB_CollisionCheck(
       Vector2 posA, Vector2 SizeA,
       Vector2 posB, Vector2 SizeB)
    {
        return posA.X < posB.X + SizeB.X &&
                posA.X + SizeA.X > posB.X &&
                posA.Y < posB.Y + SizeB.Y &&
                posA.Y + SizeA.Y > posB.Y;
    }
}