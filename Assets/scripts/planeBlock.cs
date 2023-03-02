using Unity.VisualScripting;
using UnityEngine;

public class planeBlock : MonoBehaviour
{
    [SerializeField] Material standartMaterial;
    Renderer render;

    RaycastHit hit;
    int layermask = 1 << 3;
    Renderer hitBlockRender;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.back, out hit, Mathf.Infinity, layermask) && transform.gameObject.tag != "planeBlockComplete")
        {
            hitBlockRender = hit.transform.GetComponent<Renderer>();
            Color hitBlockColor = hitBlockRender.material.color;

            render.material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            Debug.DrawLine(transform.position, Vector3.back, Color.red, Mathf.Infinity);
            transform.gameObject.tag = "planeBlockColorOn";

        }
        else
        {
            if (transform.gameObject.tag != "planeBlockComplete")
            {
                transform.gameObject.tag = "planeBlockColorOff";
                render.material.color = Color.white * 10;
            }
        }
    }

}
