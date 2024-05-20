using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Button startButton;

    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startButton == null && quitButton == null)
        {
            Debug.LogError("Buttons not assigned!");
            return;
        }
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }
    
    void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelScene");
        Debug.Log("Game Started!");
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}
