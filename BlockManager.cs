namespace BlockManager;

using Blocks;
using Input;
using windowsetting;
public class BlockManager
{
    List<Blocks> block_list = new();
    int OffSet = 30;
    int numberOffBlocks = 3;
    int currentHighlightedBlockIndex = 0;
    int MenuTopOffset=200;
    
    public void Start()
    {
        int blockWidth = (int)windowsetting.windowsize.X-2 *OffSet;
        int blockHeight = ((int)windowsetting.windowsize.Y - 2 * OffSet - MenuTopOffset) / numberOffBlocks;
        for (int x = 0; x < numberOffBlocks; x++)
        {
            int posX = OffSet;
            int posY = OffSet + x * blockHeight+5*x;
            block_list.Add(new Blocks(posX,MenuTopOffset+ posY, blockWidth, blockHeight));
        }
    }
    public void Update(Input State)
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
        for (int x = 0; x < numberOffBlocks; x++)
        {
            if (x == currentHighlightedBlockIndex)
            {
                block_list[x].Highlight(true);
                continue;
            }
            block_list[x].Highlight(false);
        }

    }
    public void ChangeHighlighted(int x)
    {
        currentHighlightedBlockIndex = (currentHighlightedBlockIndex + x+numberOffBlocks) % numberOffBlocks;
    }
    public void Draw()
    {
        block_list.ForEach(b => b.Draw());

    }
}