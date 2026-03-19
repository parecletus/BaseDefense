namespace PowerUp;

using Blocks;
using Input;
using windowsetting;
using Raylib_cs;
using Powers;
using GunEntity;
public class PowerUp
{
    public List<Blocks> blocklist = new();

    int OffSet = 30;
    int numberOffBlocks = 3;
    int currentHighlightedBlockIndex = 0;
    int MenuTopOffset = 200;
    GunEntity gun;
    public Random rng = new();
    public List<Powers> powerlist = new();

    public void Start(GunEntity _gun)
    {
        gun = _gun;
        powerlist.Add(new Powers("Fire rate -%30", UpdateGun1));
        powerlist.Add(new Powers("Bullet damage +%30", UpdateGun2));
        powerlist.Add(new Powers("Bullet Speed +%30", UpdateGun3));
        powerlist.Add(new Powers("Bullet Count +1", UpdateGun4));

        int blockWidth = (int)windowsetting.windowsize.X - 2 * OffSet;
        int blockHeight = ((int)windowsetting.windowsize.Y - (2 * OffSet) - MenuTopOffset) / numberOffBlocks;

        for (int x = 0; x < numberOffBlocks; x++)
        {
            int posX = OffSet;
            int posY = MenuTopOffset + OffSet + x * blockHeight + 5 * x;
            int yo = rng.Next(0, powerlist.Count);
            blocklist.Add(new Blocks(posX, posY, blockWidth, blockHeight, powerlist[yo].GetDo(), powerlist[yo].Name));
        }
    }
    public void UpdateGun1() => gun.GunUpgrade(percentfirerate: 0.7f);
    public void UpdateGun2() => gun.GunUpgrade(percentBulletDmg: 1.3f);
    public void UpdateGun3() => gun.GunUpgrade(percentBulletSpeed: 1.3f);
    public void UpdateGun4() => gun.GunUpgrade(_bulletcount: 1);

    public void Update(Input State, windowsetting windowsetting)
    {
        if (State.Down)
        {
            ChangeHighlighted(1);
        }
        if (State.Up)
        {
            ChangeHighlighted(-1);
            Console.WriteLine("changed");
        }
        if (State.Enter) // PowerSelected
        {
            blocklist[currentHighlightedBlockIndex].tick();
            windowsetting.Reset_Exp();
            windowsetting.FreezeState = !windowsetting.FreezeState;
            Console.WriteLine("Selected");
        }
        for (int x = 0; x < numberOffBlocks; x++)
        {
            if (x == currentHighlightedBlockIndex)
            {
                blocklist[x].Highlight(true);
                continue;
            }
            blocklist[x].Highlight(false);
        }

    }
    public void ChangeHighlighted(int x)
    {
        currentHighlightedBlockIndex = (currentHighlightedBlockIndex + x + numberOffBlocks) % numberOffBlocks;
    }
    public void Draw()
    {
        foreach (var i in blocklist)
        {
            i.Draw();

        }
        Raylib.DrawText("Level Up Screen", 20, 20, 20, Color.Red);
    }
}