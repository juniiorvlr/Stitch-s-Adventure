using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int lifetime = 2; // Lebensdauer der Kugel
    public int damage = 10; // Schaden, den die Kugel verursacht
    public Health health; 

    void Start()
    {
        Destroy(gameObject, lifetime); // Zerstört das Projektil nach einer bestimmten Zeit
    }

    // Optionale Funktion: Schaden auf Kollisionsobjekte anwenden
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (health != null)
        {
            // Schaden auf das kollidierte Objekt anwenden
            health.TakeDamage(damage);
        }
        if (collision.CompareTag("Max"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision);
            return;
        }

        // Zerstört die Kugel nach der Kollision
        Destroy(gameObject);
    }
}
