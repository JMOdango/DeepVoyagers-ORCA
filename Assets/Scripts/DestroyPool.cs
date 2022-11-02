using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPool : MonoBehaviour
{
    public static DestroyPool instance;
    public List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 32;
    [SerializeField] private GameObject destroyPrefab;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(destroyPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.parent = this.transform;
        }

    }

    public GameObject getPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
