using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f; // Lebensdauer der Kugel
    public float damage = 10f; // Schaden, den die Kugel verursacht

    void Start()
    {
        Destroy(gameObject, lifetime); // Zerstört das Projektil nach einer bestimmten Zeit
    }

    // Optionale Funktion: Schaden auf Kollisionsobjekte anwenden
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Überprüfen, ob das kollidierte Objekt ein Health-Skript hat
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            // Schaden auf das kollidierte Objekt anwenden
            enemyHealth.TakeDamage(damage);
        }

        // Zerstört die Kugel nach der Kollision
        Destroy(gameObject);
    }
}
