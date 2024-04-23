using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public static Spawnpoint instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
