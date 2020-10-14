using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalMenu : MonoBehaviour
{
    private GameObject primarySlot;
    private GameObject secondarySlot;

    public CrystalManager crystalManager;

    private void Start()
    {
        primarySlot = transform.GetChild(0).gameObject;
        secondarySlot = transform.GetChild(1).gameObject;

        Fill();
        Selected(true);
    }

    void Fill()
    {
        primarySlot.GetComponent<Image>().sprite = crystalManager.primaryGem.GetComponent<Poderes>().powerImage;
        secondarySlot.GetComponent<Image>().sprite = crystalManager.secondaryGem.GetComponent<Poderes>().powerImage;
    }

    public void Selected(bool isFirst)
    {
        if (isFirst)
        {
            primarySlot.transform.GetChild(0).GetComponent<Image>().enabled = true;
            secondarySlot.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
        else
        {
            primarySlot.transform.GetChild(0).GetComponent<Image>().enabled = false;
            secondarySlot.transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
    }
}
