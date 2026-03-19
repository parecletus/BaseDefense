namespace Menu;

using Raylib_cs;
using windowsetting;
using Input;
using System.Numerics;
using BlockManager;
public class Menu
{
    BlockManager blocks = new BlockManager();
    public void Start(){
        blocks.Start();
    }
    public void Update(Input State)
    {
        blocks.Update(State);
        if (State.Enter) {}
    }
    public void Draw()
    {
        Raylib.DrawRectanglePro(new Rectangle(0, 0, windowsetting.windowsize), Vector2.Zero, 0f, Color.Gray);
        Raylib.DrawText("MENU", (int)(windowsetting.windowsize.X - 20) / 2, 20, 20,Color.Black );
        blocks.Draw();
    }
}