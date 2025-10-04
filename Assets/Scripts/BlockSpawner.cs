using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToSpawn && rb.position.y > -1f)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
            waveCount++;
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
}
