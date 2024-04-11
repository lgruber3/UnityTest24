using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 5f;
    private float verticalRotation = 0f;
    public float upLimit = 60f;
    public float downLimit = -20f;
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
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        verticalRotation -= verticalSpeed * Input.GetAxis("Mouse Y");
        verticalRotation = Mathf.Clamp(verticalRotation, downLimit, upLimit);

        transform.Rotate(0, h, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
