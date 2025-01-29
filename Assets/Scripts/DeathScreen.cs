using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathscreen; // UI-Element f�r den Deathscreen

    // DeathScreen anzeigen


    // Respawn (Szene neu laden)
    public void Respawn()
    {
        Time.timeScale = 1f; // Spiel fortsetzen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Gleiche Szene neu laden
    }

    // Zur�ck ins Hauptmen�
    public void MainMenuMeow()
    {
        Time.timeScale = 1f; // Spiel fortsetzen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Hauptmen�-Szene laden
    }
}
