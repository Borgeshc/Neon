using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public ObjectPooling projectile;
    public Transform spawnPosition;
    public GameObject muzzleFlash;

    public void Fire()
    {
        muzzleFlash.SetActive(true);

        GameObject obj = projectile.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = spawnPosition.position;
        obj.transform.rotation = spawnPosition.rotation;
        obj.SetActive(true);
    }
}
