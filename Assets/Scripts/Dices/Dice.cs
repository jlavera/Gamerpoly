using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using AssemblyCSharp.Scripts.Dices.Die;

namespace Assets.Scripts.Dices {
    public class Dice : MonoBehaviour {

        private GameObject Dado1;
        //private GameObject Dado2;

        public Dice() {
            Dado1 = GameObject.Find("Dice1");
            //Dado2 = GameObject.Find("Dice2");
        }

        public void ResetDice() {
            Dado1.transform.position = new Vector3(10, 5, 0);
            Dado1
                .GetComponentsInChildren<SideTrigger>()
                .ToList()
                .ForEach(s => s.enabled = true);
        }

    }
}