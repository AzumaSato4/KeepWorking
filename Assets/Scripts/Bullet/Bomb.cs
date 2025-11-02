using NUnit.Framework.Constraints;
using UnityEngine;

public class Bomb : MonoBehaviour, IProduct, IAttackable, IExplodable
{
    public enum BombType
    {
        wood,
        stone,
        gold
    }

    [SerializeField] GameObject _efect;
    [SerializeField] Rigidbody2D _rbody;
    [SerializeField] float _defScale;

    BombStatus _bombStatus;
    string _productName;
    BombType _type;
    float _strength;
    float _dexterity;
    float _renge;
    float _fuseDelay = 0.5f;

    public string ProductName => _productName;
    public BombType Type => _type;
    public float Strength => _strength;
    public float Dexterity => _dexterity;
    public float Renge => _renge;
    public float FuseDelay => _fuseDelay;

    public void Initialize(int id)
    {
        _bombStatus = CSVDataBase.bombStatus[id];

        _productName = _bombStatus.ProductName;
        _type = _bombStatus.BombType;
        _strength = _bombStatus.Strength;
        _dexterity = _bombStatus.Dexterity;
        _renge = _bombStatus.Renge;

        transform.localScale *= _defScale;
        _efect.transform.localScale = Vector2.one * _renge;
        Invoke("Explode", 1);
    }

    public void Attack(IDamageable target)
    {
        target.TakeDamage(this);
    }

    public void Explode()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        _efect.SetActive(true);
        Destroy(gameObject, _fuseDelay);
    }
}
