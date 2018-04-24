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
        CameraShaker.Instance.ShakeOnce(1f, 1f, .025f, .25f);

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
