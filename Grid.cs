namespace Grid;

using System.Numerics;
using Enemy;
using EnemySystem;
using Raylib_cs;
public class Grid
{
    List<Enemy>[,] grid;
    public int Grid_scale { get; private set; }
    public bool is_GridDrawn = false;
    public int maxCellX { get; private set; }
    private int maxCellY;
    private Vector2 windowsize;

    /// <summary>Creates Grid and checks if size is multiple of scale.</summary>
    public void Initialize(int x, int y, int _scale)
    {
        if (x % _scale != 0 || y % _scale != 0)
            throw new ArgumentException("Size must be multiple of scale");
        windowsize = new Vector2(x, y);

        Grid_scale = _scale;
        int cellx = x / Grid_scale;
        int celly = y / Grid_scale;

        // window size doesnt change. I can get away with this 
        maxCellX = cellx;
        maxCellY = celly;

        grid = new List<Enemy>[maxCellX, maxCellY];
        for (int i = 0; i < maxCellX; i++)
            for (int j = 0; j < maxCellY; j++)
                grid[i, j] = new List<Enemy>();
    }
    public void Update(EnemySystem ESystem)
    {
        if (ESystem.Is_ListActive())
        {
            Reset_Grid();
            for (int i = 0; i < ESystem.enemy_list.Count; i++)
            {
                if (ESystem.enemy_list[i].Is_Active)
                    Set_EnemytoCell(ESystem.enemy_list[i]);
            }
        }

    }
    public void Reset_Grid()
    {
        for (int i = 0; i < maxCellX; i++)
            for (int j = 0; j < maxCellY; j++)
                grid[i, j].Clear();
    }

    /// <summary> Returns size of the window as an array.</summary>
    public int[] Get_WindowSize()
    {
        return [(int)windowsize.X, (int)windowsize.Y];
    }

    /// <summary> Updates grid array with given Enemy.</summary>
    public List<Enemy> Get_Cell(float posx, float posy)
    {
        int cellx = (int)posx / Grid_scale;
        int celly = (int)posy / Grid_scale;

        if (cellx >= 0 && cellx < maxCellX &&
            celly >= 0 && celly < maxCellY)
        {
            return grid[cellx, celly];
        }

        return new List<Enemy>();
    }


    public List<Enemy> Get_EnemiesInRadius(float posx, float posy)
    {
        List<Enemy> enemies = new List<Enemy>();
        int cellx = (int)posx / Grid_scale;
        int celly = (int)posy / Grid_scale;

        // Check 3x3 cells around bullet position
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int checkX = cellx + dx;
                int checkY = celly + dy;

                if (checkX >= 0 && checkX < maxCellX &&
                    checkY >= 0 && checkY < maxCellY)
                {
                    enemies.AddRange(grid[checkX, checkY]);
                }
            }
        }
        return enemies;
    }

    /// <summary> Updates grid array with given Enemy.</summary>
    public void Set_EnemytoCell(Enemy enemy)
    {
        int cellx = (int)enemy.position.X / Grid_scale;
        int celly = (int)enemy.position.Y / Grid_scale;

        Limiter(cellx, celly);
        if (enemy != null && enemy.Is_Active)
            grid[cellx, celly].Add(enemy);
    }

    public void Limiter(int cellx, int celly)
    { // Enemies cant get out of screen. This throws error because of it.
        if (cellx >= maxCellX || celly >= maxCellY) throw new ArgumentException("OutSide of Grid");
    }

    public void DrawGrid()
    {
        if (is_GridDrawn)
        {
            int windowx = Get_WindowSize()[0];
            int windowy = Get_WindowSize()[1];

            // Vertical lines
            for (int x = 0; x <= windowx; x += Grid_scale)
            {
                Raylib.DrawLine(x, 0, x, windowy, Color.White);
            }

            // Horizontal lines
            for (int y = 0; y <= windowy; y += Grid_scale)
            {
                Raylib.DrawLine(0, y, windowx, y, Color.Gold);
            }
        }
    }

}