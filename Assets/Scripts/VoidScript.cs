using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float deathHeight = -210f; // H�he, bei der der Player stirbt
    public GameObject deathScreen; // Referenz zum DeathScreen UI-Element
    public Health healthComponent; // Referenz zum Health-Skript des Spielers

    void Update()
    {
        // �berpr�fen, ob der Player unter die Y-H�he gefallen ist
        if (transform.position.y < deathHeight)
        {
            // Setze die Gesundheit auf 0
            if (healthComponent != null)
            {
                healthComponent.health = 0;
                healthComponent.TakeDamage(0); // L�st den DeathScreen aus
            }
        }
    }

}
