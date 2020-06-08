using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip badFeedback;
    [SerializeField] private AudioClip goodFeedback;
    

    public void PlayGoodSound()
    {
        audioSource.PlayOneShot(goodFeedback);
    }

    public void PlayBadSound()
    {
        audioSource.PlayOneShot(badFeedback);
    }

}
