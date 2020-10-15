using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class ProjectileTut : MonoBehaviour
{
    private PhotonView myPhotonView;

    private void Start()
    {
        myPhotonView = GetComponent<PhotonView>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (myPhotonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            if (collision.gameObject.tag != "projectile")
            {
                //Prefaf de explosao de impacto
                //GameObject impact = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Impact"), collision.contacts[0].point, transform.rotation, 0);
                //Destroy( impact , 2);

                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}
