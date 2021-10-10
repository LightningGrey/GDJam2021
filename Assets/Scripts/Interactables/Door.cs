using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject openDoor;

    public static event Action doorEvent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<OutlineObject>().getConditionMet())
        {
            openDoor.SetActive(true);
            this.gameObject.SetActive(false);
            doorEvent?.Invoke();
        }
    }
}
