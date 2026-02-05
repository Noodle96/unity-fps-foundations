using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    private bool isGamePaused = false;
    void Start()
    {
        menuPanel.SetActive(false);
    }

    void Update()
    {
        // if si apreta la tecla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            isGamePaused = !isGamePaused;
            PauseGame();
        }
    }

    public void PauseGame() {
        if (isGamePaused)
        {
            Time.timeScale = 0f;
            menuPanel.SetActive(true);
        }
        else {
            Time.timeScale = 1f;
            menuPanel.SetActive(false);
        }
    
    }

}
