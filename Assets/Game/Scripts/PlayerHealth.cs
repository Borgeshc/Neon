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
    public AudioSource playerHit;

    private void Start()
    {
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        livesText.text = "Lives: " + health;
    }

    public void TookDamage(int damage)
    {
        if (Shield.shieldActive) return;
        playerHit.Play();
        StartCoroutine(DelayHit(damage));

    }

    IEnumerator DelayHit(int damage)
    {
        yield return new WaitForSeconds(.05f);

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
