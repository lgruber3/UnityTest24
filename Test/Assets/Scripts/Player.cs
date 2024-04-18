using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int hp = 100;
    public Slider hpBar;

    void Start()
    {
        // Initialize the HP bar value
        hpBar.maxValue = hp;
        hpBar.value = hp;
    }

    public void DecreaseHP()
    {
        // Decrease the HP
        hp -= 10;

        // Update the HP bar value
        hpBar.value = hp;
    }
}