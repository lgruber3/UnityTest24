using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int maxHP = 100;
    public int hp = 100;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        hpText.text = hp.ToString() + "/" + maxHP.ToString();
    }

    // Update is called once per frame
    public void DecreaseHP(int damage)
    {
        hp -= damage;
        hpText.text = hp.ToString() + "/" + maxHP.ToString();
        if (hp <= 0)
        {
            hpText.text = "Game Over";
        }
    }
}
