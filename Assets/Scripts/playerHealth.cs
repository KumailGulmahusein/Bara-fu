using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public GameObject playerDeathEffects;

    public float maxHealth = 100;
    float currentHealth;
    playerController controlMovement;

    //HUD Variables
    public Slider healthBar;
    public Image damageScreen;

    bool damaged = false;
    Color damagedColour = new Color(0f, 0f, 0f, 0.5f);
    float smoothColour = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        controlMovement = GetComponent<playerController>();

        //HUD Initialization
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageScreen.color = damagedColour;
        }else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
        }
        damaged = false;
    }
    public void TakeDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        healthBar.value = currentHealth;
        damaged = true;

        if (currentHealth <= 0)
        {
            die();
        }
    }
    public void die()
    {
        Instantiate(playerDeathEffects, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
