using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    public List<GameObject> ants;
    private List<AntController> antControllers;
    public GameObject antPrefab;
    GameGlobals globals;

    Vector2 randomStart()
    {
        return new Vector2(Random.Range(-0.3f,0.3f), Random.Range(-0.3f,0.3f));
    }
    Vector2 randomVelocity(Vector2 pos)
    {
        return new Vector2(-Mathf.Sign(pos.x) * Random.Range(0.05f,0.2f) , -Mathf.Sign(pos.y) * Random.Range(0.05f,0.2f) );
    }

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("Globals").GetComponent<GameGlobals>();

        ants = new List<GameObject>();
        antControllers = new List<AntController>();
        for (int i = 0; i < 5; i++)
        {
            GameObject a = Instantiate(antPrefab, transform);
            a.transform.position = randomStart();
            AntController c = a.GetComponent<AntController>();
            c.dead = false;
            c.velocity = randomVelocity(a.transform.position);
            a.transform.position -= new Vector3(0.84f, 0, 0);
            ants.Add(a);
            antControllers.Add(c);
        }
    }

    void RespawnAnt(int i)
    {
        ants[i].transform.position = randomStart();
        antControllers[i].dead = false;
        antControllers[i].deadTime = 0.0f;
        antControllers[i].velocity = randomVelocity(ants[i].transform.position);
        ants[i].transform.position -= new Vector3(0.84f, 0, 0);
    }

    public void WhackBugs(Vector2Int spot)
    {
        Vector2 location = new Vector2(-0.84f - 0.12f, 0.0f); //base position
        location += spot * new Vector2(0.18f, 0.15f);
        for (int i = 0; i < ants.Count; i++)
        {
            if (antControllers[i].dead) continue;

            if (Mathf.Abs(ants[i].transform.position.x - location.x) <= 0.18f / 2f && 
                Mathf.Abs(ants[i].transform.position.y - location.y) <= 0.15f / 2f)
            {
                antControllers[i].dead = true;             
                //Increment counter when we have it   
                globals.antsCaught++;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ants.Count; i++)
        {
            if (antControllers[i].dead && antControllers[i].deadTime > 0.5f)
            {
                RespawnAnt(i);
            }
        }
    }
}
