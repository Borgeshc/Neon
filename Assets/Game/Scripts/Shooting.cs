using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPosition;
    public GameObject muzzleFlash;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            muzzleFlash.SetActive(true);
            Instantiate(projectile, spawnPosition.position, spawnPosition.rotation);
        }
    }
}
