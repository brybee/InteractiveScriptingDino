using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    
    public float obstaclespeed = 10;
    public Spin spin;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player =GameObject.Find("Player");
        spin = player.GetComponent<Spin>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-spin.speed * Time.deltaTime, 0, 0);
    }
}
