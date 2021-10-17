using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrunkPanel : MonoBehaviour
{
    private Image _image;
    private float _currentOpacity = 0.0f;
    private float _targetOpacity = 0.3f;


    private Color startColour;
    private Color endColour;
    private float lerp = 0.0f;
    private float rate = 3.0f;

    void Start()
    {
        _image = gameObject.GetComponent<Image>();
        startColour = _image.color;
    }

    void SetDrunk()
    {
        endColour = new Color(Random.value,
            Random.value, Random.value,
            _targetOpacity);
        StartCoroutine(DrunkMode());
    }

    IEnumerator DrunkMode()
    {
        for (float f = 0.0f; f < 0.9f; f += Time.deltaTime)
        {

            lerp += Time.deltaTime * rate;
            _image.color = Color.Lerp(startColour, endColour, lerp);

            if (lerp >= 1.0f)
            {
                lerp = 0.0f;
                startColour = endColour;
                endColour = new Color(Random.value,
                    Random.value, Random.value,
                    _targetOpacity);
            }

            yield return new WaitForSeconds(.04f);
        }

        lerp = 0.0f;
        Color currentColour = _image.color;
        Color lastColour = new Color(endColour.r, endColour.g, endColour.b, 0);
        while (_image.color.a > 0)
        {
            lerp += Time.deltaTime * rate;
            _image.color = Color.Lerp(currentColour, lastColour, lerp);
            yield return new WaitForSeconds(.04f);
        }
        
        StopCoroutine(DrunkMode());
    }

    void OnEnable()
    {
        OutlineChest.chestEvent += SetDrunk;
    }

    void OnDisable()
    {
        OutlineChest.chestEvent -= SetDrunk;
    }
}
