using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Text MyText;
    public static int PassengersInBus;


    // Update is called once per frame

    void Update() // text for score.
    {
        PassengersInBus = BusCollider.Passengers;
        MyText.text = "Passengers in Bus: " + PassengersInBus.ToString("F0") + " out of 50";
        if (BusCollider.Passengers >= 5)
        {
            Debug.Log("You Lost");
            Application.Quit();
        }
    }
}
