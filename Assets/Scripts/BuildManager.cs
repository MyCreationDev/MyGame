using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject Enviroment;
    public GameObject BuildMenu;
    private GameObject CurrentlySelectedPrefab;
    private bool isBuilding = false;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            isBuilding = false;
        }
        if(isBuilding == true)
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            Physics.Raycast(Ray, out hitinfo);
            CurrentlySelectedPrefab.transform.position = hitinfo.point;
        }
    }

    public void Build(GameObject PrefabToBuild)
    {
        CurrentlySelectedPrefab = Instantiate(PrefabToBuild, Enviroment.transform);
        isBuilding = true;
    }
}
