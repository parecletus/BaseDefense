namespace Menu;

using Raylib_cs;
using windowsetting;
using Input;
using System.Numerics;
using Powers;

public class Menu
{
    Vector2 window => windowsetting.windowsize;
    public void Start(){
    }
    public void Update(Input State)
    {
        if (State.Enter) {}
    }
    public void Draw()
    {
        Raylib.DrawRectanglePro(new Rectangle(0, 0,window), Vector2.Zero, 0f, Color.Gray); // background
        Raylib.DrawText("MENU", 0, 10, 50,Color.Black ); // menu text
        Raylib.DrawText("Controls", 10 , 60, 30, Color.White);
        Raylib.DrawText("Q to Close Menu", 30 , 90, 20, Color.White);
        Raylib.DrawText("-> to move right", 30 , 110, 20, Color.White);
        Raylib.DrawText("<- to move left", 30 , 130, 20, Color.White);
        Raylib.DrawText("Enter to Select Powerup", 30 , 150, 20, Color.White);
        Raylib.DrawText("Up to Show Grid", 30 , 170, 20, Color.White);
 
        Raylib.DrawText("Made by ", 10 , 200, 20, Color.White);
        Raylib.DrawText("Hakan Ergün", 10 , 230, 30, Color.Black);
            
            }
}