public class PlayerStatus
{
    public float MoveSpeed { get; } = 3; //移動スピード
    public float Strength { get; } = 10; //攻撃力
    public float CoolTime { get; } = 1; //攻撃クールタイム
    public float Dexterity { get; } = 10; //器用さ
 
    public PlayerStatus(float moveSpeed, float strength, float coolTime, float decterity)
    {
        MoveSpeed = moveSpeed;
        Strength = strength;
        CoolTime = coolTime;
        Dexterity= decterity;
    }
}
