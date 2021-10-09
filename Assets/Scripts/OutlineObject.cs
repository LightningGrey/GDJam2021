using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer outlineRenderer;

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
    }
}
