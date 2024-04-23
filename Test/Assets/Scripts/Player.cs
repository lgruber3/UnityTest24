using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public readonly int maxHp = 100;
    public int hp = 100;
    public Slider hpBar;

    void Start()
    {
        // Initialize the HP bar value
        hpBar.maxValue = 1;
        hpBar.value = (float)hp/maxHp;
    }

    public void DecreaseHP()
    {
        // Decrease the HP
        hp -= 10;

        // Update the HP bar value
        hpBar.value = (float)hp/maxHp;
        
        if (hp <= 0)
        {
            // respawn
            hp = maxHp;
            hpBar.value = 1;
            transform.position = Spawnpoint.instance.transform.position;
        }
    }
}