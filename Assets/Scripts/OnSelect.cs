using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnSelect : MonoBehaviour
{
    public List<GameObject> selectedUnits;
    public RectTransform layoutSelectionBox;
    public List<GameObject> selectableUnits;
    public bool alreadySelected;
    Vector2 topRightMousePosition;
    Vector2 bottomLeftMousePosition;


 

    // Update is called once per frame
    void Update()
    {


        if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            selectUnit(true);
        }
        else if(Input.GetMouseButtonDown(0))
        {
            selectUnit(false);
        }

        //SelectionBox - Mehrfachauswahl von Einheiten/Gebäuden
        //GEBÄUDE NOCH NICHT IMPLEMENTIERT. ABSTRAKTION FEHLT
        //Auswahl derzeit nur von unten links nach oben rechts möglich
        else if(Input.GetMouseButton(0))
        {
            if(topRightMousePosition == new Vector2())
            {
                topRightMousePosition = Input.mousePosition;
            }
            bottomLeftMousePosition = Input.mousePosition;

            layoutSelectionBox.position = (topRightMousePosition + bottomLeftMousePosition) / 2f;
            layoutSelectionBox.sizeDelta = new Vector2(Mathf.Abs(topRightMousePosition.x- bottomLeftMousePosition.x), Mathf.Abs(topRightMousePosition.y - bottomLeftMousePosition.y));
            Rect selectBox = new Rect(topRightMousePosition.x, topRightMousePosition.y, bottomLeftMousePosition.x - topRightMousePosition.x, bottomLeftMousePosition.y - topRightMousePosition.y);
            

            //Prüfe alle GameObjects in der Public Variabe "selectableUnits". Befinden diese sich innerhalb des Quadrats und sind nicht bereits in "selectedUnits" enthalten, werden sie "selectedUnits" hinzugefügt
            foreach(GameObject Unit in selectableUnits)
            {
                //INnerhalb des Quadrats?
                if (selectBox.Contains(Camera.main.WorldToScreenPoint(Unit.transform.position)))
                {
                    alreadySelected = false;
                    Debug.Log(Unit.name);
                    //prüfen, ob die Unit schon zu den ausgewählten ("selectedUnits") gehört.
                    foreach(GameObject a in selectedUnits)
                    {
                        if(a == Unit)
                        {
                            alreadySelected = true;
                            break;
                        }
                    }
                    if(alreadySelected == false)
                    {
                        selectedUnits.Add(Unit);
                    }
                    
                }
            }
            

        }
        //Linke Maustaste hoch um die variablen für die Quadrate zurückzusetzen
        else if(Input.GetMouseButtonUp(0))
        {
            topRightMousePosition = new Vector2();
            bottomLeftMousePosition = new Vector2();
            layoutSelectionBox.sizeDelta = new Vector2(0f, 0f);
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
    
        bool selectUnit(bool withControl)
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
