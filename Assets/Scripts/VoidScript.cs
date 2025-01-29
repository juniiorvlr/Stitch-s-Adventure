using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float deathHeight = -210f; // Höhe, bei der der Player stirbt
    public GameObject deathScreen; // Referenz zum DeathScreen UI-Element
    public Health healthComponent; // Referenz zum Health-Skript des Spielers

    void Update()
    {
        // Überprüfen, ob der Player unter die Y-Höhe gefallen ist
        if (transform.position.y < deathHeight)
        {
            // Setze die Gesundheit auf 0
            if (healthComponent != null)
            {
                healthComponent.health = 0;
                healthComponent.TakeDamage(0); // Löst den DeathScreen aus
            }
        }
    }

}
