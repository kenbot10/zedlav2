using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Playerstats : MonoBehaviour
{
    [SerializeField] private float maxhealth;
    [SerializeField] private Movement movementscript;

    private float currenthealth;

    public HealthBar healthBar;
    private void Start()
    {
        currenthealth = maxhealth;

        healthBar.SetSliderMax(maxhealth);
    }

    public void TakeDamage(float amount)
    {
        currenthealth -= amount;
        healthBar.SetSlider(currenthealth);
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
    public void Heal(float amount)
    {
        currenthealth += amount;
        healthBar.SetSlider(currenthealth);
    }
}
