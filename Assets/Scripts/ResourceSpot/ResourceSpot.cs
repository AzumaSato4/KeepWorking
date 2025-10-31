using UnityEngine;

public abstract class ResourceSpot : MonoBehaviour, IProduct, IDamageable
{
    SpotStatus spotStatus;
    protected string _productName;
    protected Resource.ResourceType _spotType;
    protected float _maxHealth;
    protected float _health;
    protected float _defense;
    protected float _timer = 0; //攻撃されていない時間を計測
    protected float _recoverTime; //回復開始までの時間
    protected float _recoverPower; //回復量
    public float Health => _health;
    public float Defense => _defense;
    public Resource.ResourceType SpotType => _spotType;
    public string ProductName => _productName;

    public void Initialize(int id)
    {
        spotStatus = CSVDataBase.spotStatus[id];
        _productName = spotStatus.ProductName;
        _spotType = spotStatus.SpotType;
        gameObject.name = _productName;
        _maxHealth = spotStatus.MaxHealth;
        _health = _maxHealth;
        _defense = spotStatus.Defense;
        _recoverTime = spotStatus.RecoverTime;
        _recoverPower = spotStatus.RecoverPower;
    }
    
    private void Update()
    {
        if (_health <= 0)
        {
            Dead();
            return;
        }

        _timer += Time.deltaTime;
        if (_health >= _maxHealth)
        {
            _timer = 0;
        }
        else if (_timer >= _recoverTime)
        {
            RestoreHealth();
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    public void RestoreHealth()
    {
        _health += _recoverPower * Time.deltaTime;
        if (_health >= _maxHealth) _health = _maxHealth;
        Debug.Log(_health);
    }

    public void TakeDamage(IAttackable attack)
    {
        _timer = 0;

        float damege = (attack.Strength * attack.Dexterity / 10) - _defense;
        if (damege <= 0)
        {
            damege = 0;
        }
        _health -= damege;
        Debug.Log(damege);
    }
}
