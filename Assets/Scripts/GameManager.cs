using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform distanceCheckPoint;
    [SerializeField]
    private Transform distancePlayer;
    [SerializeField]
    private Transform cameraDistance;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI gameOverText;    
    
    public Button playAgainButton;
    public GameObject mainScreen;
    private float distance;
    public bool isGameActive;

    private LevelGenerator levelGenerator;

    // Start is called before the first frame update
    void Start()
    {
        // For LevelGenerator class
        levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Calculate distance value between character and checkpoint
        distance = (distanceCheckPoint.transform.position - distancePlayer.transform.position).magnitude;

        // Display distance value via UI text
        // distance.ToString("F1") shows value with 1 digit after period
        distanceText.text = "Distance: " + distance.ToString("F1") + " meters";

        if ((cameraDistance.transform.position.y - distancePlayer.transform.position.y) >= 50)
        {            
            GameOver();
        }
    }
    public void GameOver()
    {
        playAgainButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void PlayAgainGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        isGameActive = true;
        distance = 0;
        mainScreen.gameObject.SetActive(false);
        levelGenerator.ActivateGame();
    }
}
