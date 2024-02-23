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

    private float totalTransitionTime = 0.5f;

    public float shakeDuration = 0.0f;
    public float shakeAmount = 0.01f;
    public float shakeFalloff = 1.0f;
    Vector3 originalPos;

    float EaseOutBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
    }

    void Start()
    {
        globals = GameObject.Find("Globals").GetComponent<GameGlobals>();
        cam = GetComponent<Camera>();
        originalPos = transform.localPosition;
    }

    public void Shake(float duration)
    {
        shakeDuration = duration;
        originalPos = transform.localPosition;
        shakeAmount = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetX = -0.84f; //Bug x location
            transitionTime = totalTransitionTime;
            startX = cam.transform.position.x;
            globals.currentScreen = SCREEN.BUG;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetX = 0.0f; //Cook x location
            transitionTime = totalTransitionTime;
            startX = cam.transform.position.x;
            globals.currentScreen = SCREEN.COOK;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetX = 0.84f; //serve x location
            transitionTime = totalTransitionTime;
            startX = cam.transform.position.x;
            globals.currentScreen = SCREEN.SERVE;
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
        }



    }
}
