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
    public float Dexterity => _dexterity;

    private void Start()
    {
        _strength = CSVDataBase.playerStatus.Strength;
        _coolTime = CSVDataBase.playerStatus.CoolTime;
        _dexterity = CSVDataBase.playerStatus.Dexterity;
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
        target.TakeDamage(this);
        StartCoroutine(StartCoolTime());
    }

    IEnumerator StartCoolTime()
    {
        yield return new WaitForSeconds(_coolTime);
        _isCoolTime=false;
    }
}
