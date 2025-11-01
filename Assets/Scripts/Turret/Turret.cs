using UnityEngine;

public abstract class Turret : MonoBehaviour, IProduct, ITurnable, IAttackable, IDamageable
{
    public enum TurretType
    {
        bow,
        skelton
    }

    public enum TurretState
    {
        idle,
        dead
    }

    protected TurretState _currentState = TurretState.idle;
    public TurretState CurrentState => _currentState;

    [SerializeField] Rigidbody2D _rbody;
    [SerializeField] Animator _animator;
    [SerializeField] CircleCollider2D _attackRenge;
    [SerializeField] float _defSize = 5;
    Vector2 _rotation;
    public Rigidbody2D Rbody => _rbody;
    public Animator Animator => _animator;
    public float DefSize => _defSize;
    public Vector2 Rotation => _rotation;

    TurretStatus _turretStatus;
    string _productName;
    TurretType _type;
    float _maxHealth;
    protected float _health;
    float _defense;
    float _strength;
    float _dexterity;
    float _coolTime;
    float _timer;

    public string ProductName => _productName;
    public TurretType Type => _type;
    public float Health => _health;
    public float Defense => _defense;
    public float Strength => _strength;
    public float Dexterity => _dexterity;
    public float CoolTime => _coolTime;

    public void Initialize(int id)
    {
        _turretStatus = CSVDataBase.turretStatus[id];

        _productName = _turretStatus.ProductName;
        _type = _turretStatus.TurretType;
        _maxHealth = _turretStatus.MaxHealth;
        _health = _maxHealth;
        _defense = _turretStatus.Defense;
        _strength = _turretStatus.Strength;
        _dexterity = _turretStatus.Dexterity;
        _coolTime = _turretStatus.CoolTime;

        if (transform.position.x < 0)
        {
            TurnRight();
        }
        else
        {
            TurnLeft();
        }
    }

    private void Update()
    {
        if (CurrentState == TurretState.dead) return;

        if (_health <= 0)
        {
            _health = 0;
            Dead();
            return;
        }
    }

    public void TurnLeft()
    {
        _rotation = Vector2.left;
        transform.localScale = new Vector2(_rotation.x, 1) * _defSize;
    }

    public void TurnRight()
    {
        _rotation = Vector2.right;
        transform.localScale = new Vector2(_rotation.x, 1) * _defSize;
    }

    public void ChangeState(TurretState nextState)
    {
        if (_currentState == nextState) return;
        PlayAnimation(nextState);
        _currentState = nextState;
    }

    void PlayAnimation(TurretState nextState)
    {
        switch (nextState)
        {
            case TurretState.dead:
                _animator.SetTrigger("Dead");
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();
        if (target == null) return;

        if (_timer >= _coolTime)
        {
            _timer = 0;
            Attack(target);
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    public abstract void Attack(IDamageable target);

    public void Dead()
    {
        ChangeState(TurretState.dead);
        Destroy(gameObject, 1);
    }

    public void TakeDamage(IAttackable attack)
    {
        if (CurrentState == TurretState.dead) return;

        _health -= Damage.GetDamage(attack, this);
        Debug.Log(_health);
    }

}
