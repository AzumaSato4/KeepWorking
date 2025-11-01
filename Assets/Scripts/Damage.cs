using UnityEngine;

public class Damage
{
    public static float GetDamage(IAttackable attack, IDamageable target)
    {
        float damage = 0;

        damage = (attack.Strength * attack.Dexterity / 10) - target.Defense;
        if (damage <= 0)
        {
            damage = 0;
        }
        //Debug.Log(damage);

        return damage;
    }
}
