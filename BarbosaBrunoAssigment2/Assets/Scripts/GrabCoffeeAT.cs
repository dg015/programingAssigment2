using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GrabCoffeeAT : ActionTask {

        public Transform CoffeePressPlate;
        public BBParameter<float> WalkSpeed;
        public BBParameter<bool> Ordering;
        

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {


            if (Vector3.Distance(agent.transform.position, CoffeePressPlate.position) < 0.5f)
            {
                //if theyre close enough to the machine make them order
                Ordering.value = true;
                Debug.Log("arrived");
                EndAction(true);
            }
            else
            {
                // if not make them walk there
                WalkToCoffee();
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

        private void WalkToCoffee()
        {

            Debug.Log("gotta get more coffee");
            //get the walk speed
            float WalkingTowards = WalkSpeed.value * Time.deltaTime;

            //make them walk there
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, CoffeePressPlate.position, WalkingTowards);
        }
    }
}