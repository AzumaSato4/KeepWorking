using UnityEngine;

public class Home : MonoBehaviour, IDamageable
{
    [SerializeField] float _maxHealth = 1000;
    float _health;
    float _defense = 0;

    public float Health => _health;
    public float Defense => _defense;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void Dead()
    {
        Debug.Log("ゲームオーバー");
        Time.timeScale = 0;
    }

    public void TakeDamage(IAttackable attack)
    {
        _health -= Damage.GetDamage(attack, this);

        if (_health <= 0)
        {
            _health = 0;
            Dead();
        }
    }
}
