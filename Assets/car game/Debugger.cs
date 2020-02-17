using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Debugger : MonoBehaviour
{
    public PlayerMovement playerRef;
    public KeyCounter playerKeys;
    public bool debugging = false;
    public GameObject debugPannel;
    private InputField debugInput;
    private Text debugText;
    public Text keyCount;

    public Transform spawn1, spawn2, spawn3;
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
        else if (input == "hello"){
            debugText.text = "hell o.";
        }
        else if (input == "TimeSlow"){
            Time.timeScale = 0.5f;
            debugText.text = "SlowMo";
        }
        else if (input == "TimeFreeze"){
            Time.timeScale = 0f;
            debugText.text = "Frozen";
        }
        else if (input == "TimeSpeed"){
            Time.timeScale = 2f;
            debugText.text = "Double Speed!";
        }
        else if (input == "TimeNorm"){
            Time.timeScale = 1f;
            debugText.text = "Speed Back to normal";
        }
        else if (input.Contains("K+")){
            string[] letters = input.Split(' ');
            int num = int.Parse(letters[1]);
            Debug.Log(num);
            playerKeys.keys = num;
            keyCount.text = "Keys = " + playerKeys.keys;
            debugText.text = num + " Keys Added!";
        }
        
        else if (input.Contains("PlayerSpeed")){
            string[] letters = input.Split(' ');
            float num = float.Parse(letters[1]);
            Debug.Log(num);
            playerRef.speed = num;
            debugText.text = "Speed changed to " + num;
            
        }
        else if (input.Contains("PlayerRot")){
            string[] letters = input.Split(' ');
            float num = float.Parse(letters[1]);
            Debug.Log(num);
            playerRef.rotSpeed = num;
            debugText.text = "Rotation speed changed to " + num;
        }
        else if (input.Contains("CP")){
            string[] letters = input.Split(' ');
            int num = int.Parse(letters[1]);
            Debug.Log(num);
            CheckPoints(num);
            debugText.text = "teleported to checkpoint " + num;
        }
        else if (input == "Help"){
            debugText.text = "CP num = checkpoints,  PlayerRot num/PlayerSpeed num = changing the players speed settings, K+ num = choose number of keys, Key = the amount you have, TimeSlow = half speed, TimeSpeed = double speed, TimeFreeze = frozen/paused, TimeNorm = normal time, reload scene = complete restart";

        
        }
        else if (input == "Clear"){
            debugText.text = "";

        }
        else if (input == "@Key"){
            debugText.text = "Keys = " + playerKeys.keys;
        }
        else{
            debugText.text = "That is not a command if you need help type Help";
            
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
    void CheckPoints(int check){
        if (check == 1){
            playerRef.transform.position =  spawn1.position;
            playerRef.transform.rotation = spawn1.rotation;
        }
        if (check == 2){
            playerRef.transform.position =  spawn2.position;
            playerRef.transform.rotation = spawn2.rotation;
        }
        if (check == 3){
            playerRef.transform.position =  spawn3.position;
            playerRef.transform.rotation = spawn3.rotation;
        }
        else{
            debugText.text = "That isn't  checkpoint";
        }

    }
}
