using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererController : MonoBehaviour
{
    public GameObject panel; 
    public Image img; 
    public Button btn;
    //Declare a LineRenderer to store the component attached to the GameObject.
    [SerializeField] LineRenderer rend; 
    //Settings for the LineRenderer are stored as a Vector3 array of points. Set up a V3 array to //initialize in Start.
    Vector3[] points;
    //Start is called before the first frame update
    void Start() {
        img = panel.GetComponent<Image>();
        //get the LineRenderer attached to the gameobject.
        rend = gameObject.GetComponent<LineRenderer>();
        //initialize the LineRenderer
        points = new Vector3[2];
        //set the start point of the linerenderer to the position of the gameObject.
        points[0] = Vector3.zero;
        //set the end point 20 units away from the GO on the Z axis (pointing forward)
        points[1] = transform.position + new Vector3(0, 0, 20);
        //finally set the positions array on the LineRenderer to our new values
        rend.SetPositions(points);
        rend.enabled = true;

    }

    public LayerMask layerMask;
    public bool AlignLineRenderer(LineRenderer rend)
    {
        bool hitBtn = false;
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, layerMask)) 
        {
            btn = hit.collider.gameObject.GetComponent<Button>();
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);
            rend.startColor = Color.red; 
            rend.endColor = Color.red;
            hitBtn = true;
        } 
        else 
        {
            points[1] = transform.forward + new Vector3(0, 0, 20);
            rend.startColor = Color.green;
            rend.endColor = Color.green;
            hitBtn = false;
        }
        rend.SetPositions(points);
        rend.material.color = rend.startColor;
        return hitBtn;
    }
    private void Update()
    {
        AlignLineRenderer(rend);
    }

    public void ColorChangeOnClick() 
    {
        if (btn != null) 
        {
            if (btn.name == "red_btn") 
            { 
                img.color = Color.red; 
            }
            else if (btn.name == "blue_btn")
            {
                img.color = Color.blue;
            } 
            else if (btn.name == "green_btn")
            { 
                img.color = Color.green;
            }
        } 
    }
}