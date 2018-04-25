using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerInput : MonoBehaviour
{
    float horizontal;
    float vertical;

    float horizontal2;
    float vertical2;

    Controls controls;
    string saveData;

    Movement movement;
    Shooting shooting;
    Shield shield;
    StoredEnergy storedEnergy;

    private void Start()
    {
        movement = GetComponent<Movement>();
        shooting = GetComponent<Shooting>();
        shield = GetComponent<Shield>();
        storedEnergy = GameObject.Find("GameManager").GetComponent<StoredEnergy>();
    }

    void Update ()
    {
        movement.UpdateInput(controls.Move.X, controls.Move.Y);

        if(controls.Shield)
        {
            shield.ActivateShield();
        }

        if(controls.SecondaryFire)
        {
            storedEnergy.SecondaryFire();
        }

        if(controls.Fire)
        {
            shooting.Fire();
        }
        horizontal2 = controls.Look.X;
        vertical2 = controls.Look.Y;
	}

    void OnEnable()
    {
        controls = Controls.CreateWithDefaultBindings();
    }

    void OnDisable()
    {
        controls.Destroy();
    }

    void SaveBindings()
    {
        saveData = controls.Save();
        PlayerPrefs.SetString("Bindings", saveData);
    }

    void LoadBindings()
    {
        if (PlayerPrefs.HasKey("Bindings"))
        {
            saveData = PlayerPrefs.GetString("Bindings");
            controls.Load(saveData);
        }
    }
}
