/*      File Name:              EnemyController.cs
 *      Author's Name:          Jason Gunter
 *      Last Modified By:       Jason Gunter
 *      Date Last Modified:     Oct 22nd, 2016
 *      Program Description:    A 2D scrolling game
 *      File Description:       This script controls the enemy movement and actions
 *      Revision History:       https://github.com/jgunter7/COMP305_MIDTERM
 */
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public Speed speed;
	public Boundary boundary;

	// PRIVATE INSTANCE VARIABLES
	private float _CurrentSpeed;
	private float _CurrentDrift;
    private GameController _gc;

	// Use this for initialization
	void Start () {
        var _gcObj = GameObject.Find("GameController");
        this._gc = _gcObj.GetComponent<GameController>() as GameController;
        this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y -= this._CurrentSpeed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		// Check bottom boundary
		if (currentPosition.y <= boundary.yMin) {
			this._Reset();
		}
	}

	// resets the gameObject
	private void _Reset() {
        // Player gains 10 points for every enemy that gets reset! - jgunter
        _gc.ScoreValue += 10;

        // Reset the enemy - already completed! - jgunter
        this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		Vector2 resetPosition = new Vector2 (Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}

    private void OnTriggerEnter2D(Collider2D other) {
        // RESET IF WE HIT THE PLAYER!! - jgunter
        if (other.gameObject.CompareTag("Player")) {
            this._Reset();
        }
    }
}
