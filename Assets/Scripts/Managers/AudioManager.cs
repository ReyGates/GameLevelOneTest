using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : BaseManager<AudioManager>
{
    public AudioSource AudioSource;
    public List<AudioClip> TypeClipList;

    public void PlayTypeClip()
    {
        AudioSource.PlayOneShot(TypeClipList[Random.Range(0, TypeClipList.Count - 1)]);
    }
}
