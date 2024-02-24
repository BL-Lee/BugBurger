using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource player;
    bool playing = false;
    int currPriority = 0;

    float durationLeft = 0.0f;
//1 highest
    public AudioClip hammer; //2
    public AudioClip beep; //1

    public AudioClip blender;
    public AudioClip pan;

    AudioClip wasPlaying;
    GameGlobals globals;

    void Start()
    {
        globals = GameObject.Find("Globals").GetComponent<GameGlobals>();
        player = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player.clip != beep && globals.currentScreen == SCREEN.BUG && (globals.flipReady1 || globals.flipReady2 || globals.blendReady))
            {
                PlayBeep();
            }
        durationLeft -= Time.deltaTime;
        if (durationLeft < 0.0f)
        {
            playing = false;
            
        }
        if(!playing && !player.loop)
        {
            player.Pause();
        }
    }

    void play(AudioClip clip, bool loop, int priority)
    {
       //if (currPriority > priority || !playing)
         {
            player.loop = loop;
            player.clip = clip;
            player.Play(0);
            currPriority = priority;
            playing = true;
            durationLeft = clip.length;
         }
    }

    public void PlayHammer()
    {
        play(hammer,false,2);
    }
    public void PlayBeep()
    {
        play(beep,true,1);
    }
    public void PlayBlender()
    {
        play(blender,true,1);
    }
    public void PlayPan()
    {
        play(pan,true,2);
    }

  
    public void StopPan()
    {
         if (player.clip == pan)
            player.Pause();

        if (globals.blending)
            PlayBlender();
    }

    public void SwitchScreen(SCREEN screen)
    {
        player.Pause();
        if (screen == SCREEN.BUG)
        {
            if (globals.flipReady1 || globals.flipReady2 || globals.blendReady)
            {
                PlayBeep();
            }
        }
        if (screen == SCREEN.COOK)
        {
            if (globals.panning > 0)
            {
                PlayPan();
            }
            if (globals.blending)
            {
                PlayBlender();
            }
        }
    }

}
