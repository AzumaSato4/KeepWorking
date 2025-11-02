using UnityEngine;

public abstract class Bullet : MonoBehaviour, IProduct, IAttackable, IPenetratable
{
    public enum BulletType
    {
        bow,
        skelton
    }

    [SerializeField] Rigidbody2D _rbody;
    float _scaleX = 1;

    BulletStatus _bulletStatus;
    string _productName;
    BulletType _type;
    float _shotSpeed;
    float _penetration;
    float _strength;
    float _dexterity;

    public string ProductName => _productName;
    public BulletType Type => _type;
    public float ShotSpeed => _shotSpeed;
    public float Penetration => _penetration;
    public float Strength => _strength;
    public float Dexterity => _dexterity;

    public void Initialize(int id)
    {
        _bulletStatus = CSVDataBase.turretStatus[id];

        _productName = _bulletStatus.ProductName;
        _type = _bulletStatus.BulletType;
        _shotSpeed = _bulletStatus.ShotSpeed;
        _penetration = _bulletStatus.Penetration;
        _strength = _bulletStatus.Strength;
        _dexterity = _bulletStatus.Dexterity;

        _scaleX = transform.localScale.x;
        _rbody.AddForce(new Vector2(_scaleX * _shotSpeed, 0.2f), ForceMode2D.Impulse);
    }

    public abstract void Attack(IDamageable target);

    public void Penetrate(IDamageable target)
    {
        _penetration -= target.Defense;
        if (_penetration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
