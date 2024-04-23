using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 5f;
    private float verticalRotation = 0f;
    public float upLimit = 60f;
    public float downLimit = -20f;
	public float sprintSpeed = 2f;
    private bool isMenueActive = false;
    private PlayerSKillBevhaviour playerSKillBevhaviour;
    private bool secondJump = false;

	public StaminaManager staminaManager;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        playerSKillBevhaviour = GetComponent<PlayerSKillBevhaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * 5f);
        
        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (secondJump && !Physics.Raycast(transform.position, Vector3.down, 1.1f))
            {
                foreach (var skill in playerSKillBevhaviour.acquiredSkills)
                {
                    if (skill.skillType == ESKillType.Jump)
                    {
                        if (skill.skillData.jumpSkillData.canDoubleJump)
                        {
                            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
                            secondJump = false;
                        }
                        break;
                    }

                }
            }
            else if (!secondJump && Physics.Raycast(transform.position, Vector3.down, 1.1f))
            {
                rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
                foreach (var skill in playerSKillBevhaviour.acquiredSkills)
                {
                    if (skill.skillType == ESKillType.Jump)
                    {
                        if (skill.skillData.jumpSkillData.canDoubleJump)
                        {
                            secondJump = true;
                        }
                        break;
                    }

                }
            }
        }
        
		//sprint
		if ((Input.GetKey(KeyCode.LeftShift)) && staminaManager.CanSprint())
        {
            transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * horizontalSpeed * sprintSpeed);
        }
        else
        {
            transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * horizontalSpeed);
        }
		//mouse look
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            if (isMenueActive)
            {
                Cursor.lockState = CursorLockMode.Locked;
                isMenueActive = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                isMenueActive = true;
            }
        }
        if (!isMenueActive)
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            verticalRotation -= verticalSpeed * Input.GetAxis("Mouse Y");
            verticalRotation = Mathf.Clamp(verticalRotation, downLimit, upLimit);

            transform.Rotate(0, h, 0);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
    }
}
