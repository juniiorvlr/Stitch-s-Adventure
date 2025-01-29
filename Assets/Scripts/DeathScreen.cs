using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathscreen; // UI-Element für den Deathscreen

    // DeathScreen anzeigen


    // Respawn (Szene neu laden)
    public void Respawn()
    {
        Time.timeScale = 1f; // Spiel fortsetzen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Gleiche Szene neu laden
    }

    // Zurück ins Hauptmenü
    public void MainMenuMeow()
    {
        Time.timeScale = 1f; // Spiel fortsetzen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Hauptmenü-Szene laden
    }
}
