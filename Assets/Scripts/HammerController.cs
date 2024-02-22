using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public Sprite hover;
    public Sprite hit;
    public float hitAnimationDuration = 1/30.0f;
    public float hitDuration = 0.5f;
    private float hitTime = 0.0f;
    SpriteRenderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && hitTime <= 0.0f)
        {
            hitTime = 0.5f;
            renderer.sprite = hit;
        }
        hitTime -= Time.deltaTime;

        
    }
}
