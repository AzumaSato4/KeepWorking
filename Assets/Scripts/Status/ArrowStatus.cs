public class ArrowStatus
{
    public string ProductName { get; } //名前
    public float ShotSpeed { get; } = 10; //ショットの強さ
    public float Penetration { get; } = 100; //貫通力
    public float Strength { get; } = 10; //攻撃力
    public float Dexterity { get; } = 10; //器用さ

    public ArrowStatus(string productName, float shotspeed, float penetration, float strength, float decterity)
    {
        ProductName = productName;
        ShotSpeed = shotspeed;
        Penetration = penetration;
        Strength = strength;
        Dexterity = decterity;
    }
}
