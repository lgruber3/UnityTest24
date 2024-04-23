using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;


[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
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
            case ESKillType.Projectile:
                if (skillData.projectileSkillData == null)
                {
                    skillData.projectileSkillData = new ProjectileSkillData();
                }
                break;
            case ESKillType.Jump:
                if (skillData.jumpSkillData == null)
                    skillData.jumpSkillData= new JumpSkillData();
                break;
            case ESKillType.Beam:
                if (skillData.beamSkillData == null)
                {
                    skillData.beamSkillData = new BeamSkillData();
                }
                break;
        }
    }
    
    public void Activate()
    {
        switch (skillType)
        {
            case ESKillType.Projectile:
            {
                skillData.projectileSkillData.Activate();
                break;
            }
            case ESKillType.Beam:
            {
                skillData.beamSkillData.Activate();
                break;
            }
        }
    }
}
