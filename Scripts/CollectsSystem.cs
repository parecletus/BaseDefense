namespace CollectSystem;

using ExpCube;
using System.Numerics;
using windowsetting;
public class CollectSystem
{
    List<ExpCube> cubelist = new();
    public int ExpCount = 100;
    public float sinceGameStarted = 0;
    public void Spawn(int posx, int posy)
    {
        ExpCube cube = new(posx, posy);
        cubelist.Add(cube);
    }
    public void Spawn(Vector2 positison)
    {
        ExpCube cube = new((int)positison.X, (int)positison.Y);
        cubelist.Add(cube);
    }
    public void Update(float dt, windowsetting windowsetting)
    {
        sinceGameStarted += dt;
        if (cubelist.Count > 0)
        {
            for (int i = cubelist.Count - 1; i >= 0; i--)
            {
                var cube = cubelist[i];
                cube.MoveUp(dt);
                if (cube.position.Y <= 0 || !cube.is_Active)
                {
                    windowsetting.UpdateExpBar(ExpCount* 1/(sinceGameStarted));
                    cubelist.RemoveAt(i);
                }
            }
        }
    }
    public void Draw()
    {
        if (cubelist.Count > 0)
        {
            for (int i = 0; i < cubelist.Count; i++)
            {
                if (cubelist[i].is_Active)
                    cubelist[i].Draw();
            }
        }
    }
}
