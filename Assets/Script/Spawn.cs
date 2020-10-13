using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float lifetime = 2;

    void OnTriggerEnter()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(lifetime);
        GetComponent<MeshRenderer>().enabled = true;
    }
}
