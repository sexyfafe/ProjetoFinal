using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacksTeste : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] effectlvl1;
    public GameObject[] effectlvl2;
    public GameObject[] effectlvl3;
    public GameObject[] effectlvl4;
    public Animator animator;
    public GameObject position2;
    public GameObject position3;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("2")&& animator.GetBool("WandEquiped")){
            
            animator.SetInteger("SkillNumber", 2);
            animator.SetTrigger("efeito");
        }
        if (Input.GetKeyDown("3") && animator.GetBool("WandEquiped"))
        {
            animator.SetInteger("SkillNumber", 3);
            animator.SetTrigger("efeito");


        }

    }
    public void useEffect(int number)
    {
        //print(animator.GetFloat("mouseY"));
        float yyy = animator.GetFloat("mouseY") ;
        GameObject[] effect=null;
        if (animator.GetInteger("lvlWand")==1)
        {
            effect = effectlvl1;
        }else if (animator.GetInteger("lvlWand") == 2)
        {
            effect = effectlvl2;
        }else if (animator.GetInteger("lvlWand") == 3)
        {
            effect = effectlvl3;
        }else if (animator.GetInteger("lvlWand") == 4)
        {
            effect = effectlvl4;
        }
        
        Quaternion rotation = Quaternion.Euler(new Vector3(yyy, transform.eulerAngles.y, 0));
        if (number==2)
        {

            Instantiate(effect[0], position2.transform.position, rotation);
        }
        else if(number==3){
            
            Instantiate(effect[1], position2.transform.position, rotation);
        }

        animator.SetInteger("SkillNumber", 0);
    }
}
