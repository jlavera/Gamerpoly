using System;
using System.Collections;
using UnityEngine;
namespace AssemblyCSharp {
    public class SideTrigger : MonoBehaviour {

        public int faceValue;

        private GameObject Die;
        private DieValue DieValue;
        private bool TriggerActive;

        public SideTrigger() { }

        public void Awake() {
            Die = GameObject.Find("Dice1");
            DieValue = Die.GetComponent<DieValue>();
            TriggerActive = false;
        }

        public void OnTriggerEnter(Collider other) {
            Debug.LogError("Pisó el nº " + (7 - faceValue));
            DieValue.currentValue = (7 - faceValue);
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
            Debug.LogError("Salio el nº " + (7 - faceValue));
            
            //--Aca remuevo el trigger para que no vuelva a saltar, pero cuando arrastra de nuevo o se resetea el dado, hay que volver a agregarlo
            this.enabled = false; 
            //GameSystem.Instance.NextPlayer.Move(dieComp.currentValue);
        }

        public bool IsQuiet(GameObject obj) {
            return obj.rigidbody.velocity == Vector3.zero && obj.rigidbody.angularVelocity == Vector3.zero;
        }
    }
}