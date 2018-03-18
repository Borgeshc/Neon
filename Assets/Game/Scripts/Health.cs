using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Health : MonoBehaviour
{
    public int health;
    public GameObject explosion;

    SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
    }

    public void TookDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Died();
        }
    }

    void Died()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1);
        spawnManager.EnemyKilled(gameObject);
        Destroy(gameObject);
    }
}
