using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerManager : MonoBehaviour
{
    public GameObject gameManger;
    public GameObject NPC;
    public GameObject ServeKey;
    public GameObject Warning;
    public GameObject Bubble;

    public Sprite emptyBubble;
    public Sprite goodBubble;
    public Sprite overblendedBubble;
    public Sprite burntBubble;
    public Sprite bothBubble;

    public Sprite neutralNPC;
    public Sprite happyNPC;
    public Sprite sadNPC;

    public string quality;

    public bool rating;
    
    // Unity does not support tuples. Order: isOverblended, isBurnt
    public List<bool> burgerStatusList;

    // Start is called before the first frame update
    void Start()
    {
        burgerStatusList = new List<bool>();
        rating = false;
        quality = "good";
    }

    // Update is called once per frame
    void Update()
    {
        // Remove key press. Add check for list > 0
        if(Input.GetKeyDown("y") && !ServeKey.activeSelf && !rating && gameManger.GetComponent<GameGlobals>().currentScreen == SCREEN.SERVE) //If length is greater than 0 AND Serve Key is active.
        {
            Warning.SetActive(false);
            ServeKey.SetActive(true);
        }

        if (Input.GetKeyDown("c") && ServeKey.activeSelf)
        {
            ServeKey.SetActive(false);
            InvokeRepeating("RatingBubble", 0.0f, 5f);
        }
    }
    

    void RatingBubble()
    {
        // I'd pop these if you could
        //var isOverblended = burgerStatusList.Pop();
        //var isBurnt = burgerStatusList.Pop();
        // if (!isOverblended && !isBurnt)
        if (false)
        {
            Bubble.GetComponent<SpriteRenderer>().sprite = goodBubble;
            NPC.GetComponent<SpriteRenderer>().sprite = happyNPC;
        }
        //else if (isOverblended && isBurnt)
        else if (false)
        {
            quality = "bad";
            Bubble.GetComponent<SpriteRenderer>().sprite = bothBubble;
            NPC.GetComponent<SpriteRenderer>().sprite = sadNPC;
            
        }
        //else if (isOverblended)
        else if (true)
        {
            quality = "mid";
            Bubble.GetComponent<SpriteRenderer>().sprite = overblendedBubble;
            NPC.GetComponent<SpriteRenderer>().sprite = sadNPC;
            
        }
        //else if (isBurnt)
        else if (false)
        {
            quality = "mid";
            Bubble.GetComponent<SpriteRenderer>().sprite = burntBubble;
            NPC.GetComponent<SpriteRenderer>().sprite = sadNPC;

        }
        Bubble.SetActive(true);
        InvokeRepeating("Reset", 3.0f, 1f);

    }

    void Reset()
    {
        if (quality == "good")
        {
            gameManger.GetComponent<GameGlobals>().money += 3;
        }
        else if (quality == "mid")
        {
            gameManger.GetComponent<GameGlobals>().money += 2;
        }
        else if (quality == "bad")
        {
            gameManger.GetComponent<GameGlobals>().money += 1;
        }
        quality = "good";
        rating = false;
        Bubble.SetActive(false);
        Bubble.GetComponent<SpriteRenderer>().sprite = emptyBubble;
        NPC.GetComponent<SpriteRenderer>().sprite = neutralNPC;
        CancelInvoke("RatingBubble");
        CancelInvoke("Reset");
    }

    public void AddToList(bool var)
    {
        burgerStatusList.Add(var);
    }
}
