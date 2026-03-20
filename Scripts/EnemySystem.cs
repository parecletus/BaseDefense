namespace EnemySystem;

using Timer;
using Enemy;
using Grid;
using System.Numerics;
using Raylib_cs;
using windowsetting;
public class EnemySystem
{
    public List<Enemy> enemy_list = new List<Enemy>();
    private Timer SpawnRate = new Timer(0.1f);
    private readonly Random random = new Random();
    private Random rng= new(); 
    public void Update(float dt)
    {
        enemy_list.RemoveAll(e => !e.Is_Active);
        if (SpawnRate.Update(dt)) enemy_list.Add(new Enemy(new Vector2(rng.Next(0,(int)windowsetting.windowsize.X-20 ), 20)
        , new Vector2(0, 1), 2));
        for (int i = 0; i < enemy_list.Count; i++)
        {
            enemy_list[i].Update(dt);
        }
    
    }
    public bool Is_ListActive(){
        if (enemy_list.Count>0)return true;
        else return false;
    }
    public void Draw()
    {
        enemy_list.ForEach(e => e.Draw());
    }
}