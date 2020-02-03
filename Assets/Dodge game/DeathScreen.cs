using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{

    public Spin script;
    public GameObject screen;

    public GameObject[] obstacles;
    public void StartAgain(){
        Time.timeScale = 1;
        script.restart = true;
        screen.SetActive(false);
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject obstacle in obstacles){
            Destroy(obstacle);
        }       
    }
}
