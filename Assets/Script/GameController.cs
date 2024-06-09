using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Image item; 
        public ItemData[] items;  
    public int lives = 3;  
    public Text livesText; 

    private int currentIndex = 0;  
    private string[] itemCategories = { "Left", "Right" };  

    public int score = 0;
    public Text scoreText;
    
    void Start()
    {
        SpawnItem();
    }

    void Update()
    {
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
        }
        else
        {

            
            lives--;
            livesText.text = "Lives: " + lives;

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
    }
}

