using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator anim;

    float mouseX, mouseY;
    [Range(0.0f, 3f)]
    public float rotationSpeed = 1;
    public Transform Target, Player;
    public Transform targetTransform;

    private void Start()
    {
        anim = GetComponent<Animator>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
