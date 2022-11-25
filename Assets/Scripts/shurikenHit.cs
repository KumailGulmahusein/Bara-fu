using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenHit : MonoBehaviour
{

    public int weaponDamage;

    projectileController myPC;

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponent<projectileController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hittable"))
        {
            myPC.removeForce();
            Destroy(gameObject);
            if(other.tag == "Enemy")
            {
                Enemy hurtEnemy = other.gameObject.GetComponent<Enemy>();
                hurtEnemy.TakeDamage(weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hittable"))
        {
            myPC.removeForce();
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                Enemy hurtEnemy = other.gameObject.GetComponent<Enemy>();
                hurtEnemy.TakeDamage(weaponDamage);
            }
        }
    }
}
