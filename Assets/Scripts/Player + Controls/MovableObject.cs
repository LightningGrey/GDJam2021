using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public bool selected = false;
    public bool stay = false;
    public Vector3 originalPos;
    public float lerpValue = 0;
    public float lerpSpeed = 0.1f;

    public bool getSelected()
    {
        return selected;
    }

    public void setSelected(bool b)
    {
        selected = b;
    }

    public bool getStay()
    {
        return stay;
    }

    public void setStay(bool b)
    {
        stay = b;
    }

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            FollowCursor();
        }
        else if (!stay && Vector3.Distance(this.transform.position, originalPos) >= 0.1)
        {
            lerpValue += lerpSpeed * Time.deltaTime;
            ResetPosition();
        }
        else if (stay)
        {
            originalPos = this.transform.position;
            stay = false;
        }
        else
        {
            lerpValue = 0;
        }
    }

    private void FollowCursor()
    {
        this.transform.position = new Vector2(MouseManager.Instance.getCursurPos().x, MouseManager.Instance.getCursurPos().y - 0.5f);
    }

    private void ResetPosition()
    {
        this.transform.position = Vector2.Lerp(this.transform.position, originalPos, lerpValue);
    }
}
