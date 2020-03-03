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
            //Prüfen, was angelickt wurde
            selectUnit(false);
        }

        //SelectionBox - Mehrfachauswahl von Einheiten/Gebäuden
        //GEBÄUDE NOCH NICHT IMPLEMENTIERT. ABSTRAKTION FEHLT
        else if(Input.GetMouseButton(0))
        {
            if(topRightMousePosition == new Vector2())
            {
                topRightMousePosition = Input.mousePosition;
            }
            bottomLeftMousePosition = Input.mousePosition;

            layoutSelectionBox.position = (topRightMousePosition + bottomLeftMousePosition) / 2f;
            float width = Mathf.Abs(topRightMousePosition.x - bottomLeftMousePosition.x);
            float height = Mathf.Abs(topRightMousePosition.y - bottomLeftMousePosition.y);

            
            layoutSelectionBox.sizeDelta = new Vector2(width, height);


            Rect selectBox = new Rect(topRightMousePosition.x, topRightMousePosition.y, bottomLeftMousePosition.x - topRightMousePosition.x, bottomLeftMousePosition.y - topRightMousePosition.y);


            //Prüfe alle GameObjects in der Public Variabe "selectableUnits". Befinden diese sich innerhalb des Quadrats und sind nicht bereits in "selectedUnits" enthalten, werden sie "selectedUnits" hinzugefügt
            foreach(GameObject Unit in selectableUnits)
            {
                //Innerhalb des Quadrats?
                if (selectBox.Contains(Camera.main.WorldToScreenPoint(Unit.transform.position),true))
                {
                    alreadySelected = false;
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
        if(Input.GetMouseButton(1) || Input.GetMouseButtonDown(1))
        {
            foreach (GameObject unitstoMove in selectedUnits)
            {
                unitstoMove.GetComponent<SphereCollider>().enabled = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject clickedObject = hit.transform.gameObject;
                    Component sphereCollider = clickedObject.GetComponent<SphereCollider>();
                    if (sphereCollider)
                    {
                        clickedObject.GetComponent<Units>().SphereColliderOff();
                    }
                        if (hit.transform.gameObject.GetComponent<Units>())
                    {
                        if(hit.transform.gameObject.GetComponent<Units>().playername != selectedUnits[0].GetComponent<Units>().playername)
                        {
                            foreach(GameObject units in selectedUnits)
                            {
                                units.GetComponent<Units>().attack(hit.transform.gameObject);
                            }
                        }
                    }
                    unitstoMove.GetComponent<Units>().movement = true;
                    unitstoMove.GetComponent<Units>().MoveUnits(hit.point);
                }
                unitstoMove.GetComponent<Units>().SphereColliderOn();
            }
        }
    
        
    }

    void selectUnit(bool withControl)
    {

        //Bei gedrückter STRG-Taste werden zusätzliche EInheiten ausgewählt.
        //Abfrage, ob STRG gedrückt wurde. Nein: Ausgewählte Einheiten abwählen.
        if (withControl == false)
        {
            selectedUnits.Clear();
        }
        RaycastHit hit;
        Vector3 ClickPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(ClickPosition);

        //Maustaste trifft ein Objekt.
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            //Bei SphereCollider diesen ausschalten.
            if(objectHit.gameObject.GetComponent<SphereCollider>())
            {
                selectedUnits.Clear();
                Collider sphere = objectHit.gameObject.GetComponent<SphereCollider>();
                sphere.enabled = false;
                ray = Camera.main.ScreenPointToRay(ClickPosition);
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.GetType().Name == "BoxCollider")
                    {
                        if (hit.transform.gameObject.GetComponent<Units>())
                        {
                            if (hit.transform.gameObject.GetComponent<Units>().playername == "Mike")
                            {
                                selectedUnits.Add(hit.transform.gameObject);
                            }
                        }
                            
                    }
                }
                sphere.enabled = true;
            }
            else if (objectHit.gameObject.GetComponent<Units>())
            {
                if (objectHit.gameObject.GetComponent<Units>().playername == "Mike")
                {
                    selectedUnits.Add(objectHit.gameObject);
                }
            }
        }
    }
}