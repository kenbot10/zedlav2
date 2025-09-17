using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage;
    void Start()
    {
        Destroy(gameObject, 10f); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Playerstats>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
