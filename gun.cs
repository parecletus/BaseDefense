namespace Gun;
using GunEntity;
public class Gun{
    public List<GunEntity> GunTypes; 
    public GunEntity baseStarterGun = new(0.1f , 20,200,_bullet_positionoffset :4); 
    public GunEntity baseShotgun = new(1, 20, 400); 
    public GunEntity baseSniper  = new(1, 20, 800);
    public void Start(){
        // GunTypes.Add(baseStarterGun,baseShotgun,baseSniper);
    }
    public void CreateGun(){


    }
}
