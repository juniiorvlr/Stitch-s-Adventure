using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet Prefab, das verschossen wird
    public Transform shootingPoint; // Der Punkt, an dem die Kugel abgefeuert wird
    public float shootingForce = 10f; // Die Geschwindigkeit der Kugel

    private bool isFacingRight = true; // Bestimmt, ob der Spieler nach rechts schaut

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }

        // Optional: Spielerumdrehen, um die Richtung zu �ndern (falls du das ben�tigst)
        if (Input.GetKeyDown(KeyCode.A))
        {
            Flip();
        }
    }

    void Shoot()
    {
        // Erstellen der Kugel und Zuweisung der Richtung basierend auf der Ausrichtung des Spielers
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (isFacingRight)
        {
            rb.linearVelocity = Vector2.right * shootingForce; // Schie�t nach rechts
        }
        else
        {
            rb.linearVelocity = Vector2.left * shootingForce; // Schie�t nach links
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight; // Umkehren der Blickrichtung
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Drehung des Spielers um 180 Grad
        transform.localScale = theScale;
    }
}

