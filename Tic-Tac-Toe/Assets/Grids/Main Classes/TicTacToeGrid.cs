using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// grid used to play subgames
/// setGridNumber must be called on init
/// </summary>
public class TicTacToeGrid : MonoBehaviour {

	#region init this space
	private int gridNumber = -1;
	private SuperGrid superGrid;

	/// <summary>
	/// must be called when this space is created
	/// </summary>
	/// <param name="parentGrid"></param>
	/// <param name="assignedNumber"></param>
	public void initSpace(SuperGrid parentGrid, int assignedNumber) {
		superGrid = parentGrid;
		gridNumber = assignedNumber;
		spaceImage = GetComponent<Image>();
		for (int i = 0; i < 9; i++) {
			gameState[i] = GridValues.empty;
		}
		initHidenObjects();
		displaySmallGrid();
	}
	#endregion

	private GridValues[] gameState = new GridValues[9];
	/// <summary>
	///
	/// </summary>
	/// <returns>the current game values</returns>
	public GridValues[] getGameState() {
		return gameState;
	}

	// Use this for initialization
	void Start () {

	}

	#region display Marker For Super Grid
	[SerializeField]
	private Sprite xMark;
	[SerializeField]
	private Sprite oMark;
	[SerializeField]
	private Sprite emptyMark;
	private Image spaceImage;

	public void displayMarker(GridValues value) {
		hideSmallGrid();
		switch (value) {
			case GridValues.x:
				spaceImage.sprite = xMark;
				break;
			case GridValues.o:
				spaceImage.sprite = oMark;
				break;
			case GridValues.empty:
				spaceImage.sprite = emptyMark;
				break;
			default:
				Debug.LogError("not valid value. Grid space:" + gridNumber);
				break;
		}
	}

	public Sprite getSpriteForState(GridValues value) {
		switch (value) {
			case GridValues.x:
				return xMark;
			case GridValues.o:
				return oMark;
			case GridValues.empty:
				return emptyMark;
			default:
				Debug.LogError("invalid state for sub space sprite " + gridNumber);
				return emptyMark;
		}
	}

	//must be initalized 
	[SerializeField] //TODO init in unity
	private GameObject[] markerImages = new GameObject[9];
	private IHide[] gridBitsToHide;
	private void initHidenObjects() {
		gridBitsToHide = gameObject.GetComponentsInChildren<IHide>();
	}

	public void displaySmallGrid() {
		for (int i = 0; i < 9; i++) {
			markerImages[i].SetActive(true);
			markerImages[i].GetComponent<Image>().sprite =  getSpriteForState(gameState[i]); //set to proper image
		}
		foreach (var item in gridBitsToHide) {
			item.show();
		}
	}


	private void hideSmallGrid() {
		for (int i = 0; i < 9; i++) {
			markerImages[i].SetActive(false);
		}
		foreach (var item in gridBitsToHide) {
			item.hide();
		}
	}

	public enum GridValues {
		x, o, empty
	}

	#endregion

	#region zoom 
	/// <summary>
	/// only to be called by this grids button
	/// </summary>
	public void _ZoomButtonCall() {
		superGrid.zoomOnGameGrid(gridNumber);
	}
	#endregion

	// Update is called once per frame
	void Update () {
		
	}
}
