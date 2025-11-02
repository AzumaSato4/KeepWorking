using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] Bomb bomb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            bomb.Attack(enemy);
        }
    }
}
