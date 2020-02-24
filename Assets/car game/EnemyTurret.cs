using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public Transform player;
    public Transform bulletSpawn;
    public Rigidbody bulletPrefab;
    public float bulletSpeed = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootWait());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        
        
    }

    void Shoot(){
        Rigidbody bullet = Instantiate ( bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(bullet.gameObject, 5);
        
    }

    IEnumerator ShootWait(){
        while(true){
            yield return new WaitForSeconds(0.75f);
            Shoot();
        }
        

    }
}
