using UnityEngine;
using UnityEngine.UI;

public abstract class ResourceSpot : MonoBehaviour, IProduct, IDamageable, IRestoreHealth
{
    bool isDead;

    [SerializeField] Animator _animator;
    [SerializeField] GameObject _healthSlider;
    Slider _slider;

    SpotStatus _spotStatus;
    string _productName;
    Resource.ResourceType _spotType;
    float _maxHealth;
    float _health;
    float _defense;
    float _timer = 0; //攻撃されていない時間を計測
    float _recoverTime; //回復開始までの時間
    float _recoverPower; //回復量
    public string ProductName => _productName;
    public Resource.ResourceType SpotType => _spotType;
    public float Health => _health;
    public float Defense => _defense;

    public void Initialize(int id)
    {
        _animator.enabled = false;
        _slider = _healthSlider.GetComponent<Slider>();
        _healthSlider.SetActive(false);

        _spotStatus = CSVDataBase.spotStatus[id];
        _productName = _spotStatus.ProductName;
        _spotType = _spotStatus.SpotType;
        gameObject.name = _productName;
        _maxHealth = _spotStatus.MaxHealth;
        _health = _maxHealth;
        _defense = _spotStatus.Defense;
        _recoverTime = _spotStatus.RecoverTime;
        _recoverPower = _spotStatus.RecoverPower;
    }

    private void Update()
    {
        if (isDead) return;

        _slider.maxValue = _maxHealth;
        _slider.value = _health;

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
        else
        {
            _healthSlider.SetActive(true);
        }

        if (_timer >= _recoverTime)
        {
            RestoreHealth();
        }
    }

    public void Dead()
    {
        isDead = true;
        _animator.enabled = true;
        _healthSlider.SetActive(false);
        Destroy(gameObject, 1);
    }

    public void RestoreHealth()
    {
        _health += _recoverPower * Time.deltaTime;
        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
            _healthSlider.SetActive(false);
        }
        Debug.Log(_health);
    }

    public void TakeDamage(IAttackable attack)
    {
        if (isDead) return;

        _timer = 0;
        _health -= Damage.GetDamage(attack, this);
    }
}
