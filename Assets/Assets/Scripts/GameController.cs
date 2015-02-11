using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int score, moves;
	public GUIText scoreText, movesText, gameoverText;
	public bool gameover;


	// Use this for initialization
	void Start () 
	{
		moves = 10;
		movesText.text = "moves: " + moves;
		score = 0;
		scoreText.text = "Score: " + score;
		gameoverText.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateScore ();
		UpdateMoves ();
		if (gameover) {
			gameoverText.text = "Game Over!";
		}
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	void UpdateMoves()
	{
		movesText.text = "moves: " + moves;
		if (moves == 0)
			gameover = true;
	}
	
	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void UseMove()
	{
		moves += -1;
		UpdateMoves ();
	}
}
