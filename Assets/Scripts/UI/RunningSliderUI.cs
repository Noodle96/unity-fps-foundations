using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RunningSliderUI : MonoBehaviour
{
    //[Header("Parametros running slider")]
    //public Slider runningSlider;
    //private float maxStamina = 100f;
    //private float currentStamina;
    //private float regenerateStaminaTime = 0.1f;
    //private float regenerateAmount = 2f;
    //private float losingStaminaTime = 0.1f;

    //private Coroutine myCoroutineLosing;
    //private Coroutine myCoroutineRegenerate;

    //void Start()
    //{
    //    currentStamina = maxStamina;
    //    runningSlider.maxValue = maxStamina;
    //    runningSlider.value = maxStamina;
    //}


    //public void UseStamina(float amount) {
    //    if (currentStamina - amount > 0)
    //    {
    //        if (myCoroutineLosing != null)
    //        {
    //            StopCoroutine(myCoroutineLosing);
    //        }
    //        myCoroutineLosing = StartCoroutine(LosingStaminaCoroutime(amount));

    //        if (myCoroutineRegenerate != null)
    //        {
    //            StopCoroutine(myCoroutineRegenerate);
    //        }
    //        myCoroutineRegenerate = StartCoroutine(RegenerateStaminaCoroutime());
    //    }
    //    else { 
    //        Object.FindFirstObjectByType<PlayerMovement>().isRunning = false;
    //    }

    //}

    //private IEnumerator LosingStaminaCoroutime(float amount) {
    //    while (currentStamina >= 0)
    //    {
    //        currentStamina -= amount;
    //        runningSlider.value = currentStamina;
    //        yield return new WaitForSeconds(losingStaminaTime);
    //    }
    //    myCoroutineLosing = null;
    //    Object.FindFirstObjectByType<PlayerMovement>().isRunning = false;
    //}

    //private IEnumerator RegenerateStaminaCoroutime() {
    //    yield return new WaitForSeconds(1f);
    //    while (currentStamina < maxStamina) { 
    //        currentStamina += regenerateAmount;
    //        runningSlider.value = currentStamina;
    //        yield return new WaitForSeconds(regenerateStaminaTime);
    //    }
    //    myCoroutineRegenerate = null;

    //}
    public Slider runningSlider;

    private float maxStamina = 100f;
    private float currentStamina;

    public float staminaLoseRate = 10f;
    public float staminaRegenRate = 15f;

    private bool isRunning;

    void Start()
    {
        currentStamina = maxStamina;
        runningSlider.maxValue = maxStamina;
        runningSlider.value = maxStamina;
    }

    void Update()
    {
        if (isRunning)
        {
            currentStamina -= staminaLoseRate * Time.deltaTime;
        }
        else
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        runningSlider.value = currentStamina;

        if (currentStamina <= 0)
        {
            isRunning = false;
        }
    }

    public bool CanRun()
    {
        return currentStamina > 0;
    }

    public void SetRunning(bool running)
    {
        isRunning = running;
    }
}
