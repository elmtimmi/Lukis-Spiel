using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour {
	public int SpielerAmZug = 1;
	public int maxStrecke = 0;
	public int zufallszahl;
	public int schonGewürfelt = 0;
	// Use this for initialization
	void Start () {
		SpielerAmZug = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI (){
		if (GUI.Button (new Rect (10,10,100,30), "Zug beenden")){
			print ("Nächster Spieler an der Reihe!");
			maxStrecke = 0;
			SpielerAmZug++;
			if (SpielerAmZug == 3) {
				SpielerAmZug = 1;
			}
			schonGewürfelt = 0;
		}
		if (schonGewürfelt == 0) {
			if (GUI.Button (new Rect (10, 60, 100, 30), "Würfeln!")) {
				zufallszahl = Random.Range (1, 7);
				print ("Du hast eine " + zufallszahl + " gewürfelt");
				schonGewürfelt++;
			}


		}
	}

}
