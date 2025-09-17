using UnityEngine;

public class healingitem : MonoBehaviour
{
    public float healAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Playerstats>().Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
