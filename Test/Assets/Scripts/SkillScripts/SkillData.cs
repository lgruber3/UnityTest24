using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class SkillData
    {
        public ProjectileSkillData projectileSkillData;
        public JumpSkillData jumpSkillData;
        public BeamSkillData beamSkillData;
    }
    
    [System.Serializable]
    public class ProjectileSkillData
    {
        public int damage;
        public Color color;
        public GameObject projectilePrefab;
        private GameObject player;
        
        public void Activate()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
            }
            Debug.Log(player.transform.forward);
            GameObject temp = GameObject.Instantiate(projectilePrefab, player.transform.position + 
                                                            player.transform.forward * 2, player.transform.rotation);
            temp.GetComponent<MeshRenderer>().material.color = color;
        }
    }
    
    [System.Serializable]
    public class BeamSkillData
    {
        public float duration;
        public float damage;
        public Color color;
        private GameObject player;
        private LineRenderer lineRenderer;
        
        public void Activate()
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
                lineRenderer = player.AddComponent<LineRenderer>();
            }
            if (Physics.Raycast(player.transform.position, player.transform.forward, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    lineRenderer.startColor = color;
                    lineRenderer.endColor = color;
                    lineRenderer.SetPosition(0, player.transform.position);
                    lineRenderer.SetPosition(1, hit.point);
                }
            }
        }
    }
    
    [System.Serializable]
    public class JumpSkillData
    {
        public float jumpForce;
        public float jumpTime;
        public bool canDoubleJump;
    }
}