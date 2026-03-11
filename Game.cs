namespace Game;
using System.Numerics;
using Bullet;
using Enemy;
using Timer;
using Player;
using Gun;
using GunTypes;
using Raylib_cs;
public class Game
{
    private const int GUNOFFSET = 20; // I like the visuals of bullets spawning in front of player
    private readonly List<Bullet> bullet_list = new List<Bullet>();
    private readonly List<Enemy> enemy_list = new List<Enemy>();
    private Timer ShootRate = new Timer(0.1f);
    private Timer SpawnRate = new Timer(0.1f);
    public Player player = new Player(new Vector2(30, 500));
    public Gun gun = Guntypes.basegun;
    public Game()
    {
    }
    public void Update(float dt)
    {
        player.Update(dt);
        if (bullet_list.Count > 0) bullet_list.ForEach(b => b.Update(dt));
        if (enemy_list.Count > 0) enemy_list.ForEach(e => e.Update(dt));
        if (SpawnRate.Update(dt)) enemy_list.Add(new Enemy(new Vector2(50, 50), new Vector2(0, 1)));
        if (ShootRate.Update(dt))
        {
            List<Bullet> list = gun.Get_Bulletposition(new Vector2(0, -1), new Vector2(player.position.X ,player.position.Y-GUNOFFSET) );
            foreach (var i in list) bullet_list.Add(i);
        }

        bullet_list.RemoveAll(b => !b.Is_Active);
        enemy_list.RemoveAll(e => !e.Is_Active);
    }
    public void Draw()
    {
        bullet_list.ForEach(b => b.Draw());
        enemy_list.ForEach(b => b.Draw());
        player.Draw();
        Raylib.DrawText(enemy_list.Count.ToString(),100,40 ,10 , Color.Red);
        Raylib.DrawText(bullet_list.Count.ToString(),100,20 ,10 , Color.White);   
    }
}