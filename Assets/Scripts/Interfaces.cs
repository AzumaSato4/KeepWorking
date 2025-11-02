using UnityEngine;

public interface IMovable
{
    float MoveSpeed { get; }

    void Move();
}

public interface ITurnable
{
    void TurnLeft();
    void TurnRight();
}

public interface IAttackable
{
    float Strength { get; }
    float Dexterity { get; } //器用さ

    void Attack(IDamageable target);
}

public interface IDamageable
{
    float Health { get; }
    float Defense { get; }

    void TakeDamage(IAttackable attack);
    void Dead();
}

public interface IRestoreHealth
{
    void RestoreHealth();
}

public interface ICreatable
{
    void Create();
}

public interface IShotable
{
    float ShotSpeed { get; }
    float ShotRotation { get; }

    void Shot(GameObject bullet);
}

public interface IProduct
{
    string ProductName { get; }

    void Initialize(int id);
}

public interface IPenetratable
{
    float Penetration { get; }

    void Penetrate(IDamageable target);
}
