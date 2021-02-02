using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{

    private int currentScene;
    public static int score;
    private static Manager _instance;

    public static Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Manager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        //if this doesn't exist yet...
        if (_instance == null)  //will only happen once!
        {
            //set instance to this
            _instance = this;
        }
        //If instance already exists and it's not this:
        else if (_instance != null && _instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScene = 0;

        AudioManager.Instance.PlaySong(0); //Play intro song

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Z) && currentScene == 20) //Go back to intro
        {

            currentScene = 0;
            SceneManager.LoadScene(currentScene);
            AudioManager.Instance.PlaySong(0); //Play cutscene music

        }

        if (Input.GetKeyDown(KeyCode.Z) && currentScene >= 16 && currentScene < 20) //Go to next slide
        {



            currentScene++; //Increment current scene
            SceneManager.LoadScene(currentScene); //Load next scene
            //AudioManager.Instance.PlaySong(1); //Play music for next scene
            //AudioManager.Instance.PlaySoundEffect(0); //Play sound effect
            if (currentScene == 16)
            {

                AudioManager.Instance.PlaySong(2); //Play outro music

            }

        }


        if (Input.GetKeyDown(KeyCode.Z) && currentScene > 0 && currentScene <= 13) //Go to next Introduction slide
        {

            currentScene++; //Increment current scene
            SceneManager.LoadScene(currentScene); //Load next scene
            //AudioManager.Instance.PlaySong(1); //Play music for next scene
            //AudioManager.Instance.PlaySoundEffect(0); //Play sound effect
            if (currentScene == 14 || currentScene == 15)
            {

                AudioManager.Instance.PlaySong(1); //Play level music

            }

        }

    
        if (Input.GetKeyDown(KeyCode.Z) && currentScene == 0) //Go from TitleScene to Introduction if Z pressed
        {

            SceneManager.LoadScene(1); //Load next scene
            //AudioManager.Instance.PlaySong(1); //Play music for next scene
            //AudioManager.Instance.PlaySoundEffect(0); //Play sound effect
            currentScene++; //Increment current scene

        }


    }

    public void restartScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void nextScene()
    {
        currentScene++;
        SceneManager.LoadScene(currentScene);
    }
}
