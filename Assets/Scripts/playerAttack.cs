using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire1")> 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        myAnim.SetTrigger("attacking");
    }
}
