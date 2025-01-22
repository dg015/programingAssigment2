using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class BrewCoffeeAT : ActionTask {

		
		public BBParameter<GameObject> coffeeGuy;
		public Blackboard coffeeGuyBlackboard;
        public Blackboard agentBlackboard;
        public BBParameter<float> CoffeeMakeProgress;
        public BBParameter<float> CoffeeFillRate;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            coffeeGuyBlackboard = coffeeGuy.value.GetComponent<Blackboard>();

			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            //get reference to coffee ordering
		 bool Ordering = coffeeGuyBlackboard.GetVariableValue<bool>("Ordering");

            if (Ordering == true && CoffeeMakeProgress.value <= 100)
			{
				//check if theyre ordering and doesnt havea full cup
				Debug.Log("ordering more coffee");
				CoffeeMakeProgress.value += Time.deltaTime * CoffeeFillRate.value;

				//coffeeGuyBlackboard.SetVariableValue("CaffeineDuration", caffeineAmount);

            }
			else if(CoffeeMakeProgress.value >= 100)
			{
				//if they have a full cup make them move on
				Debug.Log("coffee is ready");
                EndAction(true);
            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			//reset variable back to false
            coffeeGuyBlackboard.SetVariableValue("Ordering", false);
			CoffeeMakeProgress.value = 0f;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}