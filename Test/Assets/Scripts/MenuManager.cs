using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    private GameObject[] menuElements;
    

    private void Start()
    {
        menuElements = GameObject.FindGameObjectsWithTag("MenuElement"); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                foreach (GameObject element in menuElements)
                {
                    element.SetActive(false);
                }
                Time.timeScale = 1;
            }
            else
            {
                menu.SetActive(true);
                foreach (GameObject element in menuElements)
                {
                    element.SetActive(true);
                }
                Time.timeScale = 0;
            }
        }
    }
}