using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject gameOverContainer;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToBlack()
    {
        gameOverContainer.SetActive(true);
        image.CrossFadeAlpha(1, 5.0f, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FadeToBlack();
        Debug.Log("End Game");
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level Scene");
    }
}
