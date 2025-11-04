public class Bat : Enemy
{
    public override void Move()
    {
        Rbody.linearVelocityX = Rotation.x * MoveSpeed;
    }

    public override void Attack(IDamageable target)
    {
        if (CurrentState == EnemyState.dead) return;
        target.TakeDamage(this);
        ChangeState(EnemyState.attack);
    }
}
