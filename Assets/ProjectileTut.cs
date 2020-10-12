using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class ProjectileTut : MonoBehaviour
{
    private bool collided = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "projectile" && !collided)
        {
            collided = true;

            //Prefaf de explosao de impacto
            //GameObject impact = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Impact"), collision.contacts[0].point, transform.rotation, 0);
            //Destroy( impact , 2);

            Destroy(gameObject);
        }
    }
}
