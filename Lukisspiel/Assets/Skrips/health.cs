using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int spieler;
    public int leben;
    public GameObject MainCamera;
    public float höchsterTreffer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (MainCamera.GetComponent<mainScript>().detectObject && MainCamera.GetComponent<mainScript>().spielerAmZug != spieler)
        {
            MainCamera.GetComponent<mainScript>().ZielObjekt = this.gameObject;
            MainCamera.GetComponent<mainScript>().hitPosition = this.transform.position + new Vector3(0, höchsterTreffer, 0);
        }
    }
}

