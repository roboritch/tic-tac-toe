using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperGrid : MonoBehaviour {

	#region prefabs
	[SerializeField]
	GameObject gameGrid;


	#endregion

	private static int numbSpaces = 3;
	private TicTacToeGrid[,] games = new TicTacToeGrid[numbSpaces,numbSpaces];
		
	/// <summary>
	/// creates the 9 game grids from the prefab and places them in games
	/// </summary>
	private void spawnGameGrids() {
		for (int x = 0; x < numbSpaces; x++) {
			for (int y = 0; y < numbSpaces; y++) {
				games[x,y] = Instantiate(gameGrid).GetComponent<TicTacToeGrid>();
				
				//games[x, y].GetComponent<RectTransform>().anchoredPosition;


			}
		}
	}

	// Use this for initialization
	void Start () {
		spawnGameGrids();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
