using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TestMulti.SimpleHostile
{
public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, walkSound,hitSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("JumpSound");
        hitSound = Resources.Load<AudioClip>("HitSound");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "Hit":
                audioSource.PlayOneShot(hitSound);
                break;
        }
    }
}
}
