namespace FloatingText; 
using System.Numerics;
using Raylib_cs;

public class FloatingText

{
    public string text;
    public Vector2 position;
    public float timercon;
    public int fontsize;
    public bool IsActive;
    public FloatingText(float Positionx, float Positiony, string Damage, float timer, int _fontsize)
    {
        position = new Vector2(Positionx, Positiony);
        text = Damage;
        timercon = timer;
        IsActive = true;
        fontsize = _fontsize;
    }
    public void Update(float dt)
    {
        timercon -= dt;
        if (timercon <= 0)
        {
            IsActive = false;
        }
    }
    public void Draw()
    {
        if (IsActive) Raylib.DrawText(text, (int)position.X, (int)position.Y, fontsize, Color.Red);
    }
}