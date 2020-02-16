using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCounter : MonoBehaviour
{
    public int keys = 0;
    public GameObject ramp1, ramp2, ramp3;
    public Text keyCount;

    // Start is called before the first frame update
    void Start()
    {
        keyCount.text = "Keys = " + keys;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keys == 3){
            ramp1.SetActive(true);
        }
        if (keys == 6){
            ramp2.SetActive(true);
        }
        if (keys == 9){
            ramp3.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Key")){
            Destroy (other.gameObject);
            keys++;
            keyCount.text = "Keys = " + keys;

        }
        
    }
}
