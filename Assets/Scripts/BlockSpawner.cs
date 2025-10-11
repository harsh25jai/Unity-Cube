using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public float timeBetweenWaves = 1f;
    private float timeToSpawn = 2f;
    public int waveCount = 0;
    public Text scoreText;
    public Rigidbody rb; // Player
    public Text highScoreLabelText;
    public int highScore;
    private bool isFirstRun = false;
    private float tutorialTimeToSpawn = 3f;
    public float tutorialSpawnInterval = 2f;


    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");

        // Check first run once
        string firstRunStatus = PlayerPrefs.GetString("FirstRun");
        isFirstRun = string.IsNullOrEmpty(firstRunStatus);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToSpawn && rb.position.y > -1f)
        {

            if (isFirstRun)
            {   
                // Adding delay in spawning for tutorial
                if (Time.time >= tutorialTimeToSpawn)
                {
                    SpawnBlocksOnTutorial();

                    tutorialTimeToSpawn = Time.time + tutorialSpawnInterval;
                    waveCount++;
                }
            }
            else
            {
                SpawnBlocks();

                timeToSpawn = Time.time + timeBetweenWaves;
                waveCount++;
            }

            scoreText.text = waveCount.ToString();
            if (waveCount > highScore + 5)
            {
                highScoreLabelText.text = "NEW HIGH!!";
            }
        }
    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length - 1);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex == i)
            {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                Instantiate(blockPrefab, spawnPoints[i + 1].position, Quaternion.identity);
            }
        }
    }

    void SpawnBlocksOnTutorial()
    {
        if (waveCount < 10) // Left side
        {
            for (int i = 0; i < spawnPoints.Length / 2; i++) // Assuming first half of spawn points are left side
            {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
        else if (waveCount > 10 && waveCount < 20)// Right side
        {
            for (int i = spawnPoints.Length / 2; i < spawnPoints.Length; i++) // Assuming second half of spawn points are right side
            {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
        else
        {
            SpawnBlocks();
        }
    }
}
