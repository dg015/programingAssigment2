using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class UseBathroomAT : ActionTask {
		public float BathroomTime;
		public float BathroomTimeMax;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            
			Debug.Log("started doing le bussiness");
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            if (BathroomTime <= 0)
            {
                EndAction(true);
            }
            else
            {
                BathroomTimer();
            }
            
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			Debug.Log("Finished doing le bussiness");
            BathroomTime = BathroomTimeMax;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
		private void BathroomTimer()
		{
			//decrese timer
			BathroomTime -= Time.deltaTime * 1;
			//clamp it so it doesnt go below 0

		}

	}
}