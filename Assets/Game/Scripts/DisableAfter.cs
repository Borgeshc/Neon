using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfter : MonoBehaviour
{
    public float disableAfter = .25f;
    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(disableAfter);
        gameObject.SetActive(false);
    }
}
