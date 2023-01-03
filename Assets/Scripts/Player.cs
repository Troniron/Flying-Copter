using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public static Player instance;
    public  float score=0.0f;
    [SerializeField]
    private Text scoretext,score2,Highscore,AnotherHighscore,highscore3;
    private Rigidbody2D rb;
    [SerializeField]
    private int addforce=500;
    [SerializeField]
    private GameObject Scoretextmian,scoreontent, getready,Reset, startbutton,gameover,restartbutton,Gold,Silvar,Bronze,Flight;
    [SerializeField]
    private AudioClip Clip1,Clip2;
    [SerializeField]
    private AudioSource Source1;
    private bool istimer = false;
   // private float timer = 0.0f;
   
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 0f;
        highscore3.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
        Highscore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
        AnotherHighscore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
        score = 0;
        singleton();
    }
    void singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
           
            instance = this;
         //  DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (istimer)
        {
          
            score += Time.deltaTime;
            displaytimer();
        }
        if (score > PlayerPrefs.GetFloat("HighScore") && score > PlayerPrefs.GetFloat("HighScore")&&score>PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.SetFloat("HighScore", score);
            Highscore.text = score.ToString();
            AnotherHighscore.text = score.ToString();
            highscore3.text = score.ToString();
        }
       if (PlayerPrefs.GetFloat("HighScore") <= score)
        {
            Silvar.SetActive(true);
            Bronze.SetActive(true); 
            Gold.SetActive(true);
        }
       else if (PlayerPrefs.GetFloat("HighScore") >= score)
        {
            Bronze.SetActive(true);
        }
       else if (score <= Random.Range(20, 30))
        {
            Silvar.SetActive(true);
            Bronze.SetActive(true);
          
        }
      
      /* if (transform.position.y >= 7.5f)
        {

            Source1.clip = Clip2;
            Source1.Play();
            istimer = false;
            Time.timeScale = 0f;
            Flight.SetActive(false);
            Pause.SetActive(false);
            Play.SetActive(false);
            gameover.SetActive(true);
            Scoretextmian.SetActive(false);
            restartbutton.SetActive(true);
        }*/
       
      /* if (score == 20)
        {
            Bronze.SetActive(true);
            Gold.SetActive(true);
        }
        else if (score == 10)
        {
            Gold.SetActive(false);
            Bronze.SetActive(true);
            Silvar.SetActive(true);
        }
        else if (score == 5)
        {
            Silvar.SetActive(false);
            Gold.SetActive(false);
            Bronze.SetActive(true);
        }*/
        scoretext.text = score.ToString();
        score2.text = score.ToString();
        limit();
         if (Input.GetMouseButtonDown(0) )
         {
             rb.AddForce ( Vector2.up * addforce);
         }
      /*  if (Input.touchCount > 0)
        {
            rb.AddForce(Vector2.up * addforce);
        }*/
       
       if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * addforce);
        }
    }
    public void staticone(float newlevel)
    {
        istimer = true;
        startbutton.SetActive(false);
        getready.SetActive(false);
        scoreontent.SetActive(true);
        Time.timeScale = newlevel;
    }
    public void restart()
    {
        SceneManager.LoadScene("Scene3");
        //  gameover.SetActive(false);
     
       // restartbutton.SetActive(false);
       Time.timeScale = 1f;
        
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Source1.clip = Clip2;
            Source1.Play();
            istimer = false;
            Time.timeScale = 0f;
            Flight.SetActive(false);
           // Pause.SetActive(false);
           // Play.SetActive(false);
            gameover.SetActive(true);
            restartbutton.SetActive(true);
            Scoretextmian.SetActive(false);
        }
        else if (collision.gameObject.tag == "Ground")
        {

            Source1.clip = Clip2;
            Source1.Play();
            istimer = false;
            Time.timeScale = 0f;
            Flight.SetActive(false);
            //Pause.SetActive(false);
          //  Play.SetActive(false);
            gameover.SetActive(true);
            Scoretextmian.SetActive(false);
            restartbutton.SetActive(true);
        }
    }
    public void pause()
    {
      //  Time.timeScale = 0f;
      

    }
    public void displaytimer()
    {
        int minuets = Mathf.FloorToInt(score / 60.0f);
        int seconds = Mathf.FloorToInt(score - minuets * 60);
        scoretext.text = string.Format("{0:00}", minuets, seconds);
    }
    public void play()
    {
      //  Time.timeScale = 1f;

    }
    public void Music()
    {
        Source1.clip = Clip1;
        Source1.Play();
    }
    public void limit()
    {
       if(transform.position.y >= 6.36f)
        {
            transform.position = new Vector3(transform.position.x, 6.36f,0f);
        }
      else  if(transform.position.y <= -3.74f)
        {
            transform.position = new Vector3(transform.position.x, -3.74f,0f);
            Source1.clip = Clip2;
            Source1.Play();
            istimer = false;
            Time.timeScale = 0f;
            Flight.SetActive(false);
            //Pause.SetActive(false);
            //  Play.SetActive(false);
            gameover.SetActive(true);
            Scoretextmian.SetActive(false);
            restartbutton.SetActive(true);
        }
    }public void Restart()
    {
        PlayerPrefs.DeleteAll();
        Highscore.text ="0";
        AnotherHighscore.text ="0";
        highscore3.text ="0";
        Reset.SetActive(true);
        //Destroy(Reset);
        SceneManager.LoadScene("Scene3");
       // DontDestroyOnLoad(Reset);
     

       // startbutton.SetActive(false);
       // getready.SetActive(false);
       // scoreontent.SetActive(true);
       // Time.timeScale = newlevel;

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
