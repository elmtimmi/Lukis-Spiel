using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    public bool start;
    public int spielerAmZug = 1;
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
    public GameObject Mensch;
    public GameObject Panzer;
    public GameObject Flughafen;
    public GameObject Haus1;
    public GameObject Haus2;
    int objektNummer;
    bool neuerFlughafen;
    // Use this for initialization
    void Start()
    {
        spielerAmZug = 1;
        spieler1 = "Spieler 1";
        spieler2 = "Spieler 2";
        GameObject neuerSpieler = Instantiate(Mensch, new Vector3(Haus1.transform.position.x, -2f, 0), Quaternion.identity);
        neuerSpieler.transform.Find("Skript").gameObject.GetComponent<movement>().spieler = 1;
        neuerSpieler.transform.Find("Skript").gameObject.GetComponent<health>().spieler = 1;
        neuerSpieler.transform.Find("Skript").name = "Skript1";

        GameObject neuerSpieler2 = Instantiate(Mensch, new Vector3(Haus2.transform.position.x, -2f, 0), Quaternion.identity);
        neuerSpieler2.transform.Find("Skript").gameObject.GetComponent<movement>().spieler = 2;
        neuerSpieler2.transform.Find("Skript").gameObject.GetComponent<health>().spieler = 2;
        neuerSpieler2.transform.Find("Skript").name = "Skript2";
        objektNummer = 3;
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
        zufallszahl = 0;
    }
    public void würfeln()
    {
        if (schonGewürfelt == 0)
        {
            zufallszahl = Random.Range(1, 10);
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
            if (zufallszahl == 7)
            {
                consolenText = "Du bekommst eine weitere Person";
                zufallszahl = 0;
                if (spielerAmZug == 1)
                {
                    GameObject neuerSpieler = Instantiate(Mensch, new Vector3 (Haus1.transform.position.x, -2f, 0), Quaternion.identity);
                    neuerSpieler.transform.Find("Skript").gameObject.GetComponent<movement>().spieler = 1;
                    neuerSpieler.transform.Find("Skript").gameObject.GetComponent<health>().spieler = 1;
                    neuerSpieler.transform.Find("Skript").name = "Skript" + objektNummer;
                    objektNummer++;
                }
                if (spielerAmZug == 2)
                {
                    GameObject neuerSpieler = Instantiate(Mensch, new Vector3(Haus2.transform.position.x, -2f, 0), Quaternion.identity);
                    neuerSpieler.transform.Find("Skript").gameObject.GetComponent<movement>().spieler = 2;
                    neuerSpieler.transform.Find("Skript").gameObject.GetComponent<health>().spieler = 2;
                    neuerSpieler.transform.Find("Skript").name = "Skript" + objektNummer;
                    objektNummer++;
                }

            }
            if (zufallszahl == 8)
            {
                consolenText = "Du bekommst einen Panzer";
                zufallszahl = 0;
                if (spielerAmZug == 1)
                {
                    GameObject neuerSpieler = Instantiate(Panzer, new Vector3(Haus1.transform.position.x, -2f, 0), Quaternion.identity);
                    neuerSpieler.transform.Find("Skript").gameObject.GetComponent<movement>().spieler = 1;
                    neuerSpieler.transform.Find("Skript").gameObject.GetComponent<health>().spieler = 1;
                    neuerSpieler.transform.Find("Skript").name = "Skript" + objektNummer;
                    objektNummer++;
                }
                if (spielerAmZug == 2)
                {
                    GameObject neuerPanzer = Instantiate(Panzer, new Vector3(Haus2.transform.position.x, -2f, 0), Quaternion.identity);
                    neuerPanzer.transform.Find("Skript").gameObject.GetComponent<movement>().spieler = 2;
                    neuerPanzer.transform.Find("Skript").gameObject.GetComponent<health>().spieler = 2;
                    neuerPanzer.transform.Find("Skript").name = "Skript" + objektNummer;
                    objektNummer++;
                }
            }
            if (zufallszahl == 9)
            {
                consolenText = "Du bekommst einen Flughafen";
                GameObject neuerFlughafen = Instantiate(Flughafen, new Vector3(Input.mousePosition.x, -6.08f, 1), Quaternion.identity);
                if (spielerAmZug == 1)
                {
                    neuerFlughafen.gameObject.GetComponent<health>().spieler = 1;
                }
                if (spielerAmZug == 1)
                {
                    neuerFlughafen.gameObject.GetComponent<health>().spieler = 2;
                }
            }
        }
    }
}