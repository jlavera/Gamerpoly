using System;
using System.Collections;
using UnityEngine;
namespace AssemblyCSharp {
    public class SideTrigger:MonoBehaviour {
        
		public int faceValue;
        public bool sleep = false;
        public Vector3 prevPosition;
        private DieValue dieComp;
		private bool moving;
		

        public SideTrigger() {}

        public void OnTriggerEnter(Collider other) {			
			var dieGameObject = GameObject.Find("Dice1");
			dieComp = dieGameObject.GetComponent<DieValue>();

			//if (dieComp.currentValue == (7 - faceValue))

			if (moving)
				return;

			Debug.LogError ("salio el n "+ (7-faceValue));

			dieComp.currentValue = (7 - faceValue);
	
			GameSystem.Instance.NextPlayer.Move (dieComp.currentValue);

		}

		
		private IEnumerator isMoving()
		{
			Vector3 startPos = transform.position;
			yield return new WaitForSeconds(1f);
			Vector3 finalPos = transform.position;
			
			moving =  startPos.x != finalPos.x || startPos.y != finalPos.y || startPos.z != finalPos.z;
		}

        public void FixedUpdate() {

			isMoving ();
			/*
            var dice = GameObject.Find("Dice1");

			if (!dice.rigidbody.IsSleeping () && turnIsOver == false) {
				GameSystem.Instance.NextPlayer.Move (dieComp.currentValue);
				turnIsOver = true;
			} else {
				turnIsOver = false;
			}
			if (prevPosition != dice.transform.position) {
                prevPosition = dice.transform.position;
                quieto = false;
            } else if (!quieto) {
                quieto = true;
				GameSystem.Instance.NextPlayer.Move(dieComp.currentValue);
				//Debug.LogError("Quieto: " + (dieComp.currentValue));
            }
            */
        }
    }
}