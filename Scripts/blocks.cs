namespace Blocks;

using Raylib_cs;
using System.Numerics;
using Powers; 
public class Blocks
{


    public int width;
    public int height;
    public int posx;
    public int posy;
    public bool is_Highlighted;
    public int textsize;
    public Color color;
    public delegate Powers.Do Do();
    public readonly  Powers.Do tick;
    private void Empty() {} 
    public string name;
    public Blocks(int _posx, int _posy, int _width, int _height,Powers.Do act= null , string _name = "")
    {
        posx = _posx;
        posy = _posy;
        width = _width;
        height = _height;
        name = _name;
        tick = act ?? Empty;
    }

    public void Draw()
    {
        Raylib.DrawRectanglePro(new Rectangle(posx, posy, new Vector2(width, height)), Vector2.Zero, 0f, Color.DarkGray);
        Raylib.DrawRectangleLines(posx, posy, width, height, color);
        Raylib.DrawText(name, posx +width/2- textsize/2, posy +height/2 - textsize/2 ,textsize, Color.Gold );
    }

    public Color Highlight(bool yo)
    {
        is_Highlighted = yo;
        if (is_Highlighted) return color = Color.Gold;
        else return color = Color.Black;
    }


}