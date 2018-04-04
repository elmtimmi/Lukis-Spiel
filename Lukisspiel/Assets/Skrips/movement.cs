using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
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
	public int drehen;
	public GameObject ray;
	public GameObject Zielstrahl;
	// Use this for initialization
	void Start () {
		a = MainCamera.GetComponent<mainScript>();
		drehen = 2;
		Zielstrahl.GetComponent<Renderer> ().enabled = false;
	}
	void OnMouseDown()
	{
		Debug.Log("touch1");
		//if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Mouse down");

		switch (a.zufallszahl) {

		case 1:
			print ("Pistole");
			if (Waffe != null) {
				Destroy (Waffe);
			}
			Instantiate (Pistole, Pistole.transform.position, this.transform.rotation);
			Waffe = Pistole;
			break;

		case 2:
			print ("Shotgun");
			if (Waffe != null){
					Destroy (Waffe);
			}
			Instantiate(Shotgun, Shotgun.transform.position, this.transform.rotation);
			Waffe = Shotgun;
			break; 
		case 3:
			print ("MP");
			if (Waffe != null) {
				Destroy (Waffe);
			}
			Instantiate(MP, MP.transform.position, this.transform.rotation);
			Waffe = MP;
			break;
		case 4:
			print ("MG");
			if (Waffe != null) {
				Destroy (Waffe);
			}
			Instantiate(MG, MG.transform.position, this.transform.rotation);
			Waffe = MG;
			break; 
		case 5:
			print ("Minigun");
			if (Waffe != null) {
				Destroy (Waffe);
			}
			Instantiate(Minigun, Minigun.transform.position, this.transform.rotation);
			Waffe = Minigun;				break;
		case 6:
			print ("Sniper");
			if (Waffe != null) {
				Destroy (Waffe);
			}
			Instantiate(Sniper, Sniper.transform.position, this.transform.rotation);
			Waffe = Sniper;
			break;

			default:
				break;
			}
			a.zufallszahl = 0;

	}
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(ray.transform.position, ray.transform.forward * 100, Color.green);
		if (Waffe != null) {
			Waffe.transform.position = this.transform.position + new Vector3 (-1, 0, 0);
			if (drehen == 1) {
				Waffe.transform.position += new Vector3 (2f, 0, 0);
			}
			Waffe.transform.rotation = this.transform.rotation;
		}
		if (a.SpielerAmZug == spieler) {
			if (a.maxStrecke < 100) {
				// Vorwärts
				if (Input.GetKey (KeyCode.D)) {
					if (drehen == 2) {
						this.transform.position += new Vector3 (-1.5f, 0, 0);
					}
					this.transform.position += new Vector3 (0.03f, 0, 0);
					a.maxStrecke++;
					this.transform.rotation = Quaternion.Euler (0, 180, 0);
					drehen = 1;
				}
				// Rückwärts
				if (Input.GetKey (KeyCode.A)) {
					if (drehen == 1) {
						this.transform.position += new Vector3 (1.5f, 0, 0);
					}
					this.transform.position += new Vector3 (-0.03f, 0, 0);
					a.maxStrecke++;
					this.transform.rotation = Quaternion.Euler (0, 0, 0);
					drehen = 2;
				}
				// Schießen
				if (Input.GetKeyDown (KeyCode.G) && Waffe != null) {
					if (Zielstrahl.gameObject.activeSelf) {
						Zielstrahl.GetComponent<Renderer> ().enabled = false;
					} else {
						Zielstrahl.GetComponent<Renderer> ().enabled = true;
						Zielstrahl.transform.rotation = Quaternion.Euler (0, 0, 0);
					}
				}
				if (Waffe == Pistole) {
					while (this.transform.rotation == Quaternion.Euler (30, 0, 0)) {
						Zielstrahl.transform.Rotate (2, 0, 0);
					}
					while (this.transform.rotation == Quaternion.Euler (-30, 0, 0)) {
						Zielstrahl.transform.Rotate (-2, 0, 0);
					}
				}

				if (Waffe == Shotgun) {
					while (this.transform.rotation == Quaternion.Euler (30, 0, 0)) {
						Zielstrahl.transform.Rotate (5, 0, 0);
					}
					while (this.transform.rotation == Quaternion.Euler (-30, 0, 0)) {
						Zielstrahl.transform.Rotate (-5, 0, 0);
					}
				}

				if (Waffe == MP) {
					while (this.transform.rotation == Quaternion.Euler (30, 0, 0)) {
						Zielstrahl.transform.Rotate (3, 0, 0);
					}
					while (this.transform.rotation == Quaternion.Euler (-30, 0, 0)) {
						Zielstrahl.transform.Rotate (-3, 0, 0);
					}
				}

				if (Waffe == MG) {
					while (this.transform.rotation == Quaternion.Euler (30, 0, 0)) {
						Zielstrahl.transform.Rotate (2, 0, 0);
					}
					while (this.transform.rotation == Quaternion.Euler (-30, 0, 0)) {
						Zielstrahl.transform.Rotate (-2, 0, 0);
					}
				}

				if (Waffe == Minigun) {
					while (this.transform.rotation == Quaternion.Euler (30, 0, 0)) {
						Zielstrahl.transform.Rotate (3, 0, 0);
					}
					while (this.transform.rotation == Quaternion.Euler (-30, 0, 0)) {
						Zielstrahl.transform.Rotate (-3, 0, 0);
					}
				}

				if (Waffe == Sniper) {
					while (this.transform.rotation == Quaternion.Euler (30, 0, 0)) {
						Zielstrahl.transform.Rotate (1, 0, 0);
					}
					while (this.transform.rotation == Quaternion.Euler (-30, 0, 0)) {
						Zielstrahl.transform.Rotate (-1, 0, 0);
					}
				}

			}
		} else { 
			Zielstrahl.GetComponent<Renderer> ().enabled = false;
		}	
	}
}
	