using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 20;
    [SerializeField] private GameObject[] dotsPrefab;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            int dotsToGenerate = Random.Range(0, dotsPrefab.Length);
            GameObject obj = Instantiate(dotsPrefab[dotsToGenerate]);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.parent = this.transform;
        }
      
    }

    public GameObject getPooledObject() {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        return null;
    }

    
    public void shufflePool() {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            GameObject temp = pooledObjects[i];
            int randomIndex = Random.Range(i, pooledObjects.Count);
            pooledObjects[i] = pooledObjects[randomIndex];
            pooledObjects[randomIndex] = temp;
        }
    }
}
