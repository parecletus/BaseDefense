namespace GunTypes;

using Gun;
using System.Numerics;
using Bullet;
public static class Guntypes
{
    public static Gun basegun = new(1, 20, 300,6,0,6); 
    public static Gun shotgun = new(1, 20, 200); 
    public static Gun sniper  = new(1, 20, 200); 
}