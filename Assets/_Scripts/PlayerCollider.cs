/*      File Name:              PlayerCollider.cs
 *      Author's Name:          Jason Gunter
 *      Last Modified By:       Jason Gunter
 *      Date Last Modified:     Oct 22nd, 2016
 *      Program Description:    A 2D scrolling game
 *      File Description:       This script controls player collisions and lives updates
 *      Revision History:       https://github.com/jgunter7/COMP305_MIDTERM
 */
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

    private void OnTriggerEnter2D(Collider2D other) {
        // Lose points if we are hit! -jgunter
        if (other.gameObject.CompareTag("Enemy")) {
            this._gc.HullPointsValue -= 1;
        }
    }
}