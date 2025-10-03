using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gunScript : MonoBehaviour
{
    [SerializeField] private LayerMask RandomCubesLayer;
    [SerializeField] private float damage;

    private Camera beancam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beancam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray gunray = new Ray(beancam.transform.position, beancam.transform.forward);

            if (Physics.Raycast(gunray, out RaycastHit hitInfo, 10000f, RandomCubesLayer))
            { 
               if(hitInfo.collider.gameObject.TryGetComponent(out agro CubeHit))
                {
                    CubeHit.TakeDamage ((int)damage);
                    Debug.Log(CubeHit.health);
                }
            }
        }
    }
}
