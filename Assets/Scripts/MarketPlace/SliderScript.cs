using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public int bevölkerung = 200; // In Public Variablen schreiben und aus diesen Ziehen. Vorerst als Testvariable;
    private int newAmount;
    public Text SellAmount;
    public Text ressource;
    public Text price;

    public GameObject MarketPlace;

    public int handelsmengeStein;
    public int handelsmengeHOlz;


    private void Start()
    {
        MarketPlace = GameObject.Find("MarketPlaceInterface");
    }


    public void sliderValue(float value)
    {
        //Debug.Log(UsedRessource);
        //Debug.Log(GameManager.Instance.GetResourceAmount(ressource.text));
         
        //Angezeigte Menge aktualisieren
        if(value < 0f)
        {
            newAmount = Mathf.RoundToInt(MarketPlace.GetComponent<MarketPlace>().woodAmount * value);
        }
        else
        {
            newAmount = Mathf.RoundToInt(GameManager.Instance.GetResourceAmount(ressource.text) * value);
        }
        

        SellAmount.text = newAmount.ToString();

        //Aufruf der Funktion zum berechnen des Verkaufswertes
        calculateSellPrice(newAmount);
    }
    public void calculateSellPrice(int amount)
    {
        var neededperHundred = float.Parse(getRessourceInfo(ressource.text, "normalAmountPerHundred")); //Statt aus XML AUS GAMEMANGER!!!

        //Benötigte ressourcen ermitteln.
        int neededRessource = Mathf.RoundToInt( neededperHundred / 100f * bevölkerung)- handelsmengeHOlz;
        
        //Preis ermitteln bei 3% Preisverhandlungen
        var priceToTrade = (gaußscheSumme(neededRessource) - gaußscheSumme(neededRessource - amount)) * 0.03 + amount * int.Parse(getRessourceInfo(ressource.text, "normalPrice"));
        //Anzeige über zu handelnde Ware aktualisieren.
        price.text = (priceToTrade).ToString();
    }
    public string getRessourceInfo(string ressourceName, string info)
    {
        var gotInfo = MarketPlace.GetComponent<MarketPlace>().getRessourceInformation(ressourceName, info);
        return gotInfo;
    }

    public int gaußscheSumme(int i)
    {
        var a = (i * (i + 1)) / 2;
        return a;
    }

    public void traden()
    {
        
        GameManager.Instance.AddResource(ressource.text, int.Parse(SellAmount.text)*-1);
        //MarktplatzInventar anpassen
        handelsmengeHOlz = handelsmengeHOlz + int.Parse(SellAmount.text);
        sliderValue(0f);
        GetComponent<Slider>().value = 0;
    }

}
