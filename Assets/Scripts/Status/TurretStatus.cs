public class TurretStatus
{
    public string ProductName { get; } //名前
    public Turret.TurretType TurretType { get; } //タイプ
    public float MaxHealth { get; } = 100; //最大体力
    public float Defense { get; } = 5; //防御力
    public float Strength { get; } = 10; //攻撃力
    public float CoolTime { get; } = 1; //攻撃クールタイム
    public float Dexterity { get; } = 10; //器用さ

    public TurretStatus(string productName, Turret.TurretType turretType, float maxHealth, float defense, float strength, float coolTime, float decterity)
    {
        ProductName = productName;
        TurretType = turretType;
        MaxHealth = maxHealth;
        Defense = defense;
        Strength = strength;
        CoolTime = coolTime;
        Dexterity = decterity;
    }
}
