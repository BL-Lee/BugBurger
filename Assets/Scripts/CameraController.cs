using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    private float targetX;
    private float startX;
    private float transitionTime;
    GameGlobals globals;
    public AudioController audio;

    private float totalTransitionTime = 0.5f;

    public float shakeDuration = 0.0f;
    public float shakeAmount = 0.01f;
    public float shakeFalloff = 1.0f;
    Vector3 originalPos;

    public SpriteRenderer s2;
    public Sprite flash0;
    public Sprite flash1;

    GameObject[] tabs;
    float[] tabPos;
    float[] tabTargetPos;
    float tabUnselectedPos = 0.32f;
    float tabSelectedPos = 0.46f;
    int tabSelected = 0;
    int tabWasSelected = 0;

    float EaseOutBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
    }

    void Start()
    {
        globals = GameObject.Find("Globals").GetComponent<GameGlobals>();
        tabs = new GameObject[3];
        tabs[0] = GameObject.Find("Tab 1");
        tabs[1] = GameObject.Find("Tab 2");
        tabs[2] = GameObject.Find("Tab 3");
        tabPos = new float[3];
        tabPos[0] = 0.31f; tabPos[1] = 0.31f; tabPos[1] = 0.31f;
        tabTargetPos = new float[3];
        tabTargetPos[0] = 0.31f; tabTargetPos[1] = 0.31f; tabTargetPos[1] = 0.31f;


        cam = GetComponent<Camera>();
        originalPos = transform.localPosition;
    }

    public void Shake(float duration)
    {
        shakeDuration = duration;
        originalPos = transform.localPosition;
        shakeAmount = 0.01f;
    }

    void setTargetPos(int t)
    {
        for (int i = 0; i < 3; i++)
        {
            if(t == i)
            {
                tabTargetPos[i] = tabSelectedPos;
            }
            else 
                tabTargetPos[i] = tabUnselectedPos;

            tabPos[i] = tabs[i].transform.localPosition.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.currentScreen != SCREEN.COOK)
        {
            s2.sprite = flash0;
            if (globals.flipReady1 || globals.flipReady2 || globals.blendReady)
            {
                s2.sprite = flash1;
            }
        }
        else
        {
            s2.sprite = flash0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetX = -0.84f; //Bug x location
            transitionTime = totalTransitionTime;
            startX = cam.transform.position.x;
            globals.currentScreen = SCREEN.BUG;
            //tabWasSelected = tabSelected;
            //tabSelected = 0;
            audio.SwitchScreen(SCREEN.BUG);
                        setTargetPos(0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetX = 0.0f; //Cook x location
            transitionTime = totalTransitionTime;
            startX = cam.transform.position.x;
            globals.currentScreen = SCREEN.COOK;
            //tabWasSelected = tabSelected;
            //tabSelected = 1;
            audio.SwitchScreen(SCREEN.COOK);
            setTargetPos(1);


        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetX = 0.84f; //serve x location
            transitionTime = totalTransitionTime;
            startX = cam.transform.position.x;
            globals.currentScreen = SCREEN.SERVE;
            //tabWasSelected = tabSelected;
            //tabSelected = 2;
            audio.SwitchScreen(SCREEN.SERVE);
            setTargetPos(2);

        }
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime;
            shakeAmount *= shakeFalloff;
        }
        else
        {
            shakeDuration = 0;
            transform.localPosition = originalPos;
        }


        if (transitionTime < 0.0f)
        {
            transitionTime = 0.0f;
        }
        else if (transitionTime > 0.0f)
        {
            float interpVal = 1 - transitionTime / totalTransitionTime;
            float easeValue = EaseOutBack(interpVal);
            float newX = Mathf.LerpUnclamped(startX, targetX, easeValue);
            cam.transform.position = new Vector3(newX,0,-10);
            transitionTime -= Time.deltaTime;
            originalPos = cam.transform.position;

            for (int i = 0; i < 3; i++)
            {
                Vector3 start = tabs[i].transform.localPosition;
                Vector3 end = tabs[i].transform.localPosition;
               /* if (tabSelected == i)
                {
                    start.x = tabUnselectedPos;
                    end.x = tabSelectedPos;
                }
                else if (tabWasSelected == i)
                {
                    start.x = tabSelectedPos;
                    end.x = tabUnselectedPos;
                }*/

                //else continue;
                start.x = tabPos[i];
                end.x = tabTargetPos[i];
                tabs[i].transform.localPosition = Vector3.Lerp(start, end, easeValue); // make it finish in 0.5s
            }

        }



    }
}
