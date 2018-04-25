using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

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
            DestroyProjectile();
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Bounce"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        if (SpawnManager.killCount <= 100)
            CameraShaker.Instance.ShakeOnce(1f, 1f, .25f, .25f);
        else if (SpawnManager.killCount <= 150)
            CameraShaker.Instance.ShakeOnce(.5f, .5f, .125f, .125f);
        else if (SpawnManager.killCount <= 200)
            CameraShaker.Instance.ShakeOnce(.25f, .25f, .05f, .05f);

        GameObject obj = PoolInstances.impactPool.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);

        gameObject.SetActive(false);
    }
}
