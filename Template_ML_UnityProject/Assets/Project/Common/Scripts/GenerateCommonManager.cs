using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCommonManager : MonoBehaviour
{
    void Start()
    {
        var commonManagerOnScene = FindObjectsOfType<CommonManager>();
        if (commonManagerOnScene.Length == 0)
        {
            //シーン上にCommonManagerが存在していない時にPrefabを生成
            Debug.Log("Generate Common Manager");
            var commonManager = Instantiate((GameObject)Resources.Load("CommonManager"), Vector3.zero, Quaternion.identity);
            DontDestroyOnLoad(commonManager);
        }
    }
}
