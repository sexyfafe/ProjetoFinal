using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Photon.Pun;

public class PhotonViewDisable : MonoBehaviour
{
    private PhotonView myPhotonView;

    // Start is called before the first frame update
    void Start()
    {
        myPhotonView = GetComponent<PhotonView>();
        if (myPhotonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            gameObject.SetActive(false);
        }
    }
}
