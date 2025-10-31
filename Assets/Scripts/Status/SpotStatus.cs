public class SpotStatus
{
    public string ProductName { get; } //名前
    public Resource.ResourceType SpotType { get; } //タイプ
    public float MaxHealth { get; } = 10; //耐久値
    public float Defense { get; } = 10; //硬さ
    public float RecoverTime { get; } = 10; //回復までの時間
    public float RecoverPower { get; } = 10; //回復量

    public SpotStatus(string productName, Resource.ResourceType spotType, float maxHealth, float defense, float recoverTime, float recoverPower)
    {
        ProductName = productName;
        SpotType = spotType;
        MaxHealth = maxHealth;
        Defense = defense;
        RecoverTime = recoverTime;
        RecoverPower = recoverPower;
    }
}
