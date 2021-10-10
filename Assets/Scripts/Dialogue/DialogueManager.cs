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
    public TextMeshProUGUI namePlate;
    public TextMeshProUGUI textDisplay;
    public float typingSpeed;
    public List<Dialogue> script = new List<Dialogue>();
    [SerializeField] private GameObject nextButton;
    [SerializeField] private AudioClip sfx;
    public float volume = 0.5f;
    private AudioSource audioSource;
    private int lineIndex;
    public bool showScript = true;

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Type());
        nextButton.SetActive(false);
    }

    IEnumerator Type() {
        foreach (char letter in script[lineIndex].line.ToCharArray()) {
            if (letter != ' ')
                audioSource.PlayOneShot(sfx, volume);
            if (letter == '1')
                textDisplay.text += "  ";
            else
                textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        nextButton.SetActive(true);
    }

    public void NextLine() {
        if (lineIndex < script.Count - 1) {
            lineIndex++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else {
            textDisplay.text = "";
        }
        nextButton.SetActive(false);
    }
}
