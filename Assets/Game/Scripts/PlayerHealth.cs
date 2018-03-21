using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public Text livesText;

    public GameObject explosion;

    SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        livesText.text = "Lives: " + health;
    }

    public void TookDamage(int damage)
    {
        if (Shield.shieldActive) return;
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
        livesText.text = "Lives: " + health;

        if (health <= 0)
        {
            Died();
        }
    }

    void Died()
    {
        spawnManager.GameOver();
        Destroy(gameObject);
    }
}
