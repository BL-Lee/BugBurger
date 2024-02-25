using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    public float totalSecondsInGame = 120;
    public float timeElapsed = 0.0f;
    public Sprite[] sprites;
    int spriteIndex = 0;
    SpriteRenderer s;
    GameGlobals globals;

    // Start is called before the first frame update
    void Start()
    {        
        globals = GameObject.Find("Globals").GetComponent<GameGlobals>();
        s = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.currentScreen == SCREEN.SERVE)
        {
            s.enabled = false;
        }
        else 
        {
            s.enabled = true;
        }
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= totalSecondsInGame)
        {
            Debug.Log("GAME OVER!!!! Quit game here");
        }
        int i = (int)(timeElapsed * sprites.Length / totalSecondsInGame);
        if (i != spriteIndex)
        {
            s.sprite = sprites[i];
            spriteIndex = i;
        }


    }
}
