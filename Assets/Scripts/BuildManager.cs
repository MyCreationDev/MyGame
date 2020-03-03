using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject Enviroment;
    private GameObject CurrentlySelectedPrefab;

    // Update is called once per frame
    void Update()
    {
        if(OnSelect.Instance.IsBuildingMode)
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            Physics.Raycast(Ray, out hitinfo);
            CurrentlySelectedPrefab.transform.position = hitinfo.point;
        }
    }

    public void Build(GameObject PrefabToBuild)
    {
        BasicGebäude buildingToBuild = PrefabToBuild.GetComponent<BasicGebäude>();
        if (buildingToBuild.CanBuyBuilding())
        {
            buildingToBuild.BuyBuilding();
            CurrentlySelectedPrefab = Instantiate(PrefabToBuild, Enviroment.transform);
            OnSelect.Instance.IsBuildingMode = true;
        }
    }
}
