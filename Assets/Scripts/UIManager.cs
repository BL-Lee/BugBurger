using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject moneyUI;
    public GameObject antUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameGlobals>().currentScreen == SCREEN.SERVE)
        {
            moneyUI.SetActive(true);
            antUI.SetActive(false);

        }
        else
        {
            moneyUI.SetActive(false);
            antUI.SetActive(true);
        }
    }
}
