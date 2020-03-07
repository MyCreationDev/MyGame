using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{

    public int bevölkerung = 200; // In Public Variablen schreiben und aus diesen Ziehen. Vorerst als Testvariable;
    private int newAmount;
    public Transform SellAmount;
   public void sliderValue(float value)
   {

        //Angezeigte Menge aktualisieren
        newAmount = Mathf.RoundToInt(GameManager.Instance.stone*value); //ABSTRAHIEREN
        transform.Find("AmountValue").GetComponent<Text>().text = newAmount.ToString();

        //Aufruf der Funktion zum berechnen des Verkaufswertes


        calculateSellPrice(newAmount);
        //Debug.Log(transform.Find("/Managers/UI/completeUI/ressources/wood/woodAmount").GetComponent<TextMesh>().text); //").GetComponent<Text>().text);
    }
    public double calculateSellPrice(int amount)
    {
        var getInfoAboutRessource = transform.parent.parent.parent.GetComponent<MarketPlace>();
        var neededperHundred = float.Parse(getInfoAboutRessource.getRessourceInformation("stone", "normalAmountPerHundred")); //


        int neededRessource = Mathf.RoundToInt( neededperHundred / 100f * bevölkerung)-12;
        
        var price = (gaußscheSumme(neededRessource) - gaußscheSumme(neededRessource - amount)) * 0.1 + amount;
        //Debug.Log(price);
        SellAmount.GetComponent<Text>().text = price.ToString();
        return price;
    }

    public int gaußscheSumme(int i)
    {
        var a = (i * (i + 1)) / 2;
        return a;
    }

}
