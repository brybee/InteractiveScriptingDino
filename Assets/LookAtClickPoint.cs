using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtClickPoint : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 0.5f)]
    float interval = 0.1f;

    public Transform bulletSpawn;
    public Rigidbody bulletPrefab;

    [SerializeField]
    [Range(20f, 100f)]
    public float bulletSpeed = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LookAtMousePoint());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Bam!");
            Debug.DrawRay(bulletSpawn.transform.position, transform.TransformDirection(Vector3.forward) * 10,Color.magenta, 1f);
            Shoot();
            
        }
    }

    void Shoot(){
        Rigidbody bullet = Instantiate ( bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(bullet.gameObject, 5);

    }

    IEnumerator LookAtMousePoint(){
        while(true){
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, 5)){
                transform.LookAt(hit.point);
            }
            yield return new WaitForSeconds(interval);
        }

    }
}
