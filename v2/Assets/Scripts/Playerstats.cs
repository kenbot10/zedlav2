using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Playerstats : MonoBehaviour
{
    [SerializeField] private float maxhealth;
    [SerializeField] private Movement movementscript;

    float currenthealth;
    bool isDead;

    public HealthBar healthBar;
    private void Start()
    {
        currenthealth = maxhealth;

        healthBar.SetSliderMax(maxhealth);
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        currenthealth -= amount;
        healthBar.SetSlider(currenthealth);
        if (currenthealth <= 0f && !isDead)
        {
            handleDeath();
        }
    }
    private void Update()
    {
        if (currenthealth > maxhealth)
        {
            currenthealth = maxhealth;
        }

        if (currenthealth <= 0)
        {
            //death
        }

        if (currenthealth <= 0)
        {
            movementscript.enabled = false;
        }
    }
    void handleDeath()
    {
        isDead = true; if (movementscript != null) movementscript.enabled = false;
    }
    public void Heal(float amount)
    {
        currenthealth += amount;
        healthBar.SetSlider(currenthealth);
    }
}
