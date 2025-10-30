using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Status/Player")]
public class PlayerStatus : ScriptableObject
{
    [Header("大きさ")]
    [SerializeField] float defSize = 6;
    public float DefSize => defSize;
    [Header("移動スピード")]
    [SerializeField] float moveSpeed = 3;
    public float MoveSpeed => moveSpeed;
    [Header("攻撃力")]
    [SerializeField] float strength = 10;
    public float Strength => strength;
    [Header("攻撃クールタイム")]
    [SerializeField] float coolTime = 1;
    public float CoolTime => coolTime;
    [Header("器用さ")]
    [SerializeField] float dexterity = 10;
    public float Dexterity => dexterity;
}
