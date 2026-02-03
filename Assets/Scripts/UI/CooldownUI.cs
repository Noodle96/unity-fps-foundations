using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    [SerializeField] private Slider cooldownSlider;

    private void Awake()
    {
        // Seguridad básica
        if (cooldownSlider == null)
        {
            cooldownSlider = GetComponent<Slider>();
        }

        // Empieza lleno (arma lista)
        SetCooldown(1f);
    }

    /// <summary>
    /// Recibe un valor normalizado entre 0 y 1
    /// </summary>
    public void SetCooldown(float value)
    {
        cooldownSlider.value = Mathf.Clamp01(value);
    }

    /// <summary>
    /// Reinicia la barra a llena
    /// </summary>
    public void ResetCooldown()
    {
        cooldownSlider.value = 1f;
    }
}
