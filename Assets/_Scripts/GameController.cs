/*      File Name:              GameController.cs
 *      Author's Name:          Jason Gunter
 *      Last Modified By:       Jason Gunter
 *      Date Last Modified:     Oct 22nd, 2016
 *      Program Description:    A 2D scrolling game
 *      File Description:       This script controls the scoreboard and game over UI elements
 *      Revision History:       https://github.com/jgunter7/COMP305_MIDTERM
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int enemyCount;
	public GameObject enemy;

    //PRIVATE VARIABLES
    private int _hullPoints;
    private int _score;

    //PUBLIC VARIABLES
    [Header("UI Objects")]
    public Text HullPointsLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;

    public int HullPointsValue {
        get {
            return this._hullPoints;
        }

        set {
            this._hullPoints = value;
            if (this._hullPoints <= 0) {
                this._endGame();
            } else {
                this.HullPointsLabel.text = "Hull Points: " + this._hullPoints;
            }
        }
    }

    public int ScoreValue {
        get {
            return this._score;
        }

        set {
            this._score = value;
            this.ScoreLabel.text = "Score: " + this._score;
        }
    }

    // Use this for initialization
    void Start () {
        // Place 3 enemies on the screen
		this._GenerateEnemies ();

        // init score and hull points
        this.ScoreValue = 0;
        this.HullPointsValue = 5;
        // hide items at start:
        this.GameOverLabel.gameObject.SetActive(false);
        this.FinalScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Clouds
	private void _GenerateEnemies() {
		for (int count=0; count < this.enemyCount; count++) {
			Instantiate(enemy);
		}
	}

    void _endGame() {
        this.HullPointsLabel.gameObject.SetActive(false);
        this.ScoreLabel.gameObject.SetActive(false);
        // SET GAME OVER SCREEN ! - jgunter
        var player = GameObject.FindWithTag("Player");
        player.gameObject.SetActive(false); // get rid of the player component
        this.GameOverLabel.gameObject.SetActive(true);
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.FinalScoreLabel.text = "Final Score: " + this._score;
    }

    public void RestartButton_Click() {
        SceneManager.LoadScene("Main");
    }
}
