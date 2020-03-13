using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeInterface : MonoBehaviour
{
    public GameObject Slot;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var ressourceName in GameManager.Instance.Resourcen)
        {
            if(ressourceName.ResourceName != "Gold")
            {
                var newSlot = Instantiate(Slot, this.transform);
                newSlot.transform.SetParent(this.gameObject.transform);
                newSlot.gameObject.transform.Find("Amount").GetComponent<SliderScript>().ressource.text = ressourceName.ResourceName;
            }
            
        }
              
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
