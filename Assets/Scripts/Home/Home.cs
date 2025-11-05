using UnityEngine;

public class Home : MonoBehaviour, IDamageable
{
    [SerializeField] AudioSource _AudioSource;
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
    }

    public void TakeDamage(IAttackable attack)
    {
        if (_health <= 0) return;
        if (!_AudioSource.isPlaying)
        {
            _AudioSource.Play();
        }
        _health -= Damage.GetDamage(attack, this);

        if (_health <= 0)
        {
            _health = 0;
            Dead();
        }
    }
}
