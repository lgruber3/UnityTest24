using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSKillBevhaviour : MonoBehaviour
{
    private List<Skill> acquiredSkills;
    private Dictionary<int, Skill> skillKeyMapping;
    private Skill currentSkill;
    
    // Start is called before the first frame update
    void Start()
    {
        acquiredSkills = new List<Skill>();
        skillKeyMapping = new Dictionary<int, Skill>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;
            int keyNumber;
            if (int.TryParse(keyPressed, out keyNumber) && skillKeyMapping.ContainsKey(keyNumber))
            {
                currentSkill = skillKeyMapping[keyNumber];
                Debug.Log("Current skill: " + currentSkill.skillName);
            }
        }
        
        if (Input.GetMouseButtonDown(0) && currentSkill != null)
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            temp.transform.position = transform.position + transform.forward * 1;
            temp.GetComponent<MeshRenderer>().material.color = currentSkill.color;
            Rigidbody rb = temp.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(500 * transform.forward * Time.deltaTime, ForceMode.Impulse);
                
            Debug.Log(currentSkill.skillName + " activated");
        }
    }
    
    public void AcquireSkill(Skill skill)
    {
        acquiredSkills.Add(skill);
        skillKeyMapping[acquiredSkills.Count] = skill;
    }
}
