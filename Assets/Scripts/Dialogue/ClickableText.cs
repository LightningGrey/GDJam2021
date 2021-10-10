using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.InputSystem;

public class ClickableText : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var text = GetComponent<TextMeshProUGUI>();
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("test");
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
            if (linkIndex > -1)
            {
                
                
                Debug.Log("get one");
            }

        }


        throw new System.NotImplementedException();
    }
}
