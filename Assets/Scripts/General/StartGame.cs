using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private Button startButton;
    // Start is called before the first frame update
    
    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(GameStart);
    }

    void GameStart()
    {
        SceneManager.LoadScene("Main Scene");
    }
}