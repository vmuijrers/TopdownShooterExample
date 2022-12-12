using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjectReaction : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnGameObject(Vector3 position, Quaternion rotation)
    {
        Instantiate(prefab, position, rotation);
    }
}
