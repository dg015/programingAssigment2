using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class LeaveBathroom : ActionTask {

		public BBParameter<int> currentState;
        public BBParameter<Transform> CoffeeMachineLocation;
        public BBParameter<Transform> DeskLocation;
        public BBParameter<float> walkSpeed;
        
		//Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			Debug.Log("Gotta go back to work");
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if(currentState.value == 1 || currentState.value == 4)
			{
                WalkToDesk();
                if (Vector3.Distance(agent.transform.position, DeskLocation.value.position) < 0.5f)
                {
                    //if theyre there stop
                    
                    EndAction(true);
                }
            }
            else if (currentState.value == 2 || currentState.value == 3)
            {
                WalkToCoffeeMachine();
                if (Vector3.Distance(agent.transform.position, CoffeeMachineLocation.value.position) < 0.5f)
                {
                    //if theyre there stop
                    
                    EndAction(true);
                }
            }

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		private void WalkToDesk()
		{
            //get distance to walk towards for the movetowards function
            Debug.Log("gotta get more coffee");
            float WalkingTowards = walkSpeed.value * Time.deltaTime;

            //move character to there
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, DeskLocation.value.position, WalkingTowards);
        }

        private void WalkToCoffeeMachine()
        {
            //get distance to walk towards for the movetowards function
            Debug.Log("gotta get more coffee");
            float WalkingTowards = walkSpeed.value * Time.deltaTime;

            //move character to there
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, CoffeeMachineLocation.value.position, WalkingTowards);
        }

    }
}