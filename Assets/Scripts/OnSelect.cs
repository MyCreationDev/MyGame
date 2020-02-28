using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnSelect : MonoBehaviour
{
    public List<GameObject> selectedUnits;
    Vector2 topRightMousePosition;
    Vector2 bottomLeftMousePosition;


    // Update is called once per frame
    void Update()
    {


        if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            selectUnits(true);
        }
        else if(Input.GetMouseButtonDown(0))
        {
            selectUnits(false);
        }
        else if(Input.GetMouseButton(0))
        {
            if(topRightMousePosition == new Vector2())
            {
                topRightMousePosition = Input.mousePosition;
            }
            bottomLeftMousePosition = Input.mousePosition;

            Rect selectBox = new Rect(topRightMousePosition.x, topRightMousePosition.y, bottomLeftMousePosition.x - topRightMousePosition.x, bottomLeftMousePosition.y - topRightMousePosition.y);

            if()
        }

        //Bewegen der ausgewhlten Einheiten einleiten
        if(Input.GetMouseButtonDown(1))
        {

            

            foreach (GameObject unitstoMove in selectedUnits)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    unitstoMove.GetComponent<Units>().MoveUnits(hit.point);
                }
            }
        }
    
        bool selectUnits(bool withControl)
        {
            if(withControl == false)
            {
                selectedUnits.Clear();
            }
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit.gameObject.GetComponent<Units>().playername == "Mike")
                {
                    selectedUnits.Add(objectHit.gameObject);
                }
            }

            return true;
        }
    }
}
