public class BombStatus
{
    public string ProductName { get; } //名前
    public Bomb.BombType BombType { get; } //タイプ
    public float Strength { get; } = 10; //攻撃力
    public float Dexterity { get; } = 10; //器用さ
    public float Renge { get; } = 2; //攻撃範囲

    public BombStatus(string productName, Bomb.BombType bombType, float strength, float decterity, float renge)
    {
        ProductName = productName;
        BombType = bombType;
        Strength = strength;
        Dexterity = decterity;
        Renge = renge;
    }
}
