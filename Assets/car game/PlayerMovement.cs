using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f, 
                rotSpeed = 20f,
                chosenDrag = 0.5f,
                downForce = 10f;
    private bool isGrounded;


    void Start(){
        rb = this.GetComponent<Rigidbody>();
    }

    public void Move(float h, float v){

        if(isGrounded){
            //horizontal rotates the car around the y axis
            //vertical moves the car forwards and back on the z axis
            rb.AddRelativeForce(0,0,v * speed * Time.deltaTime);
            rb.AddRelativeTorque(0,h * rotSpeed * Time.deltaTime ,0);
            rb.drag = chosenDrag;

        }else{
            rb.drag = 0f;
            rb.AddForce(0, -downForce, 0);
        }
        


    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }

    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Restart")){
            SceneManager.LoadScene(0);
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }

        
    }
}
