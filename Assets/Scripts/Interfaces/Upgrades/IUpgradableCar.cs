namespace MobileGame.Interfaces.Upgrades
{
    public interface IUpgradableCar
    {
        float Speed { get; set; }
        void Restore();
    }
}