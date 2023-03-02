using Unity.VisualScripting;
using UnityEngine;

public class FormManager : MonoBehaviour
{
    [SerializeField] GameObject[] objectPrefab;
    Transform playSceneTransform;

    GameObject oneForm;
    GameObject twoForm;
    GameObject threeForm;

    private void Start()
    {
        objectPrefab = GameObject.FindGameObjectsWithTag("FormObject");
        playSceneTransform = GameObject.Find("playScene").transform;

        FormCreate();
    }

    private void Update()
    {
        if(!GameObject.Find("form(Clone)"))
        {
            FormCreate();
        }
    }
    void FormCreate()
    {
        oneForm = Instantiate(objectPrefab[Random.Range(0, objectPrefab.Length - 1)], new Vector3(2.25f, 3.25f, -1), Quaternion.Euler(0, 0, Random.Range(0, 3) * 90), playSceneTransform);
        twoForm = Instantiate(objectPrefab[Random.Range(0, objectPrefab.Length - 1)], new Vector3(2.25f, 0, -1), Quaternion.Euler(0, 0, Random.Range(0, 3) * 90), playSceneTransform);
        threeForm = Instantiate(objectPrefab[Random.Range(0, objectPrefab.Length - 1)], new Vector3(2.25f, -3.25f, -1), Quaternion.Euler(0, 0, Random.Range(0, 3) * 90), playSceneTransform);
    }
}
