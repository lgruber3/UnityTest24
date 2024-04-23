using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManagerBehaviouir : MonoBehaviour
{
    public GameObject[] waypoints;
    public static WaypointManagerBehaviouir instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
