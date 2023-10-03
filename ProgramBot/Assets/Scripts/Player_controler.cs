using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        

       
    
        
        
    }

    private void FixedUpdate() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(horizontalInput,0,verticalInput);
        transform.position = transform.position + movimiento * 6.0f * Time.deltaTime;
   
    }
}
