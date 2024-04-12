using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private GameObject[] canvasElements;
    public GameObject canvas;

    void Start()
    {
        Transform[] childTransforms = canvas.GetComponentsInChildren<Transform>();
        
        canvasElements = new GameObject[childTransforms.Length];
        for (int i = 0; i < childTransforms.Length; i++)
        {
            canvasElements[i] = childTransforms[i].gameObject;
        }
        
        foreach (GameObject element in canvasElements)
        {
            element.SetActive(false);
        }
    }
}