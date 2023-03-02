using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLine : MonoBehaviour
{
    [SerializeField] GameObject completeLineManagerObject;
    GameObject[] insideObject = new GameObject[10];
    int completeNum;

    GameObject boxObject;
    BoxCollider boxCollider;

    CompleteLineManager completeLineManager;

    private void Start()
    {
        completeLineManager = completeLineManagerObject.GetComponent<CompleteLineManager>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "planeBlockComplete" && collision.gameObject.tag != "completeLine")
        {
            boxObject = collision.gameObject;
            boxCollider = collision.gameObject.GetComponent<BoxCollider>();

            if (insideObject[completeNum] == null)
            {
                insideObject[completeNum] = collision.gameObject;
                boxCollider.enabled = false;
            }

            completeNum++;

            if(completeNum == 10)
            {
                foreach(GameObject obj in insideObject)
                {
                    boxCollider = obj.GetComponent<BoxCollider>();
                    obj.tag = "planeBlockColorOff";
                    boxCollider.enabled = true;
                }
                for(int arrayNum = 0; arrayNum != 10; arrayNum++)
                {
                    Debug.Log(arrayNum);
                    insideObject[arrayNum] = null;
                    Debug.Log(insideObject[0]);
                    Debug.Log(insideObject[1]);
                    Debug.Log(insideObject[2]);
                    Debug.Log(insideObject[3]);
                    Debug.Log(insideObject[4]);
                    Debug.Log(insideObject[5]);
                    Debug.Log(insideObject[6]);
                    Debug.Log(insideObject[7]);
                    Debug.Log(insideObject[8]);
                    Debug.Log(insideObject[9]);
                }
                completeLineManager.completeLineNum++;
                completeNum = 0;
            }
        }
    }
}
