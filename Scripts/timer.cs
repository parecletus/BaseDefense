namespace Timer;
public class Timer
{
    private delegate bool Delegate_Update(float dt);
    private readonly Delegate_Update tick;
 
    private float trashhold; // for fun i know it is threshold
    private bool is_Active;
    private float t;

    public Timer(float trashhold = 1, bool repeat = true)
    {
        this.trashhold = trashhold;
        this.is_Active = true;
        tick = repeat ? Repeated_update : Nonrepeated_update;
    }
    
    public bool Update(float dt) => tick(dt);
 
    private bool Repeated_update(float dt)
    {
        t += dt;
        if (t> trashhold)
        {
            t = 0;
            return true;
        }
        return false;
    }

    private bool Nonrepeated_update(float dt)
    {
        if (!is_Active) return false;

        t += dt;
        if (t > trashhold)
        {
            is_Active = false;
            return true;
        }
        return false;
    }
}