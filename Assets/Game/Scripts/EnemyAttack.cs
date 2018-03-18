using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyAttack : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            other.GetComponent<PlayerHealth>().TookDamage(1);
            Instantiate(explosion, transform.position, Quaternion.identity);
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1);
            Destroy(gameObject);
        }
    }
}
