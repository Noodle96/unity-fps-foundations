using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


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

    private float visualMainHealth;
    private float visualReserveHealth;
    private bool isMainIncreasing;
    private bool isReserveIncreasing;
    private Image mainFillImage;
    private Image reserveFillImage;
    private Color mainBaseColor;
    private Color reserveBaseColor;

    [SerializeField] private float fillSpeed = 150f;

    private void Start()
    {
        currentMainHealth = Mathf.Clamp(currentMainHealth, 0, maxMainHealth);
        currentReserveHealth = Mathf.Clamp(currentReserveHealth, 0, maxReserveHealth);

        visualMainHealth = currentMainHealth;
        visualReserveHealth = currentReserveHealth;

        mainFillImage = mainHealthSlider.fillRect.GetComponent<Image>();
        reserveFillImage = reserveHealthSlider.fillRect.GetComponent<Image>();

        mainBaseColor = mainFillImage.color;
        reserveBaseColor = reserveFillImage.color;

        ConfigureSliders();
        UpdateUI();
    }

    private void Update()
    {
        AnimateHealthBars();
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
        //if (mainHealthSlider != null) mainHealthSlider.value = currentMainHealth;
        //if (reserveHealthSlider != null) reserveHealthSlider.value = currentReserveHealth;

        //if (mainHealthText != null) mainHealthText.text = $"{currentMainHealth}/{maxMainHealth}";
        //if (reserveHealthText != null) reserveHealthText.text = $"{currentReserveHealth}/{maxReserveHealth}";
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void AnimateHealthBars()
    {
        isMainIncreasing = visualMainHealth < currentMainHealth;
        isReserveIncreasing = visualReserveHealth < currentReserveHealth;

        visualMainHealth = Mathf.MoveTowards(
            visualMainHealth,
            currentMainHealth,
            fillSpeed * Time.deltaTime
        );

        visualReserveHealth = Mathf.MoveTowards(
            visualReserveHealth,
            currentReserveHealth,
            fillSpeed * Time.deltaTime
        );

        mainHealthSlider.value = visualMainHealth;
        reserveHealthSlider.value = visualReserveHealth;

        UpdateBarVisuals();
        UpdateHealthTexts();
    }

    private void UpdateBarVisuals()
    {
        if (isMainIncreasing)
        {
            mainFillImage.color = Color.Lerp(mainBaseColor, Color.white, 0.4f);
        }
        else
        {
            mainFillImage.color = mainBaseColor;
        }

        if (isReserveIncreasing)
        {
            reserveFillImage.color = Color.Lerp(reserveBaseColor, Color.white, 0.4f);
        }
        else
        {
            reserveFillImage.color = reserveBaseColor;
        }
    }

    private void UpdateHealthTexts()
    {
        mainHealthText.text = $"{Mathf.RoundToInt(visualMainHealth)}/{maxMainHealth}";
        reserveHealthText.text = $"{Mathf.RoundToInt(visualReserveHealth)}/{maxReserveHealth}";
    }
}
