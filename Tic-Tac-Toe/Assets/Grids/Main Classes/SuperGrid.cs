using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperGrid : MonoBehaviour {

	#region prefabs
	[SerializeField]
	GameObject ticGrid;
	
	#endregion

	private static int numbSpaces = 9;
	private TicTacToeGrid[] games = new TicTacToeGrid[numbSpaces]; //spaces are bottem left to top right
	private bool[] gameWonState = new bool[numbSpaces];
	[SerializeField]
	private GameObject[] subGameAlingments = new GameObject[9];

	/// <summary>
	/// creates the 9 game grids from the prefab and places them in games
	/// </summary>
	private void spawnGameGrids() {
		for (int x = 0; x < numbSpaces; x++) {
			gameWonState[x] = false;
			games[x] = Instantiate(ticGrid).GetComponent<TicTacToeGrid>();
			games[x].initSpace(this, x);
			games[x].transform.SetParent(subGameAlingments[x].transform);
			games[x].transform.localPosition = new Vector3(); // center the grid space on it's parent
			
		}
	}


	#region subGame visibilty
	private void setVisabiltyOfASubGame(int gameNumb, bool state) {
		games[gameNumb].gameObject.SetActive(state);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="state">true for visable. false for invisable</param>
	private void changeSubGameVisabily(bool state) {
		for (int i = 0; i < numbSpaces; i++) {
			setVisabiltyOfASubGame(i, state);
		}
	}
	#endregion

	#region subGame zoom
	int gameZoomed = -1;
	/// <summary>
	/// Has all the small game grids use their image to display the state of the specificed game
	/// </summary>
	/// <param name="gameNumber"></param>
	public void zoomOnGameGrid(int gameNumber) {
		for (int i = 0; i < numbSpaces; i++) {
			games[i].displayMarker(games[gameNumber].getGameState()[i]);
		}
	}

	private void unZoom() {
		
	}
	#endregion

	// Use this for initialization
	void Start () {
		spawnGameGrids();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}