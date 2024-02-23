using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntCounter : MonoBehaviour
{
    public Sprite[] numbers;
    SpriteRenderer srenderer;

    GameGlobals globals;
    public int got = 0;
    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("Globals").GetComponent<GameGlobals>();
        srenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.antsCaught != got)
        {

            got = globals.antsCaught;
            srenderer.sprite = numbers[got];
        }
    }
}
