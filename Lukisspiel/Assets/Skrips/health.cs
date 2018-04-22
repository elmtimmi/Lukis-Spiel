using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int spieler;
    public int leben;
    public GameObject MainCamera;
    public float höchsterTreffer;
    public GameObject Leben;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<health>().leben <= 0)
        {
            if (this.GetComponent<movement>() != null)
            {
                Destroy(this.GetComponent<movement>().Waffe.gameObject);
            }
            Destroy(this.gameObject);
        }
        Leben.GetComponent<TextMesh>().text = "" + this.GetComponent<health>().leben;
        Leben.transform.rotation = Quaternion.identity;
    }
    void OnMouseDown()
    {
        if (MainCamera.GetComponent<mainScript>().detectObject && MainCamera.GetComponent<mainScript>().spielerAmZug != spieler)
        {
            Debug.Log(this.transform.name);
            MainCamera.GetComponent<mainScript>().ZielObjekt = this.gameObject;
            MainCamera.GetComponent<mainScript>().hitPosition = this.transform.position + new Vector3(0, höchsterTreffer, 0);
        }
    }
}