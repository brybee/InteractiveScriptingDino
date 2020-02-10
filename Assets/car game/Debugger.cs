using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Debugger : MonoBehaviour
{
    public PlayerMovement playerRef;
    public bool debugging = false;
    public GameObject debugPannel;
    private InputField debugInput;
    private Text debugText;
    // Start is called before the first frame update
    void Start()
    {
        if(debugPannel == null){
            debugPannel = GameObject.Find("Debug Pannel");
        }
        if(debugPannel != null){
            debugInput = debugPannel.transform.GetChild(0).GetComponent<InputField>();
            debugText = debugPannel.transform.GetChild(1).GetComponent<Text>();
        }

        debugPannel.SetActive(false);
    }

    public void ToggleDebug(){
        debugging = !debugging;
        debugPannel.SetActive(debugging);
        
    }

    public void InputText(string input){
        if (input == "reload scene") {
            Application.LoadLevel(0);
            
        }
        if (input == "hello"){
            debugText.text = "hell o.";
        }
    }

    public void ResetPlayer(){
        playerRef.transform.position =  Vector3.up * 3;
        playerRef.transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
