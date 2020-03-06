using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    public GameObject Amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //sliderValues();
    }
    public void sliderValue(float value)
    {
        //Debug.Log(value);

        //Debug.Log(Amount.GetComponent<Text>().text);
        gameObject.GetComponentInChildren<Text>().text = (Mathf.Round(GameManager.Instance.wood * value)).ToString();
        //Debug.Log(transform.Find("/Managers/UI/completeUI/ressources/wood/woodAmount").GetComponent<TextMesh>().text); //").GetComponent<Text>().text);
    }
}
