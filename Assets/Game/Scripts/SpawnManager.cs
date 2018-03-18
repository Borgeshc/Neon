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

    int amountToSpawn = 1;
    int checkCount;
    int killCount;

    bool spawning;

    bool gameover;

    List<GameObject> spawnObjects = new List<GameObject>();

    Coroutine spawn;

    void Update()
    {
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
    }

    public void GameOver()
    {
        gameover = true;

        foreach (GameObject go in spawnObjects)
        {
            Destroy(go);
        }

        gameOverPanel.SetActive(true);
        gameOverKillCounter.text = "Kill Counter: " + killCount;
    }
}
