using UnityEngine;

public class Arrow : MonoBehaviour, IProduct, IAttackable, IPenetratable
{
    [SerializeField] Rigidbody2D _rbody;
    [SerializeField] float _defScale;
    float _scaleX = 1;

    ArrowStatus _arrowStatus;
    string _productName;
    float _shotSpeed;
    float _penetration;
    float _strength;
    float _dexterity;

    public string ProductName => _productName;
    public float ShotSpeed => _shotSpeed;
    public float Penetration => _penetration;
    public float Strength => _strength;
    public float Dexterity => _dexterity;

    public void Initialize(int id)
    {
        _arrowStatus = CSVDataBase.arrowStatus;

        _productName = _arrowStatus.ProductName;
        _shotSpeed = _arrowStatus.ShotSpeed;
        _penetration = _arrowStatus.Penetration;
        _strength = _arrowStatus.Strength;
        _dexterity = _arrowStatus.Dexterity;

        _scaleX = transform.localScale.x;
        transform.localScale *= _defScale;
        _rbody.AddForce(new Vector2(_scaleX * _shotSpeed, _rbody.gravityScale), ForceMode2D.Impulse);
    }

    public void Penetrate(IDamageable target)
    {
        _penetration -= target.Defense;
        if (_penetration <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Attack(IDamageable target)
    {
        target.TakeDamage(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamageable target = collision.GetComponent<IDamageable>();
            Attack(target);
            Penetrate(target);
        }

        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
