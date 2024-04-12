using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class SkillManager : MonoBehaviour
{
    private SkillNode root;
    private Dictionary<int, SkillNode> nodes;
    public GameObject panel;
    public List<Skill> skills;
    public Button skillUIPrefab;
    public GameObject player;
    
    void Start()
    {
        skills.Sort((a, b) => a.id.CompareTo(b.id));
        
        nodes = new Dictionary<int, SkillNode>();

        foreach (var skill in skills)
        {
            skill.acquired = false;
            SkillNode node = new SkillNode();
            node.skill = skill;
            nodes[skill.id] = node;

            if (root == null)
            {
                root = node;
            }
        }
        
        foreach (var skill in skills)
        {
            SkillNode node = nodes[skill.id];
            foreach (var nextSkillId in skill.nextSkills)
            {
                node.next.Add(nodes[nextSkillId]);
            }
        }
        
        GenerateSkillUI(root, 0, 0);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

    void GenerateSkillUI(SkillNode node, float depth, int index, int offset = 0)
    {
        if (node == null)
        {
            return;
        }
        
        Button skillUIObj = Instantiate(skillUIPrefab, panel.transform);
        skillUIObj.GetComponentInChildren<Text>().text = node.skill.skillName;
        skillUIObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(offset, depth * -100+150);
        skillUIObj.GetComponent<Image>().color = Color.black;
        skillUIObj.GetComponentInChildren<Text>().color = Color.white;
        
        
        int childCount = node.next.Count;
        int offsetNew = childCount > 1 ? (childCount - 1) * 50 : 0;

        skillUIObj.GetComponent<Button>().onClick.AddListener(() =>
        {
            SkillNode parent = node;
            foreach (var currNode in skills)
            {
                if (currNode.nextSkills.Contains(parent.skill.id))
                {
                    parent = nodes[currNode.id];
                    break;
                }
            }
            
            if (!node.skill.acquired && (parent.skill.acquired || node.skill.skillName == root.skill.skillName))
            {
                player.GetComponent<PlayerSKillBevhaviour>().AcquireSkill(node.skill);
                skillUIObj.GetComponent<Image>().color = Color.red;
                node.skill.acquired = true;
            }
        });
        
        for (int i = 0; i < childCount; i++)
        {
            GenerateSkillUI(node.next[i], depth+1, i, offset-offsetNew+i*100);
        }
    }
}
