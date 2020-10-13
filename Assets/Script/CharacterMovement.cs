using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CharacterMovement : MonoBehaviour
{
    private Animator anim;
    [SerializeField] PhotonView myPhotonView;
    float mouseX, mouseY;
    [Range(0.0f, 3f)]
    public float rotationSpeed = 1;
    public Transform Target, Player;
    public Transform targetTransform;
    public Camera m_Camera;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        m_Camera = GetComponentInChildren<Camera>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        myPhotonView = GetComponent<PhotonView>();
        if (myPhotonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            m_Camera.GetComponent<AudioListener>().enabled = false;
            m_Camera.enabled = false;
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        if (mouseY - Input.GetAxis("Mouse Y") * rotationSpeed > -30 && mouseY - Input.GetAxis("Mouse Y") * rotationSpeed < 30)
        {
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            anim.SetFloat("mouseY", mouseY);

        }

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    private void OnAnimatorIK()
    {
        //Look at target IK
        anim.SetLookAtWeight(1);
        anim.SetLookAtPosition(targetTransform.position);
    }
}
