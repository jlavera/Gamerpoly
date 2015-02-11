using System;
using System.Collections;
using UnityEngine;
namespace AssemblyCSharp.Scripts.Dices.Die {
    public class SideTrigger : MonoBehaviour {

        public int FaceValue;
        private GameObject Die;
        private bool TriggerActive;

        private int FinalValue { get { return 7 - FaceValue; } }

        public SideTrigger() { }

        public void Awake() {
            Die = GameObject.Find("Dice1");
            TriggerActive = false;
        }

        public void OnTriggerEnter(Collider other) {
            Debug.LogError("Pisó el nº " + FinalValue);
            TriggerActive = true;
        }

        public void OnTriggerExit(Collider other) {
            TriggerActive = false;
        }

        public void FixedUpdate() {

            if (!TriggerActive)
                return;

            //--Si todavía se está moviendo el dado, retornar
            if (!IsQuiet(Die))
                return;

            Debug.LogError("Salio el nº " + FinalValue);
            
            //--Aca remuevo el trigger para que no vuelva a saltar, pero cuando arrastra de nuevo o se resetea el dado, hay que volver a agregarlo
            this.enabled = false;
            GameSystem.Instance.CurrentPlayer.Move(FinalValue);
        }

        public bool IsQuiet(GameObject obj) {
            return obj.rigidbody.velocity == Vector3.zero && obj.rigidbody.angularVelocity == Vector3.zero;
        }
    }
}