using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer outlineRenderer;
    [SerializeField] private bool outlined = false;
    public bool getOutlined()
    {
        return outlined;
    }

    public void setOutlined(bool new_Outlined)
    {
        outlined = new_Outlined;
    }

    public void EnableOutline()
    {
        outlineRenderer.material.SetFloat("_OutlineEnabled", 1);
    }

    public void DisableOutline()
    {
        outlineRenderer.material.SetFloat("_OutlineEnabled", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (outlined)
        {
            EnableOutline();
        }
        else
        {
            DisableOutline();
        }
    }
}
