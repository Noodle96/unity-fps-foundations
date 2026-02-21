using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject winPanel;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
       
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);

        // Opcional: detener tiempo
        Time.timeScale = 0f;
    }
}
