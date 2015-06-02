using UnityEngine;
using System.Collections;

[RequireComponent (typeof(InputState))]
[RequireComponent (typeof(Walk))]
[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(CollisionState))]
[RequireComponent (typeof(Duck))]

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehavior;
	private Animator animator;
	private CollisionState collisionState;
	private Duck duckBehavoir;

	void Awake() {
		inputState = GetComponent<InputState> ();
		walkBehavior = GetComponent<Walk> ();
		animator = GetComponent<Animator> ();
		collisionState = GetComponent<CollisionState> ();
		duckBehavoir = GetComponent<Duck> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collisionState.standing) {
			ChangeAnimation(0); 
		}

		if (inputState.absVelX > 0) {
			ChangeAnimation(1);
		}

		if (inputState.absVelY > 0) {
			ChangeAnimation(2);
		}

		animator.speed = walkBehavior.running ? walkBehavior.runMultiplier : 1;

		if (duckBehavoir.ducking) {
			ChangeAnimation(3);
		}

		if(!collisionState.standing && collisionState.onWall) {
			ChangeAnimation(4);
		}
	}

	void ChangeAnimation(int value) {
		animator.SetInteger ("AnimState", value);
	}
}
