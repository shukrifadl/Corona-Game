using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 2.0f;
    public TextMeshProUGUI scoreText;
   // public TextMeshProUGUI finalScore;
    public TextMeshProUGUI gameOverText;
  //  public TextMeshProUGUI wonText;
    //public TextMeshProUGUI timerText;
    public TextMeshProUGUI highScoreText;
    public int score=0;
    private int pointScore=5;
    public  bool isGameOver;
    public bool isGameActive;

    public  bool isGamePaused = false;
    public Button restartButton;
    //public Button wonRestartButton;
    public GameObject titleScreen;
    public GameObject EndScreen;
    public GameObject pauseScreen;
    public GameObject runTimeScreen;
    public GameObject highScoreScreen;
    public GameObject sword;



    private CameraSoundPlay soundPlay;
    private SwipeTrial swipeTrial;




    private void Start()
    {
        soundPlay = GameObject.Find("MainCamera").GetComponent<CameraSoundPlay>();
       
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); 
       // swipeTrial=sword.gameObject.GetComponent<SwipeTrial>();
    }

   IEnumerator spawnTarget()
    {
        while(!isGamePaused && !isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
   
    public void UpdateScore()
    {

        score +=pointScore;
        scoreText.text = "Score :" + score;
    }
    public void GameOver()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
        
        EndScreen.SetActive(true);
        isGameOver = true;
        isGameActive = false;
      
        soundPlay.playLoseSound();
        //sword.SetActive(false);
    }
   /* public void Won()
    {   
        isWon = true;
        isGameActive = false;
        runTimeScreen.SetActive(false);
        finalScore.text = "Score :" + score;
        WonScreen.gameObject.SetActive(true);
        EndScreen.gameObject.SetActive(false);
      
    }*/
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        runTimeScreen.SetActive(false);

    }
    public void StartGame()
    {
        isGameOver = false;
        isGameActive = true;
   
        score = 0;
        StartCoroutine(spawnTarget());
      //  pointScore = pPointScore;
        titleScreen.gameObject.SetActive(false);
        //spawnRate /= difficulty;
        runTimeScreen.SetActive(true);
       
       /* sword.SetActive(true);
        swipeTrial.TouchReader();*/
    }
   /* void timer()
    {
            timeLeft -= Time.deltaTime;
            timerText.SetText("" + Mathf.Round(timeLeft));
            if (timeLeft < 1.0f)
            {
                Won();
            }           
    }*/

   public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        StartCoroutine(spawnTarget());
        isGameActive = true;
        //sword.SetActive(true);
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        isGameActive = false;
       // sword.SetActive(false);
    }
    public void ShowHighScore()
    {
        highScoreScreen.SetActive(true);
        titleScreen.SetActive(false);

    }
}
