using UnityEngine;

public class MaxSchiesst : MonoBehaviour
{
    public float speed = 3f;  // Geschwindigkeit des Gegners
    public Transform pointA;  // Startpunkt
    public Transform pointB;  // Endpunkt

    private Vector3 target;   // Zielpunkt

    void Start()
    {
        target = pointB.position; // Gegner startet in Richtung Punkt B
    }

    void Update()
    {
        // Bewegung des Gegners
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Prüfen, ob der Gegner das Ziel erreicht hat
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            Flip(); // Gegner dreht sich
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }

        // Schießen
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Flip()
    {
        // Gegner umdrehen (X-Achse spiegeln)
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public GameObject bulletPrefab;  // Das Projektil
    public Transform firePoint;      // Der Abschusspunkt des Projektils
    public float bulletSpeed = 5f;   // Geschwindigkeit des Projektils
    public float fireRate = 2f;      // Schussrate

    private float nextFireTime = 0f;

    void Shoot()
    {
        
        // Erzeuge das Projektil
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Bestimme die Richtung (je nach Flip-Zustand des Bosses)
        float direction = transform.localScale.x > 0 ? -1f : 1f;

        // Setze die Geschwindigkeit des Projektils (mit Richtung)
        rb.linearVelocity = new Vector2(bulletSpeed * direction, 0f);

        // Skalierung des Projektils anpassen, basierend auf der Richtung des Bosses
        Vector3 bulletScale = bullet.transform.localScale;
        bulletScale.x = Mathf.Abs(bulletScale.x) * direction; // Skalierung auf der X-Achse anpassen, Y bleibt gleich
        bullet.transform.localScale = bulletScale; // Skalierung anwenden
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);  // Ignore collision with enemies
        }
    }
}
