using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Triggers.Dice {
    class SpinDice : MonoBehaviour {

        public float speed = 700f;

        void Update() {
            transform.Rotate(Vector3.right, speed * Time.deltaTime);
        }

    }
}