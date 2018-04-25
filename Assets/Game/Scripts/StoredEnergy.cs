using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoredEnergy : MonoBehaviour
{
    public ObjectPooling storedEnergy;
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

    public void SecondaryFire()
    {
        if (SpawnManager.gameover) return;
       
        for(int i = 0; i < storedEnergyCount; i++)
        {
            storedEnergyMarkers[i].SetActive(false);
            storedEnergyMuzzleFlashes[i].SetActive(true);
            //Instantiate(storedEnergy, storedEnergySpawnLocations[i].transform.position, storedEnergySpawnLocations[i].transform.rotation);

            GameObject obj = storedEnergy.GetPooledObject();

            if (obj == null)
            {
                return;
            }

            obj.transform.position = storedEnergySpawnLocations[i].transform.position;
            obj.transform.rotation = storedEnergySpawnLocations[i].transform.rotation;
            obj.SetActive(true);
        }
        storedEnergyCount = 0;
    }
}
