using UnityEngine;

public class Bow : Turret
{
    public override void Attack(IDamageable target)
    {
        target.TakeDamage(this);
    }
}
