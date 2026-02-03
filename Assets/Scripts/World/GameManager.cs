using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int gunAmmo = 10;
    public int playerHealth = 100;

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI healthText;

    private void Awake()
    {
            Instance = this;    
    }

    private void Update()
    {
        ammoText.text = gunAmmo.ToString();
        healthText.text = playerHealth.ToString();
    }
}
