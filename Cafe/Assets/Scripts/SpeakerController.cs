using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerController : MonoBehaviour {

    //public AudioClip firstClip;
    public OVRGrabber leftController;
    public OVRGrabber rightController;

    private Object[] music;

    private AudioSource musicPlayer;
    private bool isVRGrabbed;
    private OVRGrabbable speakerGrabbableScript;

    private void Awake()
    {
        musicPlayer = GetComponent<AudioSource>();
        music = Resources.LoadAll("Sounds/Music", typeof(AudioClip));
        musicPlayer.clip = music[0] as AudioClip;
    }
    // Use this for initialization
    void Start () {
        

        speakerGrabbableScript = GetComponent<OVRGrabbable>();
        
        //musicPlayer.clip = firstClip;4
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
        }
        else if(speakerGrabbableScript.grabbedBy == rightController)
        {
            if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                PlayPauseMusic();
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
}
