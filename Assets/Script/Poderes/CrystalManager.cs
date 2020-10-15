using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalManager : MonoBehaviour
{
    public CrystalMenu crystalMenu;
    public PickupRequest pickupRequest;

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
        if(powerActive != null)
            fpsShooterRef.SetGem(powerActive);
    }

    // Update is called once per frame
    void Update()
    {
        //Change current gem
        if (Input.GetKeyDown(KeyCode.Q) && primaryGem != null && secondaryGem != null)
        {
            powerActive = (isPrimaryPowerSelected) ? secondaryGem : primaryGem;
            isPrimaryPowerSelected = !isPrimaryPowerSelected;
            RefreshGem();
        }

        if (Input.GetKeyDown(KeyCode.F) && pickupRequest.getGem() != null)
        {
            PickupGem(pickupRequest.getGem());
        }
    }

    public void PickupGem(GameObject gem)
    {
        if(primaryGem == null)
        {
            primaryGem = gem;
            isPrimaryPowerSelected = true;
            powerActive = primaryGem;
            RefreshGem();
        }  
        else if (secondaryGem == null)
        {
            secondaryGem = gem;
            isPrimaryPowerSelected = false;
            powerActive = secondaryGem;
            RefreshGem();
        }
        /*
        else
        {
            //Mandar para o inventario
        }  */

        pickupRequest.DestroyGroundGem();
    }

    void RefreshGem()
    {
        fpsShooterRef.SetGem(powerActive);
        crystalMenu.Selected(isPrimaryPowerSelected);
        crystalMenu.Fill();
    }

}
