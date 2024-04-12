using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillNode
{
    public Skill skill;
    public List<SkillNode> next;
    
    public SkillNode()
    {
        next = new List<SkillNode>();
    }
}
