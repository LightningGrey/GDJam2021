using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    // Start is called before the first frame update
    void OnEnable()
    {
        InteractionManager.interactionEvent += OpenChest;
    }

    void OnDisable()
    {
        InteractionManager.interactionEvent -= OpenChest;
    }

    void OpenChest()
    {
        
    }


}
