using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class MarketPlace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        getRessourceInformation("wood", "normalPrice");
    }

    public void getRessourceInformation(string resource, string information)
    {
        TextAsset textXMLAsset = Resources.Load<TextAsset>("resourceList");
        var doc = XDocument.Parse(textXMLAsset.text);
        var alldict = doc.Element("resources").Elements();
        foreach (var oneDict in alldict)
        {
            if(oneDict.Name == resource)
            {
                foreach(var singleDict in oneDict.Elements(information))
                {
                    Debug.Log(singleDict.Value);
                }
            }
            
        }
    }
}
