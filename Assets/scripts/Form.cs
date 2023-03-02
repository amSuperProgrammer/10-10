using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Form : MonoBehaviour
{
    [SerializeField] int formBlockNum;

    Vector3 mousePos;
    Vector3 offset;

    Vector3 objectStandartPosition;

    GameObject[] colorObject;
    Renderer render;
    bool startTranslate = true;

    Renderer[] formBlock;

    CompleteLineManager completeLineManager;


    private void Awake()
    {
        objectStandartPosition = transform.position;
        completeLineManager = GameObject.Find("completeLineManager").GetComponent<CompleteLineManager>();

        render = GetComponentInChildren<Renderer>();
        formBlock = transform.GetComponentsInChildren<Renderer>();
        Color objectColor = Random.ColorHSV(0.0f, 1.0f);

        foreach (Renderer go in formBlock)
        {
            go.material.color = ColorManager(objectColor.r, objectColor.g, objectColor.b) * 10;
        }
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        colorObject = GameObject.FindGameObjectsWithTag("planeBlockColorOn");

        if(startTranslate)
            transform.position = Vector3.MoveTowards(transform.position, objectStandartPosition + new Vector3(0, -10, 0), 20f * Time.deltaTime);
    }
    private void OnMouseDown()
    {
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, 0);
        startTranslate = false;
    }

    private void OnMouseDrag()
    {
        transform.position = new Vector3(mousePos.x, mousePos.y, -1) + offset;
    }

    private void OnMouseUp()
    {
        if (colorObject.Length == formBlockNum)
        {
            startTranslate = false;
            foreach(GameObject obj in colorObject)
            {
                Renderer objRender = obj.transform.gameObject.GetComponent<Renderer>();
                objRender.material = render.material;
                obj.transform.gameObject.tag = "planeBlockComplete";
            }
            completeLineManager.pointNum += formBlockNum;
            Destroy(transform.gameObject);
        }
        else
        {
            startTranslate = true;
        }
    }

    Color ColorManager(float red, float green, float blue)
    {
        float maxValue = Mathf.Max(red, green, blue);
        float minValue = Mathf.Min(red, green, blue);
        
        if(red == maxValue)
        {
            if(green == minValue)
                return new Color(red, 0, 1);
            else
                return new Color(red, 1, 0);
        }
        else if(green == maxValue)
        {
            if (red == minValue)
                return new Color(0, green, 1);
            else
                return new Color(1, green, 0);
        }
        else
        {
            if (red == minValue)
                return new Color(0, 1, blue);
            else
                return new Color(1, blue, 0);

        }
    }

}
