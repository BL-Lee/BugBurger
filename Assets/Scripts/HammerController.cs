using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public Sprite hover;
    public Sprite hit;
    public float hitDuration = 0.5f;
    private float hitTime = 0.0f;
    SpriteRenderer srenderer;
    float blockWidthY = 0.15f;
    float blockWidthX = 0.18f;
    public BugController bugController;

    private Vector2Int location = new Vector2Int(0,0);

    // Start is called before the first frame update
    void Start()
    {
        srenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hitTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && hitTime <= 0.0f)
        {
            hitTime = 0.5f;
            srenderer.sprite = hit;
            bugController.WhackBugs(location);
        }

        if (hitTime <= 0.0f && srenderer.sprite == hit)
        {
            srenderer.sprite = hover;
        }

        if (hitTime <= 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && location.y < 1)
            {
                location.y += 1;
                transform.position += new Vector3(0,blockWidthY,0);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && location.y > -1)
            {
                location.y -= 1;
                transform.position -= new Vector3(0,blockWidthY,0);
            }
           if (Input.GetKeyDown(KeyCode.RightArrow) && location.x < 1)
            {
                location.x += 1;
                transform.position += new Vector3(blockWidthX,0,0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && location.x > -1)
            {
                location.x -= 1;
                transform.position -= new Vector3(blockWidthX,0,0);
            }
        }
    }
}
