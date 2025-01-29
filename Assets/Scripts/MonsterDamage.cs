using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public Health health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health.TakeDamage(damage); 
        }
    }

}
