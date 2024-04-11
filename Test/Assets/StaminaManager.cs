using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public Slider staminaBar;
    private float stamina;
    public float maxStamina = 100f;
    public float staminaDecreaseRate = 1f;
    public float staminaIncreaseRate = 2f;

    private void Start()
    {
        stamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = stamina;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= staminaDecreaseRate * Time.deltaTime;
        }
        else
        {
            stamina += staminaIncreaseRate * Time.deltaTime;
        }
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        
        staminaBar.value = stamina;
    }
    public bool CanSprint()
    {
        return stamina > 0;
    }
}