using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static int index = 0;

    [SerializeField]
    float spawnTimer = 1.2f;
    [SerializeField]
    float objectsSpeed = 2.2f;
    [SerializeField]
    bool objectsMoveLeft = true;
    [SerializeField]
    GameObject[] prefabs;
    List<GameObject> pool = new List<GameObject>();
    Vector3 startPoint;

    private void Awake()
    {
        startPoint = transform.position;
        InvokeRepeating("Spawn", Random.Range(0.5f,0.9f), spawnTimer);
    }

    void Spawn()
    {
        GameObject obj = GetPoolObject();
        if(obj != null)
        {
            obj.transform.position = startPoint;
            obj.SetActive(true);
        }
        else
        {
            GameObject go = Instantiate(prefabs[Random.Range(0, prefabs.Length)], startPoint, Quaternion.identity);
            go.name = index.ToString();
            index++;
            go.GetComponent<ObjectMovement>().SetMoveDirectionAndSpeed(objectsMoveLeft, objectsSpeed);
            if (!objectsMoveLeft)
                go.GetComponent<SpriteRenderer>().flipX = true;
            pool.Add(go);
        }
    }

    GameObject GetPoolObject()
    {
        if (pool.Count == 0)
            return null;

        foreach (var item in pool)
        {
            if(!item.activeSelf)
                return item;
        }

        return null;
    }
}
