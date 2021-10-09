using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private static MouseManager _instance;
    public Texture2D cursor;
    public Texture2D cursorClicked;

    private Controls controls;
    private Camera mainCamera;

    private GameObject selectedObject;

    Vector2 cursorPos;

    public static MouseManager Instance { get { return _instance; } }
    public Vector2 getCursurPos()
    {
        return cursorPos;
    }
    
    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        controls = new Controls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }

    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }

    private void Update()
    {
        cursorPos = mainCamera.ScreenToWorldPoint(controls.Mouse.Position.ReadValue<Vector2>());


    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
        DetectClick();
        if (selectedObject != null)
        {
            if (selectedObject.GetComponent<MovableObject>() != null)
            {
                selectedObject.GetComponent<MovableObject>().setSelected(true);
            }
            if (selectedObject.GetComponent<OutlineObject>() != null)
            {
                selectedObject.GetComponent<OutlineObject>().EnableOutline();
            }
        }
        else
        {
            Debug.Log("Nothing selected");
        }
    }

    private void EndedClick()
    {
        ChangeCursor(cursor);
        if (selectedObject != null)
        {
            if (selectedObject.GetComponent<MovableObject>() != null)
            {
                selectedObject.GetComponent<MovableObject>().setSelected(false);
                selectedObject = null;
            }
            if (selectedObject.GetComponent<OutlineObject>() != null)
            {
                selectedObject.GetComponent<OutlineObject>().DisableOutline();
                selectedObject = null;
            }
        }
    }

    private void DetectClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
            }
        }
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if(hits2D.collider != null)
        {
            Debug.Log("Hit 2D collider " + hits2D.collider.tag);
            selectedObject = hits2D.collider.gameObject;
        }
    }
    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Vector2 hotspot = Vector2.zero;
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
