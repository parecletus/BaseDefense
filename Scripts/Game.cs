namespace Game;

using Logic;
using FloatingTextSystem;
using BulletSystem;
using EnemySystem;
using Grid;
using Player;
using CollectSystem;
using windowsetting;
using Timer;
using Gun;
using Input;
using PowerUp;
public class Game
{
    public Player player;

    private Logic Logic = new();
    private BulletSystem BulletSystem = new();
    private EnemySystem EnemySystem = new();
    private CollectSystem CollectSystem = new();
    private windowsetting Window = new();
    private readonly FloatingTextSystem FloatingText = new();
    private Grid grid = new Grid();
    public Gun gun = new();
    private PowerUp PowerUp = new();
    private Timer update = new Timer(0.1f);
    public Game()
    {
        Window.Initialize(300, 600);
        grid.Initialize(300, 600, 30);
        player = new Player(30, 570);
        PowerUp.Start(gun.baseStarterGun);
    }

    public void Update(float dt, Input State)
    {
        if (!Window.FreezeState) // game running
        {
            player.Update(dt, State);
            Logic.CollisionCheck(FloatingText, BulletSystem, CollectSystem, grid); 

            EnemySystem.Update(dt);
            BulletSystem.Update(dt, player.position.X, player.position.Y, Logic.ClosestEnemy, gun.baseStarterGun);
            CollectSystem.Update(dt, Window);

            grid.Update(EnemySystem);
            if (update.Update(dt)) Logic.FindClosestEnemy(player.position.X, player.position.Y, player.radius, grid);
            FloatingText.Update(dt);
        }
        else // level up screen
        {
            PowerUp.Update(State,Window);
        }
        if (State.Up) grid.is_GridDrawn = !grid.is_GridDrawn;
    }

    public void Draw()
    {
        if (!Window.FreezeState)
        {
            grid.DrawGrid();
            player.Draw();
            CollectSystem.Draw();
            BulletSystem.Draw();
            EnemySystem.Draw();
            Window.Draw_Base();
            Window.Draw_ExpBar();
            Window.DrawEscape();
            FloatingText.Draw();
        }
        else
        {
            BulletSystem.Draw();
            EnemySystem.Draw();
            PowerUp.Draw();
            Window.DrawEscape();
        }
    }
}