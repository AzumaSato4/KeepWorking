public class EnemyStatus
{
    public string ProductName { get; } //名前
    public Enemy.EnemyType EnemyType { get; } //タイプ
    public float MoveSpeed { get; } = 3; //移動スピード
    public float MaxHealth { get; } = 100; //最大体力
    public float Defense { get; } = 5; //防御力
    public float Strength { get; } = 10; //攻撃力
    public float CoolTime { get; } = 1; //攻撃クールタイム
    public float Dexterity { get; } = 10; //器用さ

    public EnemyStatus(string productName, Enemy.EnemyType enemyType, float moveSpeed, float maxHealth, float defense, float strength, float coolTime, float decterity)
    {
        ProductName = productName;
        EnemyType = enemyType;
        MoveSpeed = moveSpeed;
        MaxHealth = maxHealth;
        Defense = defense;
        Strength = strength;
        CoolTime = coolTime;
        Dexterity = decterity;
    }
}
