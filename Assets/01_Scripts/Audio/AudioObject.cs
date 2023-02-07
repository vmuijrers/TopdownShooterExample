using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SomeAudioObject", menuName = "Audio/Create Audio Object")]
public class AudioObject : ScriptableObject
{
    public AudioClip clip;
    public float volume = 1;
    public bool is3D = true;
}
