using UnityEngine;

public class EnemyAttackSensor : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    float _timer;
    IDamageable target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _timer = enemy.CoolTime;
        target = collision.GetComponent<IDamageable>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (target == null) return;

        if (_timer >= enemy.CoolTime)
        {
            enemy.Attack(target);
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy.ChangeState(Enemy.EnemyState.move);
    }
}
