using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    [Header("Player Stats")]
    public int gunAmmo = 10;
    public int grenadeAmmo = 3;
    public int playerHealth = 100;
    public TextMeshProUGUI healthText;
    public Image weaponIcon;

    [Header("HUD")]
    public TextMeshProUGUI ammoText;
    public Sprite gunIcon;
    public Sprite grenadeIcon;


    private void Awake()
    {
            Instance = this;    
    }

    private void Update()
    {
        //ammoText.text = gunAmmo.ToString();
        healthText.text = playerHealth.ToString();
    }

    public void UpdateAmmoUI(int ammo, Sprite icon)
    {
        ammoText.text = ammo.ToString();
        weaponIcon.sprite = icon;
    }

    public void LoseHealth(int loseHealth) { 
        playerHealth -= loseHealth;
        checkHealth();
    }
    public void checkHealth() {
        if (playerHealth <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
