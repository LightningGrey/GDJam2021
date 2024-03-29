using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct Dialogue {
    public string speaker;
    public string line;

    public Dialogue(string speaker, string line) {
        this.speaker = speaker;
        this.line = line;
    }
    public Dialogue(string s) {
        this.speaker = null;
        this.line = null;
    }
}

public class DialogueManager : MonoBehaviour {

    public static DialogueManager Instance { get; set; }

    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI textDisplay;
    public GameObject namePlate;
    public GameObject textBox;
    public float typingSpeed;
    public List<Dialogue> script = new List<Dialogue>();
    [SerializeField] private GameObject nextButton;
    public AudioClip sfx;
    public float volume = 0.5f;
    [SerializeField] private AudioSource audioSource;
    private int lineIndex;
    public bool showScript = true;

    [SerializeField] private GameObject oneObject;


    //enable event
    public static event Action disableEvent;
    public static event Action enableEvent;

    private void Awake() {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        oneObject.SetActive(false);
    }

    IEnumerator Type() {
        if (script[lineIndex].speaker != "")
        {
            namePlate.SetActive(true);
            nameDisplay.text = script[lineIndex].speaker;
        }
        else
            namePlate.SetActive(false);
        foreach (char letter in script[lineIndex].line.ToCharArray())
        {
            if (letter != ' ')
                audioSource.PlayOneShot(sfx, volume);
            if (letter == '1')
            {
                textDisplay.text += "  ";
                if (!OneManager.Instance.active())
                {
                    oneObject.SetActive(true);
                }
            }
            else
                textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        nextButton.SetActive(true);
    }

    public void NextLine() {
        oneObject.SetActive(false);
        if (lineIndex < script.Count - 1) {
            lineIndex++;
            textDisplay.text = "";
            /*
            if (script[lineIndex].speaker = "") {
                //script[lineIndex] = new Dialogue(script[lineIndex - 1].speaker, script[lineIndex].line);
            }
            */
            StartCoroutine(Type());
        }
        else
        {
            ExitText();
        }

        nextButton.SetActive(false);
    }

    public void DisplayText(List<Dialogue> newScript, AudioClip sound)
    {
        script = newScript;
        sfx = sound;
        enableEvent?.Invoke();
        textBox.SetActive(true);
        StartCoroutine(Type());
        nextButton.SetActive(false);
    }

    public void ExitText()
    {
        lineIndex = 0;
        textDisplay.text = "";
        textBox.SetActive(false);
        oneObject.SetActive(false);
        StopAllCoroutines();
        enableEvent?.Invoke();
    }

    public void SetOnePosition(Vector2 pos)
    {
        oneObject.transform.position = pos;
    }

    public void HideOneText()
    {
        oneObject.SetActive(false);
    }
}
