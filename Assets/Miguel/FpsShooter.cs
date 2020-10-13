using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class FpsShooter : MonoBehaviour
{
    public Camera cam;
   
    public Transform LHFirePoint, RHFirePoint;

    [SerializeField] PhotonView myPhotonView;
    private bool isRightHand;
    private Vector3 destination;
    private Animator animator;

    //Right Click Ability
    public string projectileName;
    public GameObject projectile;
    public float timeToLiveRC = 4;
    public float projectileSpeed = 30;
    public float fireRateRC = 1;
    private float timeToFireRC;


    private void Start()
    {
        animator = GetComponent<Animator>();

        myPhotonView = GetComponent<PhotonView>();
        if (myPhotonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            Destroy(this);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= timeToFireRC)
        {
            timeToFireRC = Time.time + 1 / fireRateRC;
            animator.SetTrigger("RightClickAttack");
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
        GameObject projectileObj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", projectileName), firePoint.position, transform.rotation, 0 );
        //var projectileObj = Instantiate(projectile, firePoint.position, transform.rotation);
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

        //iTween.PunchPosition (projectileObj, new Vector3(Random.Range(-arcRange , arcRange), Random.Range(-arcRange , arcRange), 0 ), Random.Range(0.5f , 2))
        StartCoroutine(DestroyAfterTime(timeToLiveRC , projectileObj));
    }

    private IEnumerator DestroyAfterTime(float time , GameObject projectileObj)
    {
        yield return new WaitForSeconds(time);
        PhotonNetwork.Destroy(projectileObj);
    }
}
