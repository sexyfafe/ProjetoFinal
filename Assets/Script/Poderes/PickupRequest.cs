using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class PickupRequest : MonoBehaviour
{
    public CrystalManager crystalManager;

    private GameObject selectedGem;

    public void DestroyGroundGem()
    {
        Destroy(selectedGem.gameObject);
        selectedGem = null;
    }

    public GameObject getGem()
    {
        return selectedGem;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "interactable")
        {
            selectedGem = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == selectedGem)
        {
            selectedGem = null;
        }   
    }
}
