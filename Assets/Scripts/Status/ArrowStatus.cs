public class ArrowStatus
{
    public string ProductName { get; } //名前
    public float ShotSpeed { get; } = 10; //ショットの強さ
    public float Penetration { get; } = 100; //貫通力
    public float Strength { get; } = 10; //攻撃力

    public ArrowStatus(string productName, float shotspeed, float strength, float penetration)
    {
        ProductName = productName;
        ShotSpeed = shotspeed;
        Strength = strength;
        Penetration = penetration;
    }
}
