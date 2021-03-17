using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainScreen : MonoBehaviour
{
    public Button playButton;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playButton = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();        
        playButton.onClick.AddListener(GameStart);        
    }
    void GameStart()
    {
        gameManager.StartGame();
    }    
}
