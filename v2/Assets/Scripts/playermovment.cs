using UnityEngine;
using UnityEngine.InputSystem;

public class playermovment : MonoBehaviour
{ 
  
    
    private void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            Debug.Log("Up");
        }
    }
}
