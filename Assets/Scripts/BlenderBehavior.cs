using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderBehavior : MonoBehaviour
{
    public GameObject gameManger;
    public GameObject interactKey;
    public GameObject chargeBar;
    public GameObject pan2Key;
    public GameObject pan1Key;
    public GameObject pan2ChargeBar;
    public GameObject pan1ChargeBar;

    public Sprite empty;
    public Sprite blend1;
    public Sprite blend2;
    public Sprite blend3;
    public Sprite overblend1;
    public Sprite overblend2;
    public Sprite overblend3;

    public Sprite charge1;
    public Sprite charge2;
    public Sprite charge3;
    public Sprite charge4;
    public Sprite charge5;
    public Sprite charge6;
    public Sprite charge7;
    public Sprite charge8;
    public Sprite charge9;
    public Sprite charge10;
    public Sprite charge11;
    public Sprite charge12;
    public Sprite charge13;
    public Sprite charge14;

    public int animationCounter;
    public int blendingCounter;
    public int overblendingCounter;
    public int overblendedCounter;
    public int overblendAnimationCounter;



    public bool overblending;
    public bool blendReady;
    public bool blending;
    public bool finished;

    // Start is called before the first frame update
    void Start()
    {
        finished = false;
        blendReady = false;
        blending = false;
        overblending = false;
        blendingCounter = 1;
        animationCounter = 1;
        overblendingCounter = 1;
        overblendedCounter = 1;
        overblendAnimationCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int numAnts = gameManger.GetComponent<GameGlobals>().antsCaught;
        if (numAnts > 4 && !blendReady && !blending){
            interactKey.SetActive(true);
            blendReady = true;
        }

        if (Input.GetKeyDown("z") && blendReady && gameManger.GetComponent<GameGlobals>().currentScreen == SCREEN.COOK){
            interactKey.SetActive(false);
            chargeBar.SetActive(true);
            gameManger.GetComponent<GameGlobals>().antsCaught = gameManger.GetComponent<GameGlobals>().antsCaught - 5;
            blendReady = false;
            blending = true;
            InvokeRepeating("Blend", 0.0f, 0.25f);
            InvokeRepeating("ChargeMeterStart", 0.0f, 0.5f);
        }

        if (finished){
            if (!pan2ChargeBar.activeSelf)
            {
                pan2Key.SetActive(true);
                finished = false;
            }
            else if (!pan1ChargeBar.activeSelf)
            {
                pan1Key.SetActive(true);
                finished = false;
            }

        }
    }
    

    void Blend()
    {
        switch (animationCounter)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = blend1;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = blend2;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = blend3;
                break;
        }
        animationCounter++;
        if (animationCounter == 4)
        {
            animationCounter = 1;
        }
    }

    void ChargeMeterStart()
    {

        switch (blendingCounter)
        {
            case 1:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge1;
                break;
            case 2:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge2;
                break;
            case 3:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge3;
                break;
            case 4:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge4;
                break;
            case 5:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge5;
                break;
            case 6:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge6;
                break;
            case 7:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge7;
                break;
            case 8:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge8;
                break;
            case 9:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge9;
                break;
            case 10:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge10;
                break;
            case 11:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge11;
                break;
            case 12:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge12;
                break;
            case 13:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge13;
                break;
            case 14:
                chargeBar.GetComponent<SpriteRenderer>().sprite = charge14;
                overblending = true;
                finished = true;
                InvokeRepeating("Overblending", 0.0f, 0.5f);
                break;
        }
        
        blendingCounter++;
    }

    void Overblending()
    {
        if (overblending)
        {
            chargeBar.GetComponent<SpriteRenderer>().sprite = charge1;
            overblending = false;
        }
        else
        {
            overblending = true;
            chargeBar.GetComponent<SpriteRenderer>().sprite = charge14;
        }
        if (overblendingCounter == 10)
        {
            InvokeRepeating("Overblended", 0.0f, 0.25f);
        }
        overblendingCounter++;
        
    }


    void Overblended()
    {
        CancelInvoke("Blend");
        switch (overblendAnimationCounter)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = overblend1;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = overblend2;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = overblend3;
                break;
        }
        overblendAnimationCounter++;
        if (overblendAnimationCounter == 4)
        {
            overblendAnimationCounter = 1;
        }
        
    }
}
