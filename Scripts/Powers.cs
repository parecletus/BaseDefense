namespace Powers;


public struct Powers
{

    public string Name;
    public delegate void Do();
    public readonly Do tick;

    public Powers(string _name, Do action)
    {
        Name = _name;
        tick = action;
    }
    public Do GetDo(){
    return tick ;
    }
}