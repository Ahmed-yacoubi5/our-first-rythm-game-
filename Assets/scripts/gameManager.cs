using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource theMusic; 
    public AudioSource theMissed;
    public bool startPlaying;
    public beatScroller theBs;
    public static gameManager instance;
    public int currentScore;
    public int scorePerNote=100;
    public int scorePerGoodNote = 120;
    public int scorePerPerfectNote = 150;
    public int missedScore=50;
    //public int currentMultiplier;
    //public int multiplayerTracker;
   // public int[] multiplayerThresholds;
    public Text scoreText;
    //public Text multiText;
    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missHits;
    public GameObject scoreScreen;
    public GameObject endScreen;
    public GameObject anotherEndScreen;
    public float activatingTime;
    public float timePlayed;

    void Start()
    {
        instance = this;

        scoreText.text = "score : 0";
       // currentMultiplier = 1;
        totalNotes= FindObjectsOfType<noteObject>().Length;
       // multiText.text = "Multiplier : x 1";
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBs.hasStarted = true;

                theMusic.Play();
            }
        }else
        {
            if(!theMusic.isPlaying && !scoreScreen.activeInHierarchy && activatingTime==0)
            {
                scoreScreen.SetActive(true);
                endScreen.SetActive(true);
                activatingTime++;
            }
        }
        if(Input.GetKey(KeyCode.R) && timePlayed==0)
        {
            theMusic.Play();
            timePlayed++;
            StartCoroutine(endScreenDelay());
        }
    }
    public void noteHit()
    {
        
        Debug.Log("on time ");
        /*if (currentMultiplier - 1 < multiplayerThresholds.Length)
        {
                 multiplayerTracker++;

            if (multiplayerThresholds[currentMultiplier] - 1 <= multiplayerTracker)
            {
                multiplayerTracker = 0;
                //currentMultiplier++;
            }
            
        }*/

        /*string v = "Multiplier : x " + currentMultiplier;
        multiText.text = v;*/

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "score :" + currentScore;
    }
    public void normalHit()
    {
        currentScore += scorePerNote;
        noteHit();

        normalHits++;
    }

    public void goodHit()
    {
        currentScore += scorePerGoodNote;
        noteHit();
        goodHits++;
    }

    public void perfectHit()
    {
        currentScore += scorePerPerfectNote;
        noteHit();
        perfectHits++;
    }

    public void noteMiss()
    {
        Debug.Log("missed note");

       // currentMultiplier = 1;
       // multiplayerTracker = 0;
        currentScore -= missedScore;
        noteHit();
        theMissed.Play();
        //multiText.text = "Multiplier :  x " + currentMultiplier;
        missHits++;
    }
    IEnumerator endScreenDelay()
    {
        yield return new WaitForSeconds(90);
        endScreen.SetActive(true);
        anotherEndScreen.SetActive(true);
        


    }
}

