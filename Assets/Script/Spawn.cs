using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    private float lifetime = 2;
    [SerializeField] PhotonView myPhotonView;

    void Start()
    {
        myPhotonView = GetComponent<PhotonView>();
        if (myPhotonView.IsMine == false && PhotonNetwork.IsConnected == true)
            Destroy(this);
    }


    void OnTriggerEnter()
    {
        myPhotonView.RPC("SpawnTimer", RpcTarget.All);
    }

    [PunRPC]
    void SpawnTimer()
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
