using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class noteObject : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject hitEffect,goodEffect,perfectEffect,missEffect ;
    public float Count=0;
    public float missedCount = 0;
    public float noteTime=40;
    public float effectTimer;
    public float normalTimer;
    public float goodTimer;
    public float perfectTimer;
    public AudioSource theMissed;
    public GameObject scorePanel;
    public GameObject endGamePanel;
    public float replayTimes;
    public float fake=0; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)&&replayTimes==0)
        {

            StartCoroutine(ScreenDelay());
            if (Count == 1)
                StartCoroutine(HitNoteDelay());
            StartCoroutine(perfectNoteDelay());
            StartCoroutine(goodNoteDelay());
            StartCoroutine(hitNoteDelay());
                //Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            if (missedCount == 1)
                StartCoroutine(missedNoteDelay());
            replayTimes++; 
        }

        if (fake == 1)
        {
            if (canBePressed && Input.GetKeyDown(keyToPress))
            {
                gameManager.instance.noteMiss();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                gameObject.SetActive(false);
            }
            

        }
        else
        {

            if (Input.GetKeyDown(keyToPress))
            {
                if (canBePressed)
                {

                    if (Count < 1 && missedCount == 0)
                    {
                        effectTimer = Time.timeSinceLevelLoad;
                        Debug.Log(effectTimer);
                        Count++;
                        //gameManager.instance.noteHit();
                        // gameObject.SetActive(false);
                        StartCoroutine(delay());
                        if (transform.position.y > -6.5 || transform.position.y < -8.2)
                        {
                            gameManager.instance.normalHit();
                            Debug.Log("hit");
                            Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                            normalTimer = Time.timeSinceLevelLoad;

                        }
                        else if (transform.position.y > -7 || transform.position.y < -7.81)
                        {
                            Debug.Log("good");
                            gameManager.instance.goodHit();
                            Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                            goodTimer = Time.timeSinceLevelLoad;
                        }
                        else
                        {
                            Debug.Log("perfect");
                            gameManager.instance.perfectHit();
                            Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                            perfectTimer = Time.timeSinceLevelLoad;
                        }

                    }

                }

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (Count == 0 && missedCount <1)
        {
            if (gameObject.activeSelf)
            {
                if (other.tag == "Activator")
                {
                    if (fake == 1)
                    {
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        effectTimer = Time.timeSinceLevelLoad;
                        missedCount++;
                        canBePressed = false;
                        gameManager.instance.noteMiss();
                        Debug.Log(effectTimer);
                        Instantiate(missEffect, transform.position, missEffect.transform.rotation);
                    }
                }
            }
        }
        
    }
    IEnumerator delay()
    {
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(5);
        GetComponent<Renderer>().enabled = true;
        
    }

    IEnumerator HitNoteDelay()
    {
        yield return new WaitForSeconds(effectTimer);
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
    IEnumerator missedNoteDelay()
    {
        yield return new WaitForSeconds(effectTimer);
        theMissed.Play();
        Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator hitNoteDelay()
    {
        yield return new WaitForSeconds(normalTimer);

        Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
    }
    IEnumerator goodNoteDelay()
    {
        yield return new WaitForSeconds(goodTimer);

        Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
    }
        IEnumerator perfectNoteDelay()
    {
        yield return new WaitForSeconds(perfectTimer);

        Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
    }
     IEnumerator ScreenDelay()
    {
        yield return new WaitForSeconds(1);
        scorePanel.SetActive(false);
        endGamePanel.SetActive(false);

    }

}

