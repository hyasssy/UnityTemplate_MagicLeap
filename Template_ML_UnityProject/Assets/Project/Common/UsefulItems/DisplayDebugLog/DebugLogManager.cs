using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogManager : MonoBehaviour
{
    void Awake()
    {
        var g = FindObjectsOfType<DisplayDebugLogSwitcher>();
        Debug.Log(g);
        if (g.Length == 1)
        {
            //すでに存在している。
        }
        else if (g.Length >= 2)
        {
            Debug.LogWarning("DebugLogDisplayが複数存在しています。");
        }
        else if (g.Length == 0)
        {
            var obj = (GameObject)Resources.Load("DebugLogCanvas");
            var debugLog = Instantiate(obj, Vector3.zero, Quaternion.identity);
            GameObject.DontDestroyOnLoad(debugLog);
        }
        GameObject.Destroy(gameObject);
    }
}
