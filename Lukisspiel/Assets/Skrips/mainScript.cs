using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    public bool start;
    public int spielerAmZug = 1;
    public int maxStrecke = 0;
    public int zufallszahl;
    public int schonGewürfelt = 0;
    public GameObject Würfeln;
    public GameObject SpielerAmZug;
    public GameObject ZugBeenden;
    public GameObject Los;
    public string spieler1;
    public string spieler2;
    public GameObject text1;
    public GameObject text2;
    public GameObject ZielObjekt;
    public bool detectObject;
    public Vector3 hitPosition;
    public GameObject Console;
    public string consolenText;
    // Use this for initialization
    void Start()
    {
        spielerAmZug = 1;
        spieler1 = "Spieler 1";
        spieler2 = "Spieler 2";
    }

    // Update is called once per frame
    void Update()
    {
        Console.transform.Find("Text1").gameObject.GetComponent<Text>().text = consolenText;
        if (!start)
        {
            schonGewürfelt = 1;
            this.transform.position = new Vector3(500, 500, 0);
            SpielerAmZug.gameObject.SetActive(false);
            ZugBeenden.gameObject.SetActive(false);
            Console.gameObject.SetActive(false);
        }
        if (schonGewürfelt == 0)
        {
            Würfeln.gameObject.SetActive(true);
        }
        else
        {
            Würfeln.gameObject.SetActive(false);
        }
    }
    public void los()
    {
        start = true;
        schonGewürfelt = 0;
        this.transform.position = new Vector3(0, 0, -10);
        SpielerAmZug.gameObject.SetActive(true);
        ZugBeenden.gameObject.SetActive(true);
        Console.gameObject.SetActive(true);
        if (text1.GetComponent<Text>().text != "")
        {
            spieler1 = text1.GetComponent<Text>().text;
        }
        if (text2.GetComponent<Text>().text != "")
        {
            spieler2 = text2.GetComponent<Text>().text;
        }
        Los.gameObject.SetActive(false);
        SpielerAmZug.GetComponent<Text>().text = spieler1;
    }
    public void zugBeenden()
    {
        consolenText = "";
        maxStrecke = 0;
        spielerAmZug++;
        if (spielerAmZug == 3)
        {
            spielerAmZug = 1;
            SpielerAmZug.GetComponent<Text>().text = spieler1;
        }
        if (spielerAmZug == 2)
        {
            SpielerAmZug.GetComponent<Text>().text = spieler2;
        }
        schonGewürfelt = 0;
    }
    public void würfeln()
    {
        if (schonGewürfelt == 0)
        {
            zufallszahl = Random.Range(1, 7);
            print("Du hast eine " + zufallszahl + " gewürfelt");
            schonGewürfelt++;
            if(zufallszahl == 1)
            {
                consolenText = "Du bekommst eine Pistole";
            }
            if (zufallszahl == 2)
            {
                consolenText = "Du bekommst eine Shotgun";
            }
            if (zufallszahl == 3)
            {
                consolenText = "Du bekommst eine Mp";
            }
            if (zufallszahl == 4)
            {
                consolenText = "Du bekommst ein MG";
            }
            if (zufallszahl == 5)
            {
                consolenText = "Du bekommst eine Minigun";
            }
            if (zufallszahl == 6)
            {
                consolenText = "Du bekommst eine Sniper";
            }
        }
    }
}
