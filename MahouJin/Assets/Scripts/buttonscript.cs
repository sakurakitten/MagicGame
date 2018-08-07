using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonscript : MonoBehaviour {
	GameObject pcObj;
	// Use this for initialization
	void Start () {
		pcObj = GameObject.Find( "player" );
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonPush(){
		player pc = pcObj.GetComponent<player>();
		pc.whenbuttonpushed(0);
	}
}
