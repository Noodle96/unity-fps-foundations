using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Main Health")]
    [SerializeField] private int maxMainHealth = 200;
    [SerializeField] private int currentMainHealth = 200;

    [Header("Reserve Health")]
    [SerializeField] private int maxReserveHealth = 400;
    [SerializeField] private int currentReserveHealth = 0;

    [Header("UI")]
    [SerializeField] private Slider mainHealthSlider;
    [SerializeField] private Slider reserveHealthSlider;
    [SerializeField] private TextMeshProUGUI mainHealthText;
    [SerializeField] private TextMeshProUGUI reserveHealthText;

    private void Start()
    {
        currentMainHealth = Mathf.Clamp(currentMainHealth, 0, maxMainHealth);
        currentReserveHealth = Mathf.Clamp(currentReserveHealth, 0, maxReserveHealth);

        ConfigureSliders();
        UpdateUI();
    }

    private void ConfigureSliders()
    {
        if (mainHealthSlider != null)
        {
            mainHealthSlider.minValue = 0;
            mainHealthSlider.maxValue = maxMainHealth;
        }

        if (reserveHealthSlider != null)
        {
            reserveHealthSlider.minValue = 0;
            reserveHealthSlider.maxValue = maxReserveHealth;
        }
    }

    // ------------------ PUBLIC API ------------------

    public void TakeDamage(int amount)
    {
        if (amount <= 0) return;

        currentMainHealth -= amount;
        currentMainHealth = Mathf.Max(0, currentMainHealth);

        AutoRefillMainHealth();

        UpdateUI();

        if (currentMainHealth <= 0)
        {
            Die();
        }
    }

    public void AddReserveHealth(int amount)
    {
        if (amount <= 0) return;

        currentReserveHealth += amount;
        currentReserveHealth = Mathf.Min(maxReserveHealth, currentReserveHealth);

        // Si quieres que al recoger reserve, automáticamente rellene main:
        AutoRefillMainHealth();

        UpdateUI();
    }

    // ------------------ INTERNAL LOGIC ------------------

    private void AutoRefillMainHealth()
    {
        if (currentMainHealth >= maxMainHealth) return;
        if (currentReserveHealth <= 0) return;

        int needed = maxMainHealth - currentMainHealth;
        int transfer = Mathf.Min(needed, currentReserveHealth);

        currentMainHealth += transfer;
        currentReserveHealth -= transfer;
    }

    private void UpdateUI()
    {
        if (mainHealthSlider != null) mainHealthSlider.value = currentMainHealth;
        if (reserveHealthSlider != null) reserveHealthSlider.value = currentReserveHealth;

        if (mainHealthText != null) mainHealthText.text = $"{currentMainHealth}/{maxMainHealth}";
        if (reserveHealthText != null) reserveHealthText.text = $"{currentReserveHealth}/{maxReserveHealth}";
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
