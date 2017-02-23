using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideSubSpacers : MonoBehaviour, IHide {
	public void hide() {
		gameObject.SetActive(false);
	}

	public void show() {
		gameObject.SetActive(true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
