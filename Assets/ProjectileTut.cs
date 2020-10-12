using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class ProjectileTut : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Bateu   " + collision.transform.tag);
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "projectile")
        {
            //Prefaf de explosao de impacto
            //GameObject impact = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Impact"), collision.contacts[0].point, transform.rotation, 0);
            //Destroy( impact , 2);

            Destroy(gameObject);
        }
    }
}
