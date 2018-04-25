using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyAttack : MonoBehaviour
{
    SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            other.GetComponent<PlayerHealth>().TookDamage(1);

            if(Shield.shieldActive)
            {
                GameObject obj = PoolInstances.enemyShieldHitExplosionPool.GetPooledObject();

                if (obj == null)
                {
                    return;
                }

                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
                obj.SetActive(true);
            }

            if (SpawnManager.killCount <= 100)
                CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1);
            else if (SpawnManager.killCount <= 150)
                CameraShaker.Instance.ShakeOnce(1f, 1f, .25f, .25f);
            else if (SpawnManager.killCount <= 200)
                CameraShaker.Instance.ShakeOnce(.25f, .25f, .05f, .05f);
            spawnManager.EnemyKilled(gameObject);
            gameObject.SetActive(false);
        }
    }
}
