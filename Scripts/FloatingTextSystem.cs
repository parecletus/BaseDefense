namespace FloatingTextSystem;

using FloatingText;
public class FloatingTextSystem
{
    List<FloatingText> textlist = new();
    public void Update(float dt)
    {
        if (textlist.Count > 0)
        {
            for (int i = 0; i < textlist.Count; i++)
            {
                textlist[i].Update(dt);
            }
        }
    }
    public void Draw()
    {
        if (textlist.Count > 0)
        {
            for (int i = 0; i < textlist.Count; i++)
            {
                textlist[i].Draw();
            }
        }
    }
    public void CreateText(float posx, float posy, string dmg = "Hit", float timer = 0.2f, int fontsize = 10)
    {
        FloatingText text = new(posx, posy, dmg, timer, fontsize);
        textlist.Add(text);
    }
}
