using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Damage : MonoBehaviour
{
    public int damage;
    public GameObject impact;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            Instantiate(impact, transform.position, transform.rotation);
            other.GetComponent<Health>().TookDamage(damage);
            Destroy(gameObject);
        }
    }
}
