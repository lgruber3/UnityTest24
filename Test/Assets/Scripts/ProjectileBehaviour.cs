using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class ProjectileBehaviour : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyAfterSeconds(3));
    }
    
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBehavior>().TakeDamage(100);
            Destroy(gameObject);
        }
    }
    
    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
