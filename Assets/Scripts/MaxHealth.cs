using UnityEngine;

public class MaxHealth : MonoBehaviour
{
    public float health = 50f; // Startlebenspunkte des Gegners
    public float damage = 4f;
    public WinScript winscript;

    // Diese Methode wird vom Bullet-Skript aufgerufen, um Schaden zuzufügen
    public void TakeDamage(float damage)
    {
        health -= damage; // Schaden wird von den Lebenspunkten abgezogen

        // Wenn die Lebenspunkte des Gegners auf 0 oder weniger sinken, stirbt der Gegner
        if (health <= 0f)
        {
            Die();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if (bullet != null)
        {
            TakeDamage(bullet.damage); // Deal damage to the enemy
            Destroy(bullet.gameObject); // Destroy the player's bullet
        }
    }


    // Diese Methode wird aufgerufen, wenn der Gegner stirbt
    void Die()
    {
        // Hier kannst du alles tun, was beim Tod des Gegners passieren soll
        // Zum Beispiel: Zerstörung des Gegners oder eine Animation abspielen
        WinScript winscript = Object.FindFirstObjectByType<WinScript>();
            if (winscript != null)
        {
            winscript.ShowWin();
        }
        Destroy(gameObject); // Zerstört den Gegner (GameObject)
        
    }
}