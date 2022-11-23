using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    Animator myAnimator;
    public GameObject playerDeathEffects;

    public float maxHealth = 100;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            die();
        }
    }
    void die()
    {
        Instantiate(playerDeathEffects, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
