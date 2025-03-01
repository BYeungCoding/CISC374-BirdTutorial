using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public int highScore;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public bool gameIsOver = false;
    public AudioSource scoreIncrease;
    public GameObject titleScreen;
    public GameObject gameUI;
    public bool gameStarted = false;
    public SpawnController spawnController;
    public GameObject spawnControllerObject;

    [System.Obsolete]
    void Start()
    {
        scoreIncrease = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
        titleScreen.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0;
        spawnController = spawnControllerObject.GetComponent<SpawnController>();
        if (spawnController == null)
        {
            Debug.LogError("SpawnController not found! Make sure there is a GameObject with SpawnController in the scene.");
        }
    }

    public void StartGame()
    {
        // Hide title screen and show game UI
        titleScreen.SetActive(false);
        gameUI.SetActive(true);
        gameStarted = true;
        Time.timeScale = 1;
    }
    public void addScore(int scoreToAdd){
        if(!gameIsOver){
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            scoreIncrease.Play();

            if(playerScore > highScore){
                highScore = playerScore;
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
                highScoreText.text = "High Score: " + highScore.ToString();
            }
            if (playerScore % 5 == 0 && spawnController != null) // Every 10 pipes passed
            {
                spawnController.IncreaseSpeed(); // Call function to speed up pipes
                spawnController.ChangeBackgroundColor();  // Change background color
            }
        }
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
        gameIsOver = true;
        gameOverScreen.SetActive(true);
    }
}
