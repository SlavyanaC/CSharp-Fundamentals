public class Gun : Ammunition
{
    private const double GunWeight = 1.4;

    public Gun(string name)
        : base(name, GunWeight)
    {
    }
}
