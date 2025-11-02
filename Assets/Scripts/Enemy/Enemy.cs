using UnityEngine;

public abstract class Enemy : MonoBehaviour, IProduct, ITurnable, IMovable, IAttackable, IDamageable
{
    public enum EnemyType
    {
        goblin,
        skelton
    }

    public enum EnemyState
    {
        move,
        attack,
        dead
    }

    protected EnemyState _currentState = EnemyState.move;
    public EnemyState CurrentState => _currentState;

    [SerializeField] Rigidbody2D _rbody;
    [SerializeField] Animator _animator;
    [SerializeField] CircleCollider2D _attackRenge;
    [SerializeField] float _defSize = 5;
    Vector2 _rotation;
    public Rigidbody2D Rbody
    {
        get { return _rbody; }
        set { _rbody = value; }
    }
    public Animator Animator => _animator;
    public float DefSize => _defSize;
    public Vector2 Rotation => _rotation;

    EnemyStatus _enemyStatus;
    string _productName;
    EnemyType _type;
    float _moveSpeed;
    float _maxHealth;
    protected float _health;
    float _defense;
    float _strength;
    float _dexterity;
    float _coolTime;

    public string ProductName => _productName;
    public EnemyType Type => _type;
    public float MoveSpeed => _moveSpeed;
    public float Health => _health;
    public float Defense => _defense;
    public float Strength => _strength;
    public float Dexterity => _dexterity;
    public float CoolTime => _coolTime;

    public void Initialize(int id)
    {
        _enemyStatus = CSVDataBase.enemyStatus[id];

        _productName = _enemyStatus.ProductName;
        _type = _enemyStatus.EnemyType;
        _moveSpeed = _enemyStatus.MoveSpeed;
        _maxHealth = _enemyStatus.MaxHealth;
        _health = _maxHealth;
        _defense = _enemyStatus.Defense;
        _strength = _enemyStatus.Strength;
        _dexterity = _enemyStatus.Dexterity;
        _coolTime = _enemyStatus.CoolTime;

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
        if (CurrentState == EnemyState.dead) return;

        if (_health <= 0)
        {
            _health = 0;
            Dead();
            return;
        }

        if (CurrentState != EnemyState.attack)
        {
            Move();
        }
    }

    public void ChangeState(EnemyState nextState)
    {
        if (_currentState == nextState) return;
        PlayAnimation(nextState);
        _currentState = nextState;
    }

    void PlayAnimation(EnemyState nextState)
    {
        switch (nextState)
        {
            case EnemyState.move:
                _animator.SetTrigger("Move");
                break;
            case EnemyState.attack:
                _animator.SetTrigger("Attack");
                break;
            case EnemyState.dead:
                _animator.SetTrigger("Dead");
                break;
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

    public abstract void Move();

    public abstract void Attack(IDamageable target);

    public void TakeDamage(IAttackable attack)
    {
        if (CurrentState == EnemyState.dead) return;

        _rbody.linearVelocityX = 0;
        _health -= Damage.GetDamage(attack, this);
        Debug.Log($"{_productName},残りHP{_health}");
    }

    public void Dead()
    {
        ChangeState(EnemyState.dead);
        Destroy(gameObject, 1);
    }

}
