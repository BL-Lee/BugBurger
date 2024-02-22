using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : MonoBehaviour
{
    public Sprite antSprite;
    public Sprite hitSprite;
    public bool dead = false;
    public float deadTime = 0.0f;
    public Vector2 velocity;

    Vector2 boxMins = new Vector2(-1.26f, -0.27f);
        Vector2 boxMaxs = new Vector2(-0.67f, 0.27f);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            deadTime += Time.deltaTime;
        }
        
        if (!dead)
        {
            transform.position += new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;
        }

        if (transform.position.y > boxMaxs.y || transform.position.y < boxMins.y || 
            transform.position.x > boxMaxs.x || transform.position.x > boxMaxs.x)
        {
            dead = true;
        }
    }
}
