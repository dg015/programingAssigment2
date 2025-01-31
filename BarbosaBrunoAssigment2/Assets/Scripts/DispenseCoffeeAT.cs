using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DispenseCoffeeAT : ActionTask {

        public BBParameter<GameObject> coffeeGuy;
        private Blackboard coffeeGuyBlackboard;
		public float ammountDispensed;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			

			//get varaibles
            coffeeGuyBlackboard = coffeeGuy.value.GetComponent<Blackboard>();
            float caffeineAmount = coffeeGuyBlackboard.GetVariableValue<float>("CaffeineDuration");
			Debug.Log(caffeineAmount);
			//give the character 25 seconds of caffeine as if they got a new coffee
            coffeeGuyBlackboard.SetVariableValue("CaffeineDuration", 25f);
            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            
        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}