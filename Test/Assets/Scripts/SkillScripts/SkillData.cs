using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class SkillData
    {
        public DamageSkillData damageSkillData;
        public JumpSkillData jumpSkillData;
    }
    
    [System.Serializable]
    public class DamageSkillData
    {
        public int damage;
        public Color color;
    }
    
    [System.Serializable]
    public class JumpSkillData
    {
        public float jumpForce;
        public float jumpTime;
        public bool canDoubleJump;
    }
}