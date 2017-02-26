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

	#region main unity refrances
	[SerializeField]
	private GameObject[] subGameAlingments = new GameObject[9];
	[SerializeField]
	private CurrentPlayer currentPlayerHandler;
	#endregion

	/// <summary>
	/// creates the 9 game grids from the prefab and places them in the game world games
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

	/// <summary>
	/// place a marker on a subgrid 
	/// </summary>
	/// <param name="spaceNumber">indexed from 0, bottem left to top right</param>
	public void placeSubGridMarker(int spaceNumber) {
		//call setGameState from tic tac toe
		if (games[gameZoomed].setGameState(spaceNumber, currentPlayerHandler.getCurrentPlayer())) {
			currentPlayerHandler.changePlayer();
			unZoom();
		} else {
			Debug.Log("space not empty");
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
			games[i].setButtonToPlaceMarker(placeSubGridMarker);
		}
		gameZoomed = gameNumber;
	}

	private void unZoom() {
		for (int i = 0; i < numbSpaces; i++) {
			games[i].displaySmallGrid();
			games[i].setButtonToZoom();
		}
		gameZoomed = -1;
	}
	#endregion

	// Use this for initialization
	void Start () {
		spawnGameGrids();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)) {
			unZoom();
		}

		//keybord input for game grid
		for (int i = 0; i < numbSpaces; i++) {
			if (Input.GetKeyDown(KeyCode.Keypad1 + i) || Input.GetKeyDown(KeyCode.Alpha1 + i)) {
				if (gameZoomed != -1) {
					placeSubGridMarker(i);
				} else {
					zoomOnGameGrid(i);
				}
			}
		}

	}
}