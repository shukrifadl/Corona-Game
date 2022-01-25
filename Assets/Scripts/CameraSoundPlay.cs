using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSoundPlay : MonoBehaviour
{

    private AudioSource source;
    public List<AudioClip>audioClips;
    public AudioClip loseSound;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(int num)
    {
        source.PlayOneShot(audioClips[num], 0.5f);
    }
    public void playLoseSound()
    {
        source.PlayOneShot(loseSound,0.5f);
    }

}
