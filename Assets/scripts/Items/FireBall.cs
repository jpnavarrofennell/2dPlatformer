using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public Vector2 initialVelocity = new Vector2 (100f, -100f);

	private Rigidbody2D body2d;

	void Awake() {
		body2d = GetComponent<Rigidbody2D> (); 
	}
	// Use this for initialization
	void Start () {
		var startVelX = initialVelocity.x * transform.localScale.x;

		body2d.velocity = new Vector2 (startVelX, initialVelocity.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
