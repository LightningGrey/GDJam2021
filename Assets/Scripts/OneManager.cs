using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneManager : MonoBehaviour
{
    public static OneManager Instance { get; set; }
    public GameObject one;

    public Controls controls;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        controls = new Controls();
        controls.Always.Enable();
    }

    private void Start()
    {
        one.SetActive(false);
        controls.Always.Quit.performed += ctx => Quit();
    }

    public bool active()
    {
        Debug.Log(one.activeSelf);
        return one.activeSelf;
    }

    public void ShowOne()
    {
        one.SetActive(true);
    }

    public void HideOne()
    {
        one.SetActive(false);
    }

    public void Quit()
    {
        if (DialogueManager.Instance.textBox.activeSelf)
        {
            Debug.Log("Trying to exti text");
            DialogueManager.Instance.ExitText();
        }
        else
        {
            Debug.Log("Quiting");
            Application.Quit();
        }
    }
}
