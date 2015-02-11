using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using Assets.Scripts.Utils;
using AssemblyCSharp.Scripts.Die;

namespace Assets.Scripts.Die {
    public class DiceScript : MonoBehaviour {

        public float speed = 700f;
        private GameObject Dado1;
        private bool holding;
        //private GameObject Dado2;

        public void Awake() {
            Dado1 = GameObject.Find(ObjMan.Dado1);
            holding = true;
            ResetDice();
            //Dado2 = GameObject.Find(ObjMan.Dado2);
        }

        public void FixedUpdate() {
            //--Si está esperando el envión
            if (holding)
                Dado1.transform.Rotate(Vector3.right + Vector3.up, speed * Time.deltaTime);
        }

        public void ResetDice() {
            Dado1.transform.position = new Vector3(10, 5, 0);
            Dado1.rigidbody.velocity = Vector3.zero;
            Dado1.rigidbody.useGravity = false;
            Dado1
                .GetComponentsInChildren<SideTrigger>()
                .ToList()
                .ForEach(s => s.enabled = true);
        }

        public void StartDrag() {
            holding = true;
            Dado1.rigidbody.useGravity = true;
        }

    }
}