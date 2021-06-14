using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    Transform objRoot = default;
    GameObject obj;
    [SerializeField]
    int amount = 100;
    [SerializeField]
    float range = 10f;
    [SerializeField]
    Vector2 heightRange = new Vector2(1f, 2f);
    private void Start()
    {
        obj = (GameObject)Resources.Load("Test");
        for (int i = 0; i < amount; i++)
        {
            var playerPos = Camera.main.transform.position;
            var horizontalValue = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(-range, range);
            var verticalValue = Random.Range(heightRange.x, heightRange.y);
            var targetPos = playerPos + new Vector3(horizontalValue.x, verticalValue, horizontalValue.y);

            var newobj = Instantiate(obj, targetPos, Random.rotation);
            if (objRoot == default)
            {
                Debug.LogWarning("objRoot is not assigned");
            }
            else
            {
                newobj.transform.parent = objRoot;
            }
        }
    }
    public void LogTest()
    {
        Debug.Log("Test");
    }
}