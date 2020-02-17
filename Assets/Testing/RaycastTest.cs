using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = this.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.down, 2f)){
            rb.isKinematic = true;
            Debug.DrawRay(transform.position, Vector3.down * 2,Color.green);
        }
        else{
             Debug.DrawRay(transform.position, Vector3.down * 2,Color.red);
        }
        
    }
}
