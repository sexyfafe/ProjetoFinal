﻿using System.Collections;
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
    public float timeToLiveRC = 4;
    public float projectileSpeed = 30;
    public float fireRateRC = 1;
    private float timeToFireRC;

    //Selected Gem
    private Poderes selectedGem;

    void Start()
    {
        animator = GetComponent<Animator>();

        myPhotonView = GetComponent<PhotonView>();
    }


    // Update is called once per frame
    void Update()
    {
        if (myPhotonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= timeToFireRC && selectedGem != null)
            {
                timeToFireRC = Time.time + 1 / fireRateRC;
                animator.SetTrigger("RightClickAttack");
            }
            else if (Input.GetKeyDown(KeyCode.E) && selectedGem != null)
            {
                MediumAttack();
            }
        }
    }

    void MediumAttack()
    {
        Spell mediumSpell = selectedGem.GetMediumAttack();

        Debug.Log(mediumSpell.GetSpellPosition());
        Vector3 spawnPostion = transform.position + transform.forward * mediumSpell.GetSpellPosition();

        GameObject mediumAttack = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", mediumSpell.GetSpellString()), spawnPostion, Quaternion.identity, 0);

        StartCoroutine(DestroyAfterTime(mediumAttack.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length, mediumAttack));
    }

    void ShootProjectile()
    {
        if (myPhotonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                destination = hit.point;
            else
                destination = ray.GetPoint(1000);

            if (selectedGem != null)
            {
                if (isRightHand)
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
        }
    }

    void InstantiateProjectile(Transform firePoint)
    {
        if (myPhotonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            GameObject projectileObj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", selectedGem.GetBasicAttack()), firePoint.position, transform.rotation, 0);
            projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

            if(selectedGem.basicAttack_Cast != "")
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", selectedGem.basicAttack_Cast), firePoint.position, transform.rotation, 0);

            //iTween.PunchPosition (projectileObj, new Vector3(Random.Range(-arcRange , arcRange), Random.Range(-arcRange , arcRange), 0 ), Random.Range(0.5f , 2))
            StartCoroutine(DestroyAfterTime(timeToLiveRC, projectileObj));
        }
    }

    private IEnumerator DestroyAfterTime(float time, GameObject projectileObj)
    {
        yield return new WaitForSeconds(time);
        if(projectileObj != null)
            PhotonNetwork.Destroy(projectileObj);
    }

    public void SetGem(GameObject gem)
    {
        selectedGem = gem.GetComponent<Poderes>();
    }
}
