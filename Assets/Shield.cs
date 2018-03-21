using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject[] shieldCharges;
    public GameObject shield;
    public Animator shieldAnimator;

    int shieldChargeCount;

    public static bool shieldActive;

    private void Start()
    {
        shieldChargeCount = shieldCharges.Length;
    }

    private void Update()
    {
        if(!shieldActive && Input.GetKeyDown(KeyCode.Space) && shieldChargeCount > 0)
        {
            shieldActive = true;
            shieldCharges[shieldChargeCount - 1].SetActive(false);
            shieldChargeCount--;
            shield.SetActive(true);
            shieldAnimator.SetBool("Grow", true);
            StartCoroutine(ShieldActive());
        }
    }

    IEnumerator ShieldActive()
    {
        yield return new WaitForSeconds(3);
        shieldActive = false;
        shieldAnimator.SetBool("Grow", false);
        yield return new WaitForSeconds(.5f);
        shield.SetActive(false);
    }
}
