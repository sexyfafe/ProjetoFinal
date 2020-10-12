using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class FpsShooter : MonoBehaviour
{
    public Camera cam;
   
    public Transform LHFirePoint, RHFirePoint;

    private bool isRightHand;
    private Vector3 destination;

    //Right Click Ability
    public GameObject projectile;
    public float timeToLiveRC = 4;
    public float projectileSpeed = 30;
    public float fireRateRC = 1;
    private float timeToFireRC;

    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= timeToFireRC)
        {
            timeToFireRC = Time.time + 1 / fireRateRC;
            ShootProjectile();
        }  
    }

    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay( new Vector3(0.5f , 0.5f, 0) );
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);

        if(isRightHand)
        {
            isRightHand = false;
            InstantiateProjectile(RHFirePoint);
        }
        else
        {
            isRightHand = true;
            InstantiateProjectile(LHFirePoint);
        }
    }

    void InstantiateProjectile(Transform firePoint)
    {
        GameObject projectileObj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Fireball"), firePoint.position, transform.rotation, 0 );
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

        //iTween.PunchPosition (projectileObj, new Vector3(Random.Range(-arcRange , arcRange), Random.Range(-arcRange , arcRange), 0 ), Random.Range(0.5f , 2))
        Destroy(projectileObj , timeToLiveRC);
    }
}
