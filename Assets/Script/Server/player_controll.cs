using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


public class player_controll : MonoBehaviour
{
    [SerializeField] PhotonView myPhotonView;
    float mouseX, mouseY;
    [Range(0.0f, 3f)]
    public float rotationSpeed = 1;
    public Transform Target, Player;
    public CharacterController controller;
    public Camera m_Camera;

    void Start()
    {
        myPhotonView = GetComponent<PhotonView>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        m_Camera = GetComponentInChildren<Camera>();

        if (myPhotonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            //Destroy(m_Camera);
            m_Camera.enabled = false;

            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*-0.1f);

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        if (mouseY- Input.GetAxis("Mouse Y") * rotationSpeed>-30&& mouseY - Input.GetAxis("Mouse Y") * rotationSpeed<30)
        {
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        }

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
       
    }

}
