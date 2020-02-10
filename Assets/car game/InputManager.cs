using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerMovement playerRef;
    // Start is called before the first frame update
    void Start()
    {
        if(playerRef == null) playerRef = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRef.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }
}
