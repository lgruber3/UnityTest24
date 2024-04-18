using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public bool acquired = false;
    public int id;
    public ESKillType skillType;
    public SkillData skillData;
    public List<int> nextSkills;

    private void OnValidate()
    {
        switch (skillType)
        {
            case ESKillType.Damage:
                if (skillData.damageSkillData == null)
                    skillData.damageSkillData = new DamageSkillData();
                break;
            case ESKillType.Movement:
                if (skillData.jumpSkillData == null)
                    skillData.jumpSkillData= new JumpSkillData();
                break;
        }
    }
}
