using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Spin : MonoBehaviour
{
  [Tooltip("The degrees per second that the object should spin.")]
  [Range(-360,360)]
  public float spinSpeed = 60f;

  public float jumpForce = 10f;

  [Tooltip("The force that forces the cube down so it falls faster.")]
  [Range(-500,-5)]
  public float downForce = -20f;

  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI hiScoreText;

  public List<Transform> spawnPoints;
  public List<Transform> cloudSpawnPoints;
  public float timer = 0, spawnTimerMin = 0.5f, spawnTimerMax = 1.5f; 

  public float cloudSpawnmin  = 3f, cloudSpawnmax = 5f;


  public GameObject obstaclePrefab;
  public GameObject cloudPrefab;

  public GameObject deathScreen;

  public float speed = 10;
  

  

  public bool restart = false;

  private Rigidbody rb;
  private bool isGrounded = true;
  private float playerHeight;

  public float score = 0;



  public AudioSource aud;
  public AudioClip jump;
  public AudioClip score100;
  public AudioClip speedUpSound;
  public AudioClip death;


  
  

    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(SpawnCloud());
      Debug.Log("Starting");  
      rb = this.GetComponent<Rigidbody>();
      playerHeight = this.transform.localScale.y;
      hiScoreText.text = "HiScore: " + PlayerPrefs.GetFloat("HiScore").ToString("0");
      //gives player 2 secs before obsticles start spawning
      timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
      //autospin object at a certain speed around y-axis
      this.transform.Rotate(0, spinSpeed * Time.deltaTime,0);

      //if the player presses "jump" addForce to y-axis
      if(Input.GetButtonDown("Jump") && isGrounded){
        rb.AddRelativeForce(0,jumpForce,0, ForceMode.Impulse);
        aud.PlayOneShot(jump);
      }

      //if the player presses down arrow, crouch, change player hieght to 1/2
      if(Input.GetKeyDown(KeyCode.DownArrow)){
        this.transform.localScale = new Vector3(this.transform.localScale.x,playerHeight * 0.5f,this.transform.localScale.z);
      }
      //uncrouch when player lets go of down arrow
      if(Input.GetKeyUp(KeyCode.DownArrow)){
        this.transform.localScale = new Vector3(this.transform.localScale.x,playerHeight,this.transform.localScale.z);
      }

      //to make object fall faster if not grounded, add VVVV force
      if (!isGrounded){
        rb.AddForce(0,downForce, 0);
      }

      //add ten points to score every second
      score += Time.deltaTime * 10;
      //Debug.Log(score%50);

      //update scoreText with score
      scoreText.text = "Score: " + score.ToString("0");

      if(((int)score)%50 == 0 && score < 10000 && score > 1 ){
        if (score%50 < 0.13f){
          speed ++;
          Debug.Log("50");
          aud.PlayOneShot(speedUpSound);
        }
        
      }

      if (((int)score)%100 == 0 && score != 0 && score > 1){
        if (score%100 < 0.13f){
          Debug.Log("100");
          aud.PlayOneShot(score100);
        }
        
      }

      //spawn obsticles at random intervals and heights
      if(timer > 0){
        timer -= Time.deltaTime;
      }
      else{
        SpawnObsticle();
        
      }

      if (restart){
        score = 0;
        speed = 10;
        restart = false;
      }

      

      

    }

    void SpawnObsticle(){
      timer = Random.Range(spawnTimerMin, spawnTimerMax);
      Instantiate(obstaclePrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
    }
    IEnumerator SpawnCloud(){
      while (true){
        Instantiate(cloudPrefab, cloudSpawnPoints[Random.Range(0, cloudSpawnPoints.Count)].position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(cloudSpawnmin,cloudSpawnmax));

      }
      
    }

    void OnTriggerEnter(Collider other){
      if (other.gameObject.name ==  "Platform"){
        isGrounded = true;
      }

      if (other.gameObject.tag == "Obstacle"){
        Time.timeScale = 0;
        if( score > PlayerPrefs.GetFloat("HiScore")){
          hiScoreText.text = "HiScore: " + score.ToString("0");
          PlayerPrefs.SetFloat("HiScore", score);
          
        }
        deathScreen.SetActive(true);
        aud.PlayOneShot(death);
        
      }
    }
    void OnTriggerExit(Collider other){
      if (other.gameObject.name ==  "Platform"){
        isGrounded = false;
      }
    }
}
