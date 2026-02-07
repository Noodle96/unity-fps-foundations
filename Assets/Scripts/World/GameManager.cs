using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Player Stats")]
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private TextMeshProUGUI healthText;

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
        if (healthText != null)
        {
            healthText.text = playerHealth.ToString();
        }
    }

    // ---------- HEALTH ----------

    public void LoseHealth(int amount)
    {
        playerHealth -= amount;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (playerHealth <= 0)
        {
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
