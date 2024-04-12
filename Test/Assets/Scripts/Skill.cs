using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public bool acquired = false;
    public int id;
    public Color color;
    public List<int> nextSkills;
}
