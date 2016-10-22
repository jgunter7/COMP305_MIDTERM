using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {
    //PRIVATE VARIABLES
    private GameController _gc;
    // Use this for initialization
    void Start() {
        var _gcObj = GameObject.Find("GameController");
        this._gc = _gcObj.GetComponent<GameController>() as GameController;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Lose points if we are hit! -jgunter
        if (other.gameObject.CompareTag("Enemy")) {
            this._gc.HullPointsValue -= 1;
        }
    }
}