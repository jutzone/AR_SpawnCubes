using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnedObjectPrefab;
    private List<GameObject> objectsList;
    public int MaxObjectsCount;
    public float Delay;
    public float AreaLimits, DistanceFromPlayer;
    public delegate void VoidDelegate(GameObject obj, bool removeAll);
    public static VoidDelegate RemoveObjectFromListDelegate;


    private void Start()
    {
        objectsList = new List<GameObject>();
        RemoveObjectFromListDelegate = removeFromList;
        StartCoroutine(spawnObjectRoutine());
    }


    IEnumerator spawnObjectRoutine()
    {
        Vector3 position;
        yield return new WaitForSeconds(Delay);
        do
        {
            position = getPosition();
        }
        while (Vector3.Distance(position, Camera.main.transform.position) < DistanceFromPlayer);

        GameObject go = Instantiate(spawnedObjectPrefab, position, Quaternion.identity);

        objectsList.Add(go);
        yield return new WaitUntil(() => objectsList.Count < MaxObjectsCount);
        StartCoroutine(spawnObjectRoutine());
    }

    public void RespawnAll()
    {
        
    }

    private void removeFromList(GameObject obj, bool removeAll)
    {
        if (removeAll)
        {
            foreach (GameObject cube in objectsList)
            {
                Destroy(cube.gameObject);
            }
            objectsList.Clear();
        }
        else
        {
            objectsList.Remove(objectsList.Find(x => x == obj));
        }
    }


    private Vector3 getPosition()
    {
        Vector3 position = new Vector3(
            Random.Range(-AreaLimits, AreaLimits),
            Camera.main.transform.position.y,
            Random.Range(-AreaLimits, AreaLimits));
       
            return position;
    }
}
