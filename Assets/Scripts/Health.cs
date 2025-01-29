using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Slider healthbar;
    public DeathScreenAnruf deathScreenAnruf; // Referenz zum DeathScreen-Skript

    // Start
    void Start()
    {
        health = maxHealth;
        healthbar.maxValue = maxHealth;
        healthbar.value = health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthbar.value = health;

        if (health <= 0)
        {
            // DeathScreen anzeigen
            deathScreenAnruf.ShowDeathScreen();

            // Zerstörung des GameObjects verhindern, damit UI sichtbar bleibt
            gameObject.SetActive(false);
        }
    }
}
