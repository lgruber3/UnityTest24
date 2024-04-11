using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * 5f);
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}
