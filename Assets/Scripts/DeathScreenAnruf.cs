using UnityEngine;

public class DeathScreenAnruf : MonoBehaviour
{

    public GameObject Death;
    public void ShowDeathScreen()
    {
        Death.SetActive(true);
        Time.timeScale = 0f; // Spiel pausieren
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
