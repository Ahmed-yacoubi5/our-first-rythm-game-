using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    private SpriteRenderer theSprite;
    public Sprite defaulImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;
    void Start()
    {
        theSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            theSprite.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            theSprite.sprite = defaulImage;
        }
    }
}
