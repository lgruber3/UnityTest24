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
            case ESKillType.Damage:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("skillData.damageSkillData"));
                break;
            case ESKillType.Movement:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("skillData.jumpSkillData"));
                break;
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("nextSkills"));

        serializedObject.ApplyModifiedProperties();
    }
}