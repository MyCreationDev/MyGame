using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;
public class craftingList : MonoBehaviour
{
    public TextAsset xmlRawFile;
    public Text uiFile;

    private List<string> returnvalue;


    private void Start()
    {
        
        
    }

    private void Update()
    {
        string data = xmlRawFile.text;
        foreach(string c in parseXmlFile(data, "resources", "woodPlanks", "requirement"))
        {
            Debug.Log(c);
        }
    }

    public List<string> parseXmlFile(string xmlData, string headerOfXML, string item, string getAttribute)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));
        returnvalue = new List<string>();
        string xmlPathPattern = headerOfXML;

        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);

        foreach(XmlNode node in myNodeList)
        {
            foreach(XmlNode resourcHeader in node)
            {
                if(resourcHeader.Name == item)
                {
                    foreach(XmlNode a in resourcHeader)
                    {
                        if(a.Name == getAttribute)
                        {
                            //Debug.Log(a.Name);
                            foreach (XmlNode b in a)
                            {
                                returnvalue.Add(b.Name);
                                returnvalue.Add(b.InnerText);
                            }
                            return returnvalue;
                        }
                    }
                }
            }
        }
        return returnvalue;
    }

}
