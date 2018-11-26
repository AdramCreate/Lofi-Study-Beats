using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerController : MonoBehaviour {

    //public AudioClip firstClip;
    public OVRGrabber leftController;
    public OVRGrabber rightController;

    private Object[] music;
    private int musicCurrIndex;
    private AudioSource musicPlayer;
    private OVRGrabbable speakerGrabbableScript;

    private void Awake()
    {
        musicPlayer = GetComponent<AudioSource>();
        speakerGrabbableScript = GetComponent<OVRGrabbable>();
        music = Resources.LoadAll("Sounds/Music", typeof(AudioClip));
        musicPlayer.clip = music[0] as AudioClip;
        musicCurrIndex = 0;
    }

    void Start () {
        musicPlayer.loop = true;
        musicPlayer.Play();
    }

    private void Update()
    {
        if (speakerGrabbableScript.isGrabbed)
        {
            interactWithSpeaker();
        }
    }

    private void interactWithSpeaker()
    {
        if(speakerGrabbableScript.grabbedBy == leftController)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                PlayPauseMusic();
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft))
            {
                PlayPreviousSong();
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight))
            {
                PlayNextSong();
            }
        }
        else if(speakerGrabbableScript.grabbedBy == rightController)
        {
            if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                PlayPauseMusic();
            }
            if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickLeft))
            {
                PlayPreviousSong();
            }
            if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickRight))
            {
                PlayNextSong();
            }
        }
         
    }

    private void PlayPauseMusic()
    {
        if (musicPlayer.isPlaying)
        {
            musicPlayer.Pause();
        }
        else
        {
            musicPlayer.Play();
        }
    }

    private void PlayNextSong()
    {
        PlayPauseMusic();
        if (musicCurrIndex == music.Length - 1)
        {
            musicCurrIndex = 0;
        }
        else
        {
            musicCurrIndex++;
        }
        musicPlayer.clip = music[musicCurrIndex] as AudioClip;
        PlayPauseMusic();
    }

    private void PlayPreviousSong()
    {
        PlayPauseMusic();
        if (musicCurrIndex == 0)
        {
            musicCurrIndex = music.Length - 1;
        }
        else
        {
            musicCurrIndex--;
        }
        musicPlayer.clip = music[musicCurrIndex] as AudioClip;
        PlayPauseMusic();
    }
}
