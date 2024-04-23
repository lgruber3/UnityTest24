using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSKillBevhaviour : MonoBehaviour
{
    public List<Skill> acquiredSkills;
    private Dictionary<int, Skill> skillKeyMapping;
    [HideInInspector]
    public Skill currentSkill;
    public GameObject projectilePrefab;
    
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
            GameObject temp = GameObject.Instantiate(projectilePrefab, transform.position + transform.forward * 2, transform.rotation);
            temp.GetComponent<MeshRenderer>().material.color = currentSkill.skillData.damageSkillData.color;
            
            Debug.Log(currentSkill.skillName + " activated");
        }
    }
    
    public void AcquireSkill(Skill skill)
    {
        acquiredSkills.Add(skill);
        skillKeyMapping[acquiredSkills.Count] = skill;
    }
}
