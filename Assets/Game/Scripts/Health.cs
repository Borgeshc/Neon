using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Health : MonoBehaviour
{
    public int health;

    SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
    }

    private void OnEnable()
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
        GameObject obj = PoolInstances.enemyExplosionPool.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = transform.position;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);

        if (SpawnManager.killCount <= 100)
            CameraShaker.Instance.ShakeOnce(2f, 2f, .5f, .5f);
        else if (SpawnManager.killCount <= 150)
            CameraShaker.Instance.ShakeOnce(.5f, .5f, .125f, .125f);
        else if (SpawnManager.killCount <= 200)
            CameraShaker.Instance.ShakeOnce(.25f, .25f, .05f, .05f);

        spawnManager.EnemyKilled(gameObject);
        gameObject.SetActive(false);
    }
}
