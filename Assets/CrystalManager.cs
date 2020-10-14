using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalManager : MonoBehaviour
{
    public CrystalMenu crystalMenu;

    //Power that is active
    private GameObject powerActive;
    private bool isPrimaryPowerSelected = true;

    public GameObject primaryGem = null;
    public GameObject secondaryGem = null;

    private FpsShooter fpsShooterRef;
    

    private void Start()
    {
        fpsShooterRef = transform.GetComponent<FpsShooter>();
        powerActive = primaryGem;

        //Set active Gem
        fpsShooterRef.SetGem(powerActive);
    }

    // Update is called once per frame
    void Update()
    {
        //Change current gem
        if (Input.GetKeyDown(KeyCode.Q))
        {
            powerActive = (isPrimaryPowerSelected) ? secondaryGem : primaryGem;
            isPrimaryPowerSelected = !isPrimaryPowerSelected;

            fpsShooterRef.SetGem(powerActive);

            crystalMenu.Selected(isPrimaryPowerSelected);
        }
    }
}
