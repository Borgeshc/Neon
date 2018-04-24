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

        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1);
        spawnManager.EnemyKilled(gameObject);
        gameObject.SetActive(false);
    }
}
