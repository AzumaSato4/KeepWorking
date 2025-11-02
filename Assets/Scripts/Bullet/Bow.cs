using UnityEngine;

public class Bow : Bullet
{
    public override void Attack(IDamageable target)
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
