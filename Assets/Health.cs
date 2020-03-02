using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject bod;
    public int health = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0){
            Destroy(bod);
        }
        
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Bullet")){
            health -= 10;

        }

    }
}
