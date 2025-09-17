using UnityEngine;

public class Playerstats : MonoBehaviour
{
    [SerializeField] private float maxhealth;

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
    }
    public void Heal(float amount)
    {
        currenthealth += amount;
        healthBar.SetSlider(currenthealth);
    }
}
