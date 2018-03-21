using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyAttack : MonoBehaviour
{
    public GameObject explosion;
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
                Instantiate(explosion, transform.position, transform.rotation);

            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1);

            spawnManager.EnemyKilled(gameObject);
            Destroy(gameObject);
        }
    }
}
