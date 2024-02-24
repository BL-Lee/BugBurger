using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan1Behavior : MonoBehaviour
{
    public GameObject gameManger;
    public GameObject pan1Key;
    public GameObject chargeBar;
    public GameObject burger;

    public Sprite uncooked;
    public Sprite halfCooked;
    public Sprite fullCooked;
    public Sprite burnt;

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

    public AudioController audio;


    public int uncookedCounter;
    public int overcookingCounter;

    public bool overcooking;
    public bool cooked;
    public bool overcooked;
    public bool flipRequired;
    public bool isBurnt;

    // Start is called before the first frame update
    void Start()
    {
        uncookedCounter = 1;
        overcookingCounter = 1;
        overcooking = false;
        cooked = false;
        overcooked = false;
        flipRequired = true;
        isBurnt = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameGlobals globals = gameManger.GetComponent<GameGlobals>();
        globals.flipReady1 = overcooking;

        if (Input.GetKeyDown("x") && pan1Key.activeSelf && gameManger.GetComponent<GameGlobals>().currentScreen == SCREEN.COOK && !overcooking){
            pan1Key.SetActive(false);
            chargeBar.SetActive(true);
            burger.SetActive(true);
            InvokeRepeating("ChargeMeterStart", 0.0f, 0.4f);
        }

        if (Input.GetKeyDown("x") && pan1Key.activeSelf && gameManger.GetComponent<GameGlobals>().currentScreen == SCREEN.COOK && overcooking && flipRequired){
            pan1Key.SetActive(false);
            CancelInvoke("BeginOvercook");
            CancelInvoke("ChargeMeterStart");
            flipRequired = false;
            chargeBar.SetActive(true);
            uncookedCounter = 1;
            overcookingCounter = 1;
            InvokeRepeating("ChargeMeterStart", 0.0f, 0.4f);
        }

        if (Input.GetKeyDown("x") && pan1Key.activeSelf && gameManger.GetComponent<GameGlobals>().currentScreen == SCREEN.COOK && ((overcooking && !flipRequired) || isBurnt)){
            CancelInvoke("BeginOvercook");
            CancelInvoke("ChargeMeterStart");
            burger.SetActive(false);
            burger.GetComponent<SpriteRenderer>().sprite = uncooked;
            pan1Key.SetActive(false);
            chargeBar.SetActive(false);
            uncookedCounter = 1;
            overcookingCounter = 1;
            overcooking = false;
            cooked = false;
            overcooked = false;
            flipRequired = true;
            isBurnt = false;
            globals.panning--;
            if (globals.panning == 0)
            {
                audio.StopPan();
            }
        }
    }

    void ChargeMeterStart()
    {

        switch (uncookedCounter)
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
                chargeBar.SetActive(false);
                overcooking = true;
                if (flipRequired)
                {
                    burger.GetComponent<SpriteRenderer>().sprite = halfCooked;
                }
                else if (!isBurnt)
                {
                    burger.GetComponent<SpriteRenderer>().sprite = fullCooked;
                }
                InvokeRepeating("BeginOvercook", 0.0f, 0.5f);
                
                break;
        }
        uncookedCounter++;
    }

    void BeginOvercook()
    {
        pan1Key.SetActive(true);
        if (overcookingCounter == 10)
        {
            InvokeRepeating("Overcooked", 0.0f, 0.25f);
        }
        overcookingCounter++;
    }

    void Overcooked()
    {
        burger.GetComponent<SpriteRenderer>().sprite = burnt;
        isBurnt = true;
    }
}
