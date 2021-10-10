using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    private static MouseManager _instance;
    public Texture2D cursor;
    public Texture2D cursorClicked;

    private Controls controls;
    private Camera mainCamera;

    private GameObject selectedObject;
    private GameObject outlineObject;

    Vector2 cursorScreenPos;
    Vector2 cursorWorldPos;

    public static MouseManager Instance { get { return _instance; } }
    public Vector2 getCursurPos(float type)
    {
        if (type == 0)
        {
            return cursorScreenPos;
        }
        else if (type == 1)
        {
            return cursorWorldPos;
        }
        else
        {
            return Vector2.zero;
        }
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
        cursorScreenPos = controls.Mouse.Position.ReadValue<Vector2>();
        cursorWorldPos = mainCamera.ScreenToWorldPoint(controls.Mouse.Position.ReadValue<Vector2>());

        if(selectedObject != null)
        {
            DetectOutlineObject();
        }

        if (outlineObject != null)
        {
            if (outlineObject.GetComponent<OutlineObject>() != null)
            {
                outlineObject.GetComponent<OutlineObject>().setOutlined(true);
            }
        }
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
                if(outlineObject != null)
                {
                    selectedObject.GetComponent<MovableObject>().setStay(true);
                    outlineObject.GetComponent<OutlineObject>().setOutlined(false);
                    outlineObject.GetComponent<OutlineObject>().setConditionMet(true);
                    outlineObject = null;
                }
                selectedObject.GetComponent<MovableObject>().setSelected(false);
                selectedObject.SetActive(false);
                selectedObject = null;
            }
        }
    }

    private void DetectClick()
    {
        //World
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
            }
        }
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if (hits2D.collider != null)
        {
            //Debug.Log("Hit 2D collider " + hits2D.collider.tag);
            if (hits2D.collider.gameObject.GetComponent<MovableObject>() != null)
            {
                selectedObject = hits2D.collider.gameObject;
            }
        }

        //UI
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        
        pointerData.position = cursorScreenPos;
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        
        if (results.Count > 0)
        {
            Debug.Log(results[0].gameObject.name);
            for (int i = 0; i < results.Count; i++)
            {
                selectedObject = results[i].gameObject;
                selectedObject.transform.GetComponent<MovableObject>().setSelected(true);
            }
        }
    }

    private void DetectOutlineObject()
    {
        bool outlineObjectDetected = false;
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
            }
        }

        RaycastHit2D[] hits2DAll = Physics2D.GetRayIntersectionAll(ray);
        for(int i = 0; i < hits2DAll.Length; i++)
        {
            if(hits2DAll[i].collider != null)
            {
                if(hits2DAll[i].collider.tag == "OutlineObject")
                {
                    outlineObjectDetected = true;
                    outlineObject = hits2DAll[i].collider.gameObject;
                }
            }
        }

        if (!outlineObjectDetected && outlineObject != null)
        {
            Debug.Log("Object null");
            outlineObject.GetComponent<OutlineObject>().setOutlined(false);
            outlineObject = null;
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
