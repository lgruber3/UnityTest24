using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeybindManager : MonoBehaviour
{
    public Text forwardKeyText; 
    public Text backwardKeyText;
    public Text leftKeyText; 
    public Text rightKeyText; 
    public Text jumpKeyText; 
    public Slider mouseSensitivitySlider;

    private KeyCode forwardKey;
    private KeyCode backwardKey;
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode jumpKey;
    private float mouseSensitivity;

    void Start()
    {
        // Default keys
        forwardKey = KeyCode.W;
        backwardKey = KeyCode.S;
        leftKey = KeyCode.A;
        rightKey = KeyCode.D;
        jumpKey = KeyCode.Space;

        // Default mouse sensitivity
        mouseSensitivity = 1.0f;

        // Update UI
        forwardKeyText.text = forwardKey.ToString();
        backwardKeyText.text = backwardKey.ToString();
        leftKeyText.text = leftKey.ToString();
        rightKeyText.text = rightKey.ToString();
        jumpKeyText.text = jumpKey.ToString();
        mouseSensitivitySlider.value = mouseSensitivity;
    }

    void Update()
    {
        // Use the keys for movement
        // Use mouseSensitivity for mouse look speed
    }

    public void ChangeForwardKey()
    {
        StartCoroutine(ListenForKey(key => forwardKey = key, forwardKeyText));
    }

    public void ChangeBackwardKey()
    {
        StartCoroutine(ListenForKey(key => backwardKey = key, backwardKeyText));
    }

    public void ChangeLeftKey()
    {
        StartCoroutine(ListenForKey(key => leftKey = key, leftKeyText));
    }

    public void ChangeRightKey()
    {
        StartCoroutine(ListenForKey(key => rightKey = key, rightKeyText));
    }

    public void ChangeJumpKey()
    {
        StartCoroutine(ListenForKey(key => jumpKey = key, jumpKeyText));
    }

    public void ChangeMouseSensitivity()
    {
        mouseSensitivity = mouseSensitivitySlider.value;
    }

    IEnumerator ListenForKey(System.Action<KeyCode> setKey, Text keyText)
    {
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                setKey(keyCode);
                keyText.text = keyCode.ToString();
                break;
            }
        }
    }
}