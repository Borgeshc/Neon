using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float speed;

	void Update ()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy"))
        {
            other.GetComponent<Health>().TookDamage(damage);
            Destroy(gameObject);
        }
    }
}
