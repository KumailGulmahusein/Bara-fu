using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public GameObject playerDeathEffects;
    public Slider enemyHPBar;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyHPBar.maxValue = currentHealth;
        enemyHPBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        enemyHPBar.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyHPBar.value = currentHealth;
        
        animator.SetTrigger("Hurt");
        Instantiate(playerDeathEffects);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("Dead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        enemyHPBar.gameObject.SetActive(false);
    }
}
