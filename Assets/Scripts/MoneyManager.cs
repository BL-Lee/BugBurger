using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject moneyDigitOne;
    public GameObject moneyDigitTwo;

    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;


    public int money;

    // Start is called before the first frame update
    void Start()
    {
        money = gameManager.GetComponent<GameGlobals>().money;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (money != gameManager.GetComponent<GameGlobals>().money)
        {
            
            var digitTwoNum = gameManager.GetComponent<GameGlobals>().money % 10;
            var digitOneNum = (gameManager.GetComponent<GameGlobals>().money - digitTwoNum) / 10;
            var sprite = zero;
            switch (digitOneNum)
            {
                case 0:
                    break;
                case 1:
                    sprite = one;
                    break;
                case 2:
                    sprite = two;
                    break;
                case 3:
                    sprite = three;
                    break;
                case 4:
                    sprite = four;
                    break;
                case 5:
                    sprite = five;
                    break;
                case 6:
                    sprite = six;
                    break;
                case 7:
                    sprite = seven;
                    break;
                case 8:
                    sprite = eight;
                    break;
                case 9:
                    sprite = nine;
                    break;
            }
            
            moneyDigitOne.GetComponent<SpriteRenderer>().sprite = sprite;
            sprite = zero;
            switch (digitTwoNum)
            {
                case 0:
                    break;
                case 1:
                    sprite = one;
                    break;
                case 2:
                    sprite = two;
                    break;
                case 3:
                    sprite = three;
                    break;
                case 4:
                    sprite = four;
                    break;
                case 5:
                    sprite = five;
                    break;
                case 6:
                    sprite = six;
                    break;
                case 7:
                    sprite = seven;
                    break;
                case 8:
                    sprite = eight;
                    break;
                case 9:
                    sprite = nine;
                    break;
            }
            moneyDigitTwo.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
