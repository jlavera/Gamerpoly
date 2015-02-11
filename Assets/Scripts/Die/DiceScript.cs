using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using UnityEngine;

using Assets.Scripts.Utils;
using AssemblyCSharp.Scripts.Die;

namespace Assets.Scripts.Die {
    public class DiceScript : MonoBehaviour {

        public float speed = 700f;
        private bool holding;
        private bool draging;
        private Vector3 screenPoint;

        public void Awake() {
            ResetDice();
        }

        public void FixedUpdate() {
            //--Si está esperando el envión o arrastrando, girar
            if (holding || draging)
                transform.Rotate(Vector3.right + Vector3.up, speed * Time.deltaTime);
        }

        public void ResetDice() {
            holding = true;
            draging = false;
            transform.position = new Vector3(10, 5, 0);
            rigidbody.velocity = Vector3.zero;
            rigidbody.useGravity = false;
            GetComponentsInChildren<SideTrigger>()
                .ToList()
                .ForEach(s => s.enabled = true);
        }

        public void OnMouseDown() {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            holding = false;
            draging = true;
            rigidbody.useGravity = true;
            Debug.LogWarning("StartDrag");
        }

        public void OnMouseUp() {
            draging = false;
        }

        public void OnMouseDrag() {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
            transform.position = currentPos;
            Debug.LogWarning("Draging to: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

    }
}