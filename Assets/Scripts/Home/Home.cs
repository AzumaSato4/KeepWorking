using UnityEngine;

public class Home : MonoBehaviour, IDamageable
{
    float _maxHealth = 100;
    float _health;
    float _defense = 0;

    public float Health => _health;
    public float Defense => _defense;

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            _health = 0;
            Dead();
            return;
        }
    }

    public void Dead()
    {
        Debug.Log("ゲームオーバー");
    }

    public void TakeDamage(IAttackable attack)
    {
        if (_health <= 0) return;
        _health -= Damage.GetDamage(attack, this);
    }
}
