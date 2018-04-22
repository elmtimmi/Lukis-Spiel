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
    public GameObject Capsule;
    public bool activeSpieler;
    bool einmaligerDürchlauf;
    public bool schießen;
    public int geschossen;
    public int maxSchuss;
    public int maxStrecke;
    float maxRange = 500;
    public bool mensch;
    public bool panzer;
    RaycastHit hit;
    // Use this for initialization
    void Start()
    {
        a = MainCamera.GetComponent<mainScript>();
        maxStrecke = 0;
    }
    void OnMouseDown()
    {
        if (a.spielerAmZug == spieler)
        {
            activeSpieler = true;
            einmaligerDürchlauf = true;
            if (mensch)
            {
                if (a.zufallszahl != 0)
                {
                    a.consolenText = "Waffe ausgerüstet";
                }
                switch (a.zufallszahl)
                {
                    case 1:
                        print("Pistole");
                        if (Waffe != null)
                        {
                            Destroy(Waffe);
                        }
                        Waffe = Instantiate(Pistole, Pistole.transform.position, this.transform.rotation);
                        maxSchuss = 1;
                        break;

                    case 2:
                        print("Shotgun");
                        if (Waffe != null)
                        {
                            Destroy(Waffe);
                        }
                        Waffe = Instantiate(Shotgun, Shotgun.transform.position, this.transform.rotation);
                        maxSchuss = 1;
                        break;
                    case 3:
                        print("MP");
                        if (Waffe != null)
                        {
                            Destroy(Waffe);
                        }
                        Waffe = Instantiate(MP, MP.transform.position, this.transform.rotation);
                        maxSchuss = 3;
                        break;
                    case 4:
                        print("MG");
                        if (Waffe != null)
                        {
                            Destroy(Waffe);
                        }
                        Waffe = Instantiate(MG, MG.transform.position, this.transform.rotation);
                        maxSchuss = 2;
                        break;
                    case 5:
                        print("Minigun");
                        if (Waffe != null)
                        {
                            Destroy(Waffe);
                        }
                        Waffe = Instantiate(Minigun, Minigun.transform.position, this.transform.rotation);
                        maxSchuss = 4;
                        break;
                    case 6:
                        print("Sniper");
                        if (Waffe != null)
                        {
                            Destroy(Waffe);
                        }
                        Waffe = Instantiate(Sniper, Sniper.transform.position, this.transform.rotation);
                        maxSchuss = 1;
                        break;
                    default:
                        break;
                }
                a.zufallszahl = 0;
            }
        }
        else
        {
          //  a.consolenText = "Dieser Spieler gehört dir nicht";
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(spieler == 1)
        {
            if (mensch)
            {
                this.transform.Find("Kopf").gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            if (panzer)
            {
                this.transform.Find("Tower").gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        if (spieler == 2)
        {
            if (mensch)
            {
                this.transform.Find("Kopf").gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            if (panzer)
            {
                this.transform.Find("Tower").gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
        }
        Debug.DrawRay(ray.transform.position, (a.hitPosition - ray.transform.position), Color.green);
        if (Input.GetMouseButtonDown(0) && !einmaligerDürchlauf)
        {
            activeSpieler = false;
           // RaycastHit2D hitt = Physics2D.Raycast(transform.position, (a.hitPosition - transform.position));
            if (schießen && Physics.Raycast(ray.transform.position, (a.hitPosition - ray.transform.position), out hit, maxRange))
            {
                if (a.ZielObjekt != null)
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.GetChild(0) != null && hit.transform.GetChild(0).name == a.ZielObjekt.transform.name || hit.transform.parent != null && hit.transform.parent.transform.name == a.ZielObjekt.transform.name)
                    {
                        Debug.Log(hit.transform.name);
                        // In Range and i can see you!

                        if (Waffe != null && schießen || panzer && schießen)
                        {
                            schießen = false;
                            a.detectObject = false;
                            float abstand = this.transform.position.x - a.ZielObjekt.transform.position.x;
                            abstand = Math.Abs(abstand);
                            int random = UnityEngine.Random.Range(1, 11);
                            if (mensch)
                            {
                                if (Waffe.transform.name == Pistole.transform.name + "(Clone)")
                                {
                                    if (abstand < 4)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 8;
                                            a.consolenText = "Feind 8 Leben abgezogen (kr.)";
                                        }
                                        else
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 4;
                                            a.consolenText = "Feind 4 Leben abgezogen";
                                        }
                                    }
                                    else if (abstand < 7)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 8;
                                            a.consolenText = "Feind 8 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 8)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 4;
                                            a.consolenText = "Feind 4 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }
                                    else
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 6;
                                            a.consolenText = "Feind 6 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 6)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 3;
                                            a.consolenText = "Feind 3 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }
                                }
                                else if (Waffe.transform.name == MP.transform.name + "(Clone)")
                                {
                                    if (abstand < 4)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 4;
                                            a.consolenText = "Feind 4 Leben abgezogen (kr.)";
                                        }
                                        else
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 3;
                                            a.consolenText = "Feind 2 Leben abgezogen";
                                        }
                                    }
                                    else if (abstand < 6)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 4;
                                            a.consolenText = "Feind 4 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 7)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 3;
                                            a.consolenText = "Feind 2 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }
                                    else
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 2;
                                            a.consolenText = "Feind 2 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 5)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 1;
                                            a.consolenText = "Feind 1 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }

                                }
                                else if (Waffe.transform.name == MG.transform.name + "(Clone)")
                                {
                                    if (abstand < 4)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 6;
                                            a.consolenText = "Feind 6 Leben abgezogen (kr.)";
                                        }
                                        else
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 4;
                                            a.consolenText = "Feind 4 Leben abgezogen";
                                        }
                                    }
                                    else if (abstand < 7)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 6;
                                            a.consolenText = "Feind 6 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 7)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 4;
                                            a.consolenText = "Feind 4 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }
                                    else
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 5;
                                            a.consolenText = "Feind 5 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 6)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 3;
                                            a.consolenText = "Feind 3 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }
                                }
                                else if (Waffe.transform.name == Shotgun.transform.name + "(Clone)")
                                {
                                    if (abstand < 4)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 20;
                                            a.consolenText = "Feind 20 Leben abgezogen (kr.)";
                                        }
                                        else
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 10;
                                            a.consolenText = "Feind 10 Leben abgezogen";
                                        }
                                    }
                                    else if (abstand < 7)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 10;
                                            a.consolenText = "Feind 10 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 7)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 6;
                                            a.consolenText = "Feind 6 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }
                                    else
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 3;
                                            a.consolenText = "Feind 3 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }
                                }
                                else if (Waffe.transform.name == Minigun.transform.name + "(Clone)")
                                {
                                    if (abstand < 4)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 4;
                                            a.consolenText = "Feind 4 Leben abgezogen (kr.)";
                                        }
                                        else
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 3;
                                            a.consolenText = "Feind 2 Leben abgezogen";
                                        }
                                    }
                                    else if (abstand < 6)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 4;
                                            a.consolenText = "Feind 4 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 7)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 3;
                                            a.consolenText = "Feind 2 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }
                                    else
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 3;
                                            a.consolenText = "Feind 2 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 4)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 2;
                                            a.consolenText = "Feind 1 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }
                                }
                                else if (Waffe.transform.name == Sniper.transform.name + "(Clone)")
                                {
                                    if (abstand < 25 && abstand > 15)
                                    {
                                        Debug.Log("jojojo" + abstand);

                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 15;
                                            a.consolenText = "Feind 20 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 6)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 9;
                                            a.consolenText = "Feind 9 Leben abgezogen";
                                        }
                                        else
                                        {
                                            a.consolenText = "Schuss daneben";
                                        }
                                    }
                                    else if (abstand >= 4)
                                    {
                                        if (random == 1)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 12;
                                            a.consolenText = "Feind 12 Leben abgezogen (kr.)";
                                        }
                                        else if (random < 6)
                                        {
                                            a.ZielObjekt.GetComponent<health>().leben -= 7;
                                            a.consolenText = "Feind 7 Leben abgezogen";
                                        }
                                    }
                                    else
                                    {
                                        a.ZielObjekt.GetComponent<health>().leben -= 5;
                                        a.consolenText = "Feind 5 Leben abgezogen";
                                    }
                                }
                                a.ZielObjekt = null;
                                geschossen++;
                            }
                            if (panzer)
                            {
                                if(abstand > 20)
                                {
                                    if (random == 1)
                                    {
                                        a.ZielObjekt.GetComponent<health>().leben -= 15;
                                        a.consolenText = "Feind 15 Leben abgezogen (kr.)";
                                    }
                                    else if (random < 5)
                                    {
                                        a.ZielObjekt.GetComponent<health>().leben -= 8;
                                        a.consolenText = "Feind 8 Leben abgezogen";
                                    }
                                    else
                                    {
                                        a.consolenText = "Schuss daneben";
                                    }
                                }
                                else if (abstand > 10)
                                {
                                    if (random == 1)
                                    {
                                        a.ZielObjekt.GetComponent<health>().leben -= 15;
                                        a.consolenText = "Feind 15 Leben abgezogen (kr.)";
                                    }
                                    else if (random < 6)
                                    {
                                        a.ZielObjekt.GetComponent<health>().leben -= 10;
                                        a.consolenText = "Feind 10 Leben abgezogen";
                                    }
                                    else
                                    {
                                        a.consolenText = "Schuss daneben";
                                    }
                                }
                                else if(abstand > 5)
                                {
                                    if (random == 1)
                                    {
                                        a.ZielObjekt.GetComponent<health>().leben -= 15;
                                        a.consolenText = "Feind 15 Leben abgezogen (kr.)";
                                    }
                                    else if (random < 7)
                                    {
                                        a.ZielObjekt.GetComponent<health>().leben -= 10;
                                        a.consolenText = "Feind 10 Leben abgezogen";
                                    }
                                    else
                                    {
                                        a.consolenText = "Schuss daneben";
                                    }
                                }
                                else
                                {
                                    a.ZielObjekt.GetComponent<health>().leben -= 10;
                                    a.consolenText = "Feind 10 Leben abgezogen";
                                }
                                geschossen++;
                            }
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
                    Debug.Log("Kein Zielobject");
                }
            }
            else if(schießen)
            {
                a.consolenText = "Falsches Ziel";
                geschossen--;
                Debug.Log("Ray geht ins nichts");
            }
        }
        else
        {
            einmaligerDürchlauf = false;
        }
        Capsule.GetComponent<Renderer>().enabled = false;
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
            if (maxStrecke < 100)
            {
                // Vorwärts
                if (Input.GetKey(KeyCode.D))
                {
                    this.transform.position += new Vector3(0.03f, 0, 0);
                    maxStrecke++;
                    if (mensch)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    if (panzer)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
                // Rückwärts
                if (Input.GetKey(KeyCode.A))
                {
                    this.transform.position += new Vector3(-0.03f, 0, 0);
                    maxStrecke++;
                    if (mensch)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    if (panzer)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                }  
            }
            // Schießen
            if (Input.GetKey(KeyCode.G) && Waffe != null && !schießen && mensch || Input.GetKey(KeyCode.G) && !schießen && panzer)
            {
                if (geschossen < maxSchuss)
                {
                    a.consolenText = "Wähle ein Ziel";
                    schießen = true;
                    a.detectObject = true;
                }
                else
                {
                    a.consolenText = "Munition verbraucht!";
                }
            }
        }
        else
        {
           // schießen = false;
        }
        if (a.spielerAmZug != spieler)
        {
            geschossen = 0;
            schießen = false;
            maxStrecke = 0;
        }
    }
}