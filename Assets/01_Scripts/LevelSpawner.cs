using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public int amountTrees = 100;
    public GameObject prefab;
    public float maxX = 100;
    public float maxZ = 100;
    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < amountTrees; i++)
        {
            SpawnObject(prefab, new Vector3(Random.Range(0, maxX),0, Random.Range(0, maxZ)));
        }
    }

    public void SpawnObject(GameObject prefab, Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.Euler(0,Random.Range(0, 360),0));
    }
}
