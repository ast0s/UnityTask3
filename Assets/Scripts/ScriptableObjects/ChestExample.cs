using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestExample : MonoBehaviour
{
    private void Start()
    {
        var allChestInfos = Resources.LoadAll<ChestInfo>("Chests");

        foreach (var chestInfo in allChestInfos)
        {
            Debug.Log(chestInfo.id);
        }
    }
}
