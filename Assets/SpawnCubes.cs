using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public int cubesCount = 0;
    public GameObject minPosEmpty;
    public GameObject maxPosEmpty;
    public GameObject prefubCube;


    private int currentCount = 0;
    private List<GameObject> cubes = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {
        if (cubesCount < 0)
            cubesCount = 0;

        if (currentCount < cubesCount)
        {
            var newPos = new Vector3(
                Random.Range(getMinPos().x, getMaxPos().x),
                Random.Range(getMinPos().y, getMaxPos().y),
                Random.Range(getMinPos().z, getMaxPos().z));
            cubes.Add(Instantiate(prefubCube, newPos, new Quaternion(0, 0, 0, 0)));
            currentCount++;
        }
        else if (currentCount > cubesCount)
        {
            Destroy(cubes[currentCount - 1]);
            cubes.RemoveAt(currentCount - 1);
            currentCount--;
        }
    }

    private Vector3 getMinPos()
    {
        return minPosEmpty.gameObject.transform.position;
    }

    private Vector3 getMaxPos()
    {
        return maxPosEmpty.gameObject.transform.position;
    }
}
