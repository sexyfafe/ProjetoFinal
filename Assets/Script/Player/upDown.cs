using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDown : MonoBehaviour
{
    public Animator animator;
    public Transform Player;
    public float offSetCimaBaixo = 14;
    public float offSetCentro=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position =   new Vector3(transform.position.x, Player.position.y+ offSetCentro - animator.GetFloat("mouseY") / offSetCimaBaixo, transform.position.z) ;
    }
}
