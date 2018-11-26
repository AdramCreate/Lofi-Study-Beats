using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerController : MonoBehaviour {

    public AudioClip firstClip;
    public OVRGrabber leftController;
    public OVRGrabber rightController;

    private AudioSource musicPlayer;
    private bool isVRGrabbed;
    private OVRGrabbable speakerGrabbableScript;
    
	// Use this for initialization
	void Start () {
        speakerGrabbableScript = GetComponent<OVRGrabbable>();
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.clip = firstClip;
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
