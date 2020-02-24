using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretTwo : MonoBehaviour
{
    public Rigidbody target;
    public Transform bulletSpawn;
    public float bulletSpeed = 50f;

    [Range(0,1)]
    public float leadAmount = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.LookAt(target.transform.position +(target.velocity * leadAmount));
        //Debug.DrawRay(bulletSpawn.position, bulletSpawn.forward * 50, Color.cyan, 1);
        
    }
    IEnumerator Fire(){
        while(true){
            
            this.transform.LookAt(target.transform.position);
            RaycastHit hit;
           
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 50f)){
                if(hit.transform.gameObject.CompareTag("Target")){
                    Debug.Log("Target locked");
                    this.transform.LookAt(target.transform.position +(target.velocity * leadAmount));
                    GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    bullet.transform.position = bulletSpawn.position;
                    bullet.transform.rotation = bulletSpawn.rotation;
                    bullet.transform.localScale = Vector3.one * 0.2f;
                    Rigidbody rb = bullet.AddComponent<Rigidbody>();
                    rb.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
                    Debug.DrawRay(bulletSpawn.position, bulletSpawn.forward * 50, Color.cyan, 1);
                    
                }
                else{
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50,Color.green, 0.5f);
                    Debug.Log("hit something");
                }
                
            }
            else{
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50,Color.red, 0.5f);
                Debug.Log("no");
            }
            
            yield return new WaitForSeconds(0.5f);
        }
    }
   
}
