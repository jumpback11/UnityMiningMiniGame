using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	// The Grid itself
	public static int gridWidth = 9;
	public static int gridHeight = 8;
	public Transform[,] grid = new Transform[gridWidth,gridHeight];
	//public GameObject explosion = Resources.Load<GameObject>("explosion");
	private GameController gameController;
	public GameObject dirt, common, uncommon, rare, cover;
	
	void Start()
	{
		/*GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("cannot find 'GameController' script");
		}*/

		SetGridValues ();
		CoverGrid ();
	}
	

	
	public void SetGridValues()
	{
		int x, z;
		for (x = 0; x < gridWidth; x++) {
			for (z = 0; z < gridHeight; z++) {
				if (x == 0 && z == 0 || x == 0 && z == 4 || x == 0 && z == 5 || 
				    x == 0 && z == 6 || x == 0 && z == 7 || x == 1 && z == 0 ||
				    x == 1 && z == 5 || x == 1 && z == 6 || x == 1 && z == 7 || 
				    x == 2 && z == 0 || x == 2 && z == 6 || x == 2 && z == 7 ||
				    x == 3 && z == 0 || x == 3 && z == 6 || x == 3 && z == 7 ||
				    x == 4 && z == 7 || x == 5 && z == 7 || x == 7 && z == 0 || 
				    x == 8 && z == 0 || x == 8 && z == 1 || x == 8 && z == 2){
					continue;
				}else{
				Instantiate (MapTileGenerator (), new Vector3 (x, -0.5f, z), transform.rotation);
				}
			}
		}
	}

	public void CoverGrid()
	{
		int x, z;
		for (x = 0; x < gridWidth; x++) {
			for (z = 0; z < gridHeight; z++) {
				if (x == 0 && z == 0 || x == 0 && z == 4 || x == 0 && z == 5 || 
				    x == 0 && z == 6 || x == 0 && z == 7 || x == 1 && z == 0 ||
				    x == 1 && z == 5 || x == 1 && z == 6 || x == 1 && z == 7 || 
				    x == 2 && z == 0 || x == 2 && z == 6 || x == 2 && z == 7 ||
				    x == 3 && z == 0 || x == 3 && z == 6 || x == 3 && z == 7 ||
				    x == 4 && z == 7 || x == 5 && z == 7 || x == 7 && z == 0 || 
				    x == 8 && z == 0 || x == 8 && z == 1 || x == 8 && z == 2){
					continue;
				}else{
					Instantiate (cover, new Vector3 (x, 0.1f, z), transform.rotation);
				}
			}
		}
	}
	
	private GameObject MapTileGenerator()
	{
		int i = RandomGenerator (100);
		
		if (i <= 50) {
			return dirt;
		} else if (i > 50 && i <= 80) {
			return common;
		} else if (i > 80 && i <= 95) {
			return uncommon;
		} else {
			return rare;
		}
	}
	
	private int RandomGenerator(int maxValue)
	{
		//Random number generator
		int i = Random.Range (0, maxValue);
		
		return i;
	}
	

}
