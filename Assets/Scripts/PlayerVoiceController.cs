using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerVoiceController : MonoBehaviour
{
    private AudioSource _voiceAudio;

    private void Awake() 
    {
        _voiceAudio = GetComponent<AudioSource>();
    }

    public void PlayJumpVoice()
    {
        if (_voiceAudio == null)
        {
            return;
        }

        _voiceAudio.Play();
    }


}
