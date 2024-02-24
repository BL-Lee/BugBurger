using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeKeyBehavior : MonoBehaviour
{
    public Sprite flash;
    public Sprite regular;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetFlashing", 0.0f, 0.25f);
    }

    void SetFlashing()
    {
        var currSprite = this.GetComponent<SpriteRenderer>().sprite;
        if (currSprite == regular)
        {
            this.GetComponent<SpriteRenderer>().sprite = flash;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = regular;
        }

    }
}
