using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if(instance == null){
                instance = FindObjectOfType<AudioManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    
    public void PlayObject(AudioObject audioObject, Vector3 position)
    {
        //AudioSource.PlayClipAtPoint(audioObject.clip, position);
        GameObject obj = new GameObject(audioObject.name);
        obj.transform.position = position;
        var aSource = obj.AddComponent<AudioSource>();
        aSource.clip = audioObject.clip;
        aSource.volume = audioObject.volume;
        aSource.spatialBlend = audioObject.is3D ? 1 : 0;
        aSource.Play();
        Destroy(obj, audioObject.clip.length + 0.1f);
    }
}
