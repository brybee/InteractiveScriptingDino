using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherBox : MonoBehaviour
{
    public Transform spawn;
    public int rDir = 15;

    public float force = 20;

    public EnemyTurretTwo et2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Launch());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Launch(){
        while(true){
            
            GameObject rock = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Rigidbody rb = rock.AddComponent<Rigidbody>();
            rock.GetComponent<Renderer>().material.color = Random.ColorHSV();
            rock.transform.position = spawn.position;
            rock.transform.Rotate(Random.Range(-rDir, rDir), Random.Range(-rDir, rDir), Random.Range(-rDir, rDir));
            rb.AddRelativeForce(rock.transform.up * force, ForceMode.Impulse);
            rock.gameObject.tag = "Target";
            et2.target = rb;
            
            yield return new WaitForSeconds(4);
            
        }
    }
}
