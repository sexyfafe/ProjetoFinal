using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_controllTeste : MonoBehaviour
{
    private Animator anim;

    float mouseX, mouseY;
    [Range(0.0f, 3f)]
    public float rotationSpeed = 1;
    public Transform Target, Player;
    Transform chest;
    public Transform targetTransform;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
        chest = anim.GetBoneTransform(HumanBodyBones.Chest);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
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
