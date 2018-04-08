using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movement : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Pistole;
    public GameObject Shotgun;
    public GameObject MP;
    public GameObject MG;
    public GameObject Minigun;
    public GameObject Sniper;
    private mainScript a;
    public int spieler;
    public GameObject Waffe;
    public GameObject ray;
    public GameObject Zielstrahl;
    public GameObject Capsule;
    public bool activeSpieler;
    bool einmaligerDürchlauf;
    public GameObject Leben;
    public bool schießen;
    public bool geschossen;

    float maxRange = 500;
    RaycastHit hit;
    // Use this for initialization
    void Start()
    {
        a = MainCamera.GetComponent<mainScript>();
    }
    void OnMouseDown()
    {
        if (a.spielerAmZug == spieler)
        {
            activeSpieler = true;
        }
        einmaligerDürchlauf = true;
        switch (a.zufallszahl)
        {
            case 1:
                print("Pistole");
                if (Waffe != null)
                {
                    Destroy(Waffe);
                }
                Waffe = Instantiate(Pistole, Pistole.transform.position, this.transform.rotation);
                break;

            case 2:
                print("Shotgun");
                if (Waffe != null)
                {
                    Destroy(Waffe);
                }
                Waffe = Instantiate(Shotgun, Shotgun.transform.position, this.transform.rotation);
                break;
            case 3:
                print("MP");
                if (Waffe != null)
                {
                    Destroy(Waffe);
                }
                Waffe = Instantiate(MP, MP.transform.position, this.transform.rotation);
                break;
            case 4:
                print("MG");
                if (Waffe != null)
                {
                    Destroy(Waffe);
                }
                Waffe = Instantiate(MG, MG.transform.position, this.transform.rotation);
                break;
            case 5:
                print("Minigun");
                if (Waffe != null)
                {
                    Destroy(Waffe);
                }
                Waffe = Instantiate(Minigun, Minigun.transform.position, this.transform.rotation);
                break;
            case 6:
                print("Sniper");
                if (Waffe != null)
                {
                    Destroy(Waffe);
                }
                Waffe = Instantiate(Sniper, Sniper.transform.position, this.transform.rotation);
                break;

            default:
                break;
        }
        a.zufallszahl = 0;

    }
    // Update is called once per frame
    void Update()
    {
        if(spieler == 1)
        {
            this.transform.Find("Kopf").gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (spieler == 2)
        {
            this.transform.Find("Kopf").gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetMouseButtonDown(0) && !einmaligerDürchlauf)
        {
            activeSpieler = false;
            //Debug.DrawRay(ray.transform.position, (a.hitPosition - transform.position), Color.green);
            if (schießen && Physics.Raycast(Waffe.transform.position, (a.hitPosition - Waffe.transform.position), out hit, maxRange))
            {
                if (a.ZielObjekt != null)
                {
                    if (hit.transform.parent.name == a.ZielObjekt.transform.name)
                    {
                        Debug.Log(hit.transform.name);
                        Debug.Log(hit.transform.parent.transform.name);
                        // In Range and i can see you!

                        if (Waffe != null && schießen && a.ZielObjekt != null)
                        {
                            schießen = false;
                            a.detectObject = false;
                            a.ZielObjekt.GetComponent<health>().leben -= 5;
                            a.consolenText = "Feind getroffen";
                            a.ZielObjekt = null;
                            geschossen = true;
                        }
                    }
                    else
                    {
                        a.consolenText = "Gegenstand im Weg!";
                    }
                }
                else
                {
                    a.consolenText = "Falsches Ziel";
                }
            }
            else if(schießen)
            {
                a.consolenText = "Falsches Ziel";
            }
        }
        else
        {
            einmaligerDürchlauf = false;
        }
        Capsule.GetComponent<Renderer>().enabled = false;
        Leben.GetComponent<TextMesh>().text = "" + this.GetComponent<health>().leben;
        Leben.transform.rotation = Quaternion.identity;
        if (this.GetComponent<health>().leben <= 0)
        {
            Destroy(Waffe.gameObject);
            Destroy(this.gameObject);
        }
        if (Waffe != null)
        {
            Waffe.transform.rotation = this.transform.rotation;
            if (this.transform.rotation.y == -1)
            {
                Waffe.transform.position = this.transform.position + new Vector3(0.35f, 0, 0);
            }
            else if (this.transform.rotation.y == 0)
            {
                Waffe.transform.position = this.transform.position - new Vector3(0.35f, 0, 0);
            }else
            {
                Waffe.transform.position = this.transform.position + new Vector3(0.35f, 0, 0);
            }
        }
        if (a.spielerAmZug == spieler && activeSpieler)
        {
            Capsule.GetComponent<Renderer>().enabled = true;
            Capsule.GetComponent<Renderer>().material.color = Color.blue;
            if (a.maxStrecke < 100)
            {
                // Vorwärts
                if (Input.GetKey(KeyCode.D))
                {
                    this.transform.position += new Vector3(0.03f, 0, 0);
                    a.maxStrecke++;
                    this.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                // Rückwärts
                if (Input.GetKey(KeyCode.A))
                {
                    this.transform.position += new Vector3(-0.03f, 0, 0);
                    a.maxStrecke++;
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                // Schießen
                if (Input.GetKey(KeyCode.G) && Waffe != null && !schießen && !geschossen)
                {
                    schießen = true;
                    a.detectObject = true;
                }
            }
        }
        else
        {
           // schießen = false;
        }
        if (a.spielerAmZug != spieler)
        {
            geschossen = false;
            schießen = false;
        }
    }
}
	