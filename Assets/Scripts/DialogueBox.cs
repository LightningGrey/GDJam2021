using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] script;
    private int lineIndex;
    public float typingSpeed;

    public GameObject nextButton;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Type());
        nextButton.SetActive(false);
    }

    IEnumerator Type() {
        foreach(char letter in script[lineIndex].ToCharArray()) {
            if (letter == '1')
                text.text += ' ';
            else
                text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        nextButton.SetActive(true);
    }

    public void NextLine() {
        if (lineIndex < script.Length - 1) {
            lineIndex++;
            text.text = "";
            StartCoroutine(Type());
        }
        else {
            text.text = "";
        }
        nextButton.SetActive(false);
    }
}
