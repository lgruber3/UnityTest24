using UnityEditor;
using UnityEngine;
using DefaultNamespace;

[CustomEditor(typeof(Skill))]
public class SkillEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Skill skill = (Skill)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("skillName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("acquired"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("id"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("skillType"));

        switch (skill.skillType)
        {
            case ESKillType.Projectile:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("skillData.projectileSkillData"));
                break;
            case ESKillType.Jump:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("skillData.jumpSkillData"));
                break;
            case ESKillType.Beam:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("skillData.beamSkillData"));
                break;
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("nextSkills"));

        serializedObject.ApplyModifiedProperties();
    }
}