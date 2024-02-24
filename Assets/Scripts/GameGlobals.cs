using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SCREEN {BUG, COOK, SERVE};

public class GameGlobals : MonoBehaviour
{
  public int antsCaught = 0;
  public int money = 0;
  public SCREEN currentScreen = SCREEN.BUG; //
  public bool flipReady1 = false;
  public bool flipReady2 = false;
  public bool blendReady = false;
  public bool blending = false;
  public int panning = 0;

}
