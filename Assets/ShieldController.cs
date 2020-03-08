using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public float maxSize = 8;
    public float minSize = 4;
    public float timeToRecharge = 2;
    public float timeToDepleat = 1;
    public float timer = 0;
    public bool rbtnIsDown= false;

    MeshRenderer rend;

    Collider col;
    // Start is called before the first frame update
    void Start()
    {
       rend = this.GetComponent<MeshRenderer>();
       col = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > timeToDepleat && !(timer > timeToRecharge)){
            if(rbtnIsDown){
                rend.enabled = true;
                col.enabled = true;
                this.transform.localScale = Vector3.one * timer * minSize;
                timer -= Time.deltaTime;

            }
            else{
                timer += Time.deltaTime;
                rend.enabled = false;
                col.enabled = false;
            }

        }
        else if (timer < 2){
            timer += Time.deltaTime;
            rend.enabled = false;
            col.enabled = false;
        }
        else if(timer > 2){
            timer = 2;
        }










       /* if(rbtnIsDown){
            if (timer > timeToRecharge){

            }
            else if(timer > timeToDepleat){
                //turn shield on
                rend.enabled = true;
                col.enabled = true;
                this.transform.localScale = Vector3.one * timer * minSize;
                timer -= timer.deltaTime;
            }
            
            //otherwise recharge shield
        }
        else{
            //recharge Shield
        } */
    }
}
