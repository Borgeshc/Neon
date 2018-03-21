using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnFrequency;
    public int spawnOffset;
    public int killsBeforeIncrease;
    public Text killCounter;
    public GameObject gameOverPanel;
    public Text gameOverKillCounter;
    public Text highScoreText;
    public AudioSource highScoreSource;

    StoredEnergy storedEnergy;

    int amountToSpawn = 1;
    int checkCount;
    int killCount;

    bool spawning;

    public static bool gameover;

    List<GameObject> spawnObjects = new List<GameObject>();

    Coroutine spawn;
    int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        gameover = false;
        storedEnergy = GetComponent<StoredEnergy>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha4) && Input.GetKeyDown(KeyCode.Alpha5) && Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            print("High Score Reset");
        }

        if(gameover)
        {
            if (spawn != null)
                StopCoroutine(spawn);
            return;
        }

        if(!spawning)
        {
            spawning = true;
           spawn = StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        for(int i = 0; i < amountToSpawn; i++)
        {
            int randomX = Random.Range(-spawnOffset, spawnOffset);
            int randomZ = Random.Range(-spawnOffset, spawnOffset);

            if (randomX < 0)
                randomX -= spawnOffset;
            else if (randomX > 0)
                randomX += spawnOffset;

            if (randomZ < 0)
                randomZ -= spawnOffset;
            else
                randomZ += spawnOffset;

            Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);

           GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            spawnObjects.Add(newObject);
        }
        yield return new WaitForSeconds(spawnFrequency);
        spawning = false;
    }

    public void EnemyKilled(GameObject enemy)
    {
        if(spawnObjects.Contains(enemy))
        {
            spawnObjects.Remove(enemy);
        }

        killCount++;
        checkCount++;

        killCounter.text = "Kill Count: " + killCount;

        if (checkCount == killsBeforeIncrease)
        {
            checkCount = 0;
            amountToSpawn++;
        }

        storedEnergy.StoreEnergy();
    }

    public void GameOver()
    {
        if (gameover) return;
        gameover = true;

        foreach (GameObject go in spawnObjects)
        {
            Destroy(go);
        }

        gameOverPanel.SetActive(true);
        gameOverKillCounter.text = "Kill Counter: " + killCount;

        if(killCount > highScore)
        {
            highScore = killCount;
            StartCoroutine(NewHighScore());
        }
        else
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    IEnumerator NewHighScore()
    {
        highScoreSource.Play();
        highScoreText.text = "New High Score!";
        yield return new WaitForSeconds(2);
        highScoreText.text = "High Score: " + highScore;
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}
