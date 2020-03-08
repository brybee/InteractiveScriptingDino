using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBox : MonoBehaviour
{
    
    public int health = 100;
    public Text healthTxt;
    // Start is called before the first frame update
    void Start()
    {
        healthTxt.text = "health = " + health;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("EnemyBullet")){
            health -=10;
            Destroy(other.gameObject);
            healthTxt.text = "health = " + health;
        }
        if (other.CompareTag("Health")){
            health += 20;
            Destroy(other.gameObject);
            healthTxt.text = "health = " + health;
        }

    }
}
