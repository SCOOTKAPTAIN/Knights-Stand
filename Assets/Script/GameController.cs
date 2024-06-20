using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject gameOverCanvas; 
    public GameObject gameOverCanvasAlt; 

    public Button restartButton;  
    public Button quitButton;
    
   
    public Image item; 
    public ItemData[] items;  
    public int lives = 3;  
    public Text livesText; 

    private int currentIndex = 0;  
    private string[] itemCategories = { "Left", "Right"};  

    public int score = 0;
    public Text scoreText;

    public bool Timeout = false;

     public Text timerText;
    public Animator ouch;
    public Animator nice;

     public AudioSource correctSound;  
     public AudioSource BGM;
    public AudioSource lifeLostSound; 

    public AudioSource gameoverSE;
    public AudioSource gameoverSEAlt;
   [SerializeField] float remainingTime;

   

   
    void Start()
    {
        SpawnItem();

        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
        gameOverCanvas.SetActive(false);
        gameOverCanvasAlt.SetActive(false);
       
    }

    void Update()
    {
        if(remainingTime > 0){

        remainingTime -= Time.deltaTime;

    }else if (remainingTime < 0)
    {
        remainingTime = 0;
        Timeout = true;
        GameOver();

    }
        

    int minutes = Mathf.FloorToInt(remainingTime / 60);
    int seconds = Mathf.FloorToInt(remainingTime % 60);
    timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SortItem("Left");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SortItem("Right");
        }
    }



   void SpawnItem()
   {
      
       currentIndex = Random.Range(0, items.Length);
       item.sprite = items[currentIndex].itemSprite;
   }



    void SortItem(string category)
    {
        if (itemCategories[currentIndex] == category)
        {
            score++;
            scoreText.text = "Bodycount: " + score;
            SpawnItem();
            correctSound.Play();
            nice.Play("thatsalotofdamage");
        }
        else
        {

            
            lives--;
            livesText.text = "Lives: " + lives;
            lifeLostSound.Play();
            ouch.Play("thatsalotofdamage");

            if (lives <= 0)
            {

                GameOver();
            }
            else
            {
                SpawnItem();
            }
        }
    }



    void GameOver()
    {
        
        Debug.Log("Game Over!");
        if(Timeout == true)
        {
            gameOverCanvasAlt.SetActive(true);
            BGM.Stop();
            gameoverSE.Play();


        }else
        {
             gameOverCanvas.SetActive(true);
             BGM.Stop();
             gameoverSEAlt.Play();
        }
       
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}

