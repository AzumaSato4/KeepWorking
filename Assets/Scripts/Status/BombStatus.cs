public class BombStatus
{
    public string ProductName { get; } //名前
    public Bomb.BombType BombType { get; } //タイプ
    public float Strength { get; } = 10; //攻撃力
    public float Renge { get; } = 2; //攻撃範囲

    public BombStatus(string productName, Bomb.BombType bombType, float strength, float renge)
    {
        ProductName = productName;
        BombType = bombType;
        Strength = strength;
        Renge = renge;
    }
}
