using UnityEngine;

public class Playerstats : MonoBehaviour
{
    [SerializeField] private float maxhealth;

    private float currenthealth;
    private void Start()
    {
        currenthealth = maxhealth;
    }
}
