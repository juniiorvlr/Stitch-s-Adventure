using UnityEngine;

public class WinScript : MonoBehaviour
{

    public GameObject Win;
    
    public void ShowWin()
    {
        Win.SetActive(true);
        Time.timeScale = 0;
    }
}
