namespace windowsetting;

using Raylib_cs;
using System.Numerics;
public class windowsetting
{
    public static Vector2 windowsize = new(0, 0);
    private float ExpCount;
    public bool FreezeState;
    public static void SetWindowsize(float x, float y)
    {
        windowsize = new Vector2(x, y);
    }
    public void Initialize(int x, int y)
    {
        windowsize = new Vector2(x, y);
    }
    public void UpdateExpBar(int Exp)
    {
        if (ExpCount >= windowsize.X)
        {
            FreezeState = true;
            return;
        }
        ExpCount += Exp / 10;
    }
    public void Reset_Exp()
    {
        ExpCount = 0;
    }
    public void Draw_ExpBar()
    {
        Raylib.DrawRectangle(0, 0, (int)ExpCount, 20, Color.Gray);
    }
    public void Draw_Base()
    {
        Raylib.DrawRectangle(0, (int)windowsize.Y-20, (int) windowsize.X,20, Color.Green);
    }
    public void DrawEscape(){
        const int area = 30 ;
        Vector2 position = new Vector2 ((int)windowsize.X-area-10  , area);
        Raylib.DrawRectangle((int)position.X,(int) position.Y,area,area, Color.Gray);
        Raylib.DrawText("Q to Menu",(int)position.X +area/10,(int)position.Y +area/4,10,Color.White);

    }
}