using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoredEnergy : MonoBehaviour
{
    public GameObject storedEnergy;
    public GameObject[] storedEnergyMarkers;
    public GameObject[] storedEnergySpawnLocations;
    public GameObject[] storedEnergyMuzzleFlashes;

    int storedEnergyCount;
    
    public void StoreEnergy()
    {
        if (storedEnergyCount == 8) return;
        storedEnergyMarkers[storedEnergyCount].SetActive(true);
        storedEnergyCount++;
    }

    private void Update()
    {
        if (SpawnManager.gameover) return;
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            for(int i = 0; i < storedEnergyCount; i++)
            {
                storedEnergyMarkers[i].SetActive(false);
                storedEnergyMuzzleFlashes[i].SetActive(true);
                Instantiate(storedEnergy, storedEnergySpawnLocations[i].transform.position, storedEnergySpawnLocations[i].transform.rotation);
            }
            storedEnergyCount = 0;
        }
    }
}
