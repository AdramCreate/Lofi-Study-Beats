using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerController : MonoBehaviour {

    public AudioClip firstClip;

    private AudioSource musicPlayer;
    
	// Use this for initialization
	void Start () {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.clip = firstClip;
        musicPlayer.loop = true;
        musicPlayer.Play();
        //StartCoroutine(WaitForTrackTOend());
    }

    /*IEnumerator WaitForTrackTOend()
    {
        while (musicPlayer.isPlaying)
        {

            yield return new WaitForSeconds(0.01f);
        }
        musicPlayer.clip = firstClip;
        musPlayer.loop = true;
        MpPlayer.Play();

    }*/
}
