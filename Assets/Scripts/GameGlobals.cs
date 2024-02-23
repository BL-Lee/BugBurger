using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SCREEN {BUG, COOK, SERVE};

public class GameGlobals : MonoBehaviour
{
  public int antsCaught = 0;
  public SCREEN currentScreen = SCREEN.BUG; //
}
