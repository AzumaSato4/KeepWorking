using UnityEngine;

[CreateAssetMenu(fileName = "SpotStatus", menuName = "Status/Spot")]
public class SpotStatus : ScriptableObject
{
    [Header("耐久値")]
    [SerializeField] float maxHealth = 10;
    public float MaxHealth => maxHealth;
    [Header("硬さ")]
    [SerializeField] float defense = 10;
    public float Defense => defense;
    [Header("回復までの時間")]
    [SerializeField] float recoverTime = 10;
    public float RecoverTime => recoverTime;
    [Header("回復量")]
    [SerializeField] float recoverPower = 10;
    public float RecoverPower => recoverPower;
    [Header("オブジェクト名")]
    [SerializeField] string productionName;
    public string ProductionName => productionName;
    [Header("タイプ")]
    [SerializeField] Resource.ResourceType spotType;
    public Resource.ResourceType SpotType => spotType;
}
