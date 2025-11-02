using UnityEngine;

public class Goblin : Enemy
{
    public override void Move()
    {
        Rbody.linearVelocityX = Rotation.x * MoveSpeed;
    }

    public override void Attack(IDamageable target)
    {
        target.TakeDamage(this);
        ChangeState(EnemyState.attack);
    }
}
