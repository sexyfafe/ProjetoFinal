using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class SpawnCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Cube"), transform.position, transform.rotation, 0);
    }


}
