public class BulletStatus
{
    public string ProductName { get; } //名前
    public Bullet.BulletType BulletType { get; } //タイプ
    public float ShotSpeed { get; } = 10; //ショットの強さ
    public float Penetration { get; } = 100; //貫通力
    public float Strength { get; } = 10; //攻撃力
    public float Dexterity { get; } = 10; //器用さ

    public BulletStatus(string productName, Bullet.BulletType bulletType, float shotspeed, float penetration, float strength, float decterity)
    {
        ProductName = productName;
        BulletType = bulletType;
        ShotSpeed = shotspeed;
        Penetration = penetration;
        Strength = strength;
        Dexterity = decterity;
    }
}
