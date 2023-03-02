using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompleteLineManager : MonoBehaviour
{
    public int completeLineNum = 0;
    [SerializeField] GameObject pointNumObject;
    TextMeshPro textMeshPro;

    public int pointNum = 0;

    private void Start()
    {
        textMeshPro = pointNumObject.GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        textMeshPro.text = pointNum.ToString();

        if (completeLineNum == 1)
        {
            pointNum += 10;
            completeLineNum = 0;
        }
        else if(completeLineNum > 1)
        {
            pointNum += (completeLineNum * 10) * completeLineNum;
            completeLineNum = 0;
        }
    }
}
