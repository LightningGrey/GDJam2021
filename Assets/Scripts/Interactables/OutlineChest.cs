using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineChest : MonoBehaviour
{
    public GameObject openChest;
    public GameObject item;
    public static event Action chestEvent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<OutlineObject>().getConditionMet())
        {
            openChest.SetActive(true);
            item.SetActive(true);
            this.gameObject.SetActive(false);
            chestEvent?.Invoke();
        }
    }

}
