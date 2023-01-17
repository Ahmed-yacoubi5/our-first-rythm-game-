using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ActionReplay : MonoBehaviour
{
   public bool isInReplayMode;
   private List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();
   public Rigidbody2D rigidbody;
   public Vector3 position;
   private int currentReplayIndex;
    public noteObject noteObject;
    public float hitBoxTime;
    public float replayTime;


    void Start ()
   {
    rigidbody = GetComponent<Rigidbody2D>();
   }
   
   
   
    void Update()
{
        

        if (Input.GetKey(KeyCode.R)&&replayTime==0)
    {
        isInReplayMode = !isInReplayMode;

        if (isInReplayMode)
        {
            SetTransform(0);
            rigidbody.isKinematic = true;
        }
      else
        {
            SetTransform(actionReplayRecords.Count - 1);
            rigidbody.isKinematic = false;
        }
        replayTime ++;
    }        
}



    void FixedUpdate()
{
        
    if (isInReplayMode== false)
    {
    actionReplayRecords.Add(new ActionReplayRecord { position = transform.position, rotation = transform.rotation });
    }
   else 
   {
           
              
            int nextIndex = currentReplayIndex + 1;
        
        if (nextIndex < actionReplayRecords.Count)
            {

            SetTransform(nextIndex);


            }
   }
}
   private void SetTransform(int index)
   {
     currentReplayIndex = index;

     ActionReplayRecord actionReplayRecord = actionReplayRecords[index];

        transform.position = actionReplayRecord.position;
        transform.rotation = actionReplayRecord.rotation;
        
        
    }
    

    


}