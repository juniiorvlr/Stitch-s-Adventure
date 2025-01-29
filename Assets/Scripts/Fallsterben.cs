using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathScreen; // Referenz zum Death Screen UI
    private bool isDead = false;

    // Diese Methode wird aufgerufen, wenn der Spieler den Trigger betritt
    private void OnTriggerEnter(Collider other)
    {
        if (!isDead && other.CompareTag("DeathZone")) // Prüft, ob der Trigger ein DeathZone-Tag hat
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true; // Verhindert mehrfaches Auslösen
        deathScreen.SetActive(true); // Death Screen anzeigen
        Time.timeScale = 0f; // Spiel anhalten
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Spielzeit zurücksetzen
        SceneManager.LoadScene("DeathScreen"); // Hauptmenü laden
    }
}