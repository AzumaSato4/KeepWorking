using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackable
{
    [SerializeField] CircleCollider2D _attackCollider;
    [SerializeField] float _strength;
    [SerializeField] float _coolTime;
    [SerializeField] float _dexterity;
    [SerializeField] bool _isCoolTime;
    public float Strength => _strength;
    public float CoolTime => _coolTime;
    public float Dexterity => _dexterity;

    private void Start()
    {
        PlayerStatus status = GetComponentInParent<PlayerStatusHolder>().MainStatus;
        _strength = status.Strength;
        _coolTime = status.CoolTime;
        _dexterity = status.Dexterity;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isCoolTime) return;

        IDamageable target = collision.GetComponent<IDamageable>();
        if (target != null)
        {
            Attack(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isCoolTime = false;
    }

    public void Attack(IDamageable target)
    {
        _isCoolTime = true;
        Debug.Log("攻撃した！");
        target.TakeDamage(this);
        StartCoroutine(StartCoolTime());
    }

    IEnumerator StartCoolTime()
    {
        yield return new WaitForSeconds(_coolTime);
        _isCoolTime=false;
    }
}
