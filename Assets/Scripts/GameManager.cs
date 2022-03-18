using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public BoxCollider foodSpawnBounds;
    public GameObject[] foodItems;
    public float gameTime = 60;

    public TMP_Text timerText;

    private float timer = 0;
    private int score = 0;
    private bool isGameRunning = false;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //StartGame();
        timerText.text = "Time : " + gameTime;
    }

    public bool isGame()
    {
        return isGameRunning;
    }

    public int getScore()
    {
        return score;
    }

    public int getTime()
    {
        return Mathf.FloorToInt(timer); // eg: if timer = 54.89 -> 54
    }

    public void AddScore()
    {
        score++;
    }

    public void SpawnFoodItem()
    {
        GameObject randomFood = foodItems[Random.Range(0, foodItems.Length)];

        float x = Random.Range(foodSpawnBounds.bounds.min.x, foodSpawnBounds.bounds.max.x);
        float y = Random.Range(foodSpawnBounds.bounds.min.y, foodSpawnBounds.bounds.max.y);
        float z = Random.Range(foodSpawnBounds.bounds.min.z, foodSpawnBounds.bounds.max.z);

        Instantiate(randomFood, new Vector3(x, y, z), Quaternion.identity);
    }

    public void StartGame()
    {
        timer = gameTime;
        score = 0;
        isGameRunning = true;
    }

    void GameOver()
    {
        isGameRunning = false;
    }

    private void Update()
    {
        if(timer > 0 && isGameRunning)
        {
            timer -= Time.deltaTime;

            // Updating the game time
            timerText.text = "Time : " + getTime();

            Debug.Log(timer);
        }
        else
        {
            //Game Over!
            GameOver();
        }

        
    }
}
