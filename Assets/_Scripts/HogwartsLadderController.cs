using UnityEngine;
using System.Collections;

public class HogwartsLadderController : MonoBehaviour {

	public float timeInterval;

	// Use this for initialization
	void Start () {
		timeInterval = 10;
		ladderSegments = gameObject.GetComponentsInChildren<LadderSegmentController>();
		InvokeRepeating ("moveLadderSegments", 0, timeInterval);
	}

	private Component[] ladderSegments;

	void Update () {
		
	}

	void MoveLadderSegmentRandom (Component ladderSegment) {
		int randomState = Random.Range (-1, 2);
		ladderSegment.SendMessage("setState", randomState);
	}

	void moveLadderSegments () {
		foreach( var ladderSegment in ladderSegments ) {
			MoveLadderSegmentRandom(ladderSegment);	
		}
	}
}
