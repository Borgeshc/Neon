using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPosition;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectile, spawnPosition.position, spawnPosition.rotation);
        }
    }
}
