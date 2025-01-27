using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class WalkToBathroom : ActionTask {

		public BBParameter<Transform> ToilletLocation;
		public BBParameter<float> walkSpeed;
		public float speedModifier;
		
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (Vector3.Distance(agent.transform.position, ToilletLocation.value.position) < 0.5f)
            {
                //if theyre there stop
                Debug.Log("arrived");
                EndAction(true);
            }
            else
            {
                //if not walk more to there
                Walking();
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}


        private void Walking()
        {
            //get distance to walk towards for the movetowards function
            Debug.Log("gotta get more coffee");
            float WalkingTowards = walkSpeed.value * Time.deltaTime;

            //move character to there
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, ToilletLocation.value.position, WalkingTowards);
        }
    }
}