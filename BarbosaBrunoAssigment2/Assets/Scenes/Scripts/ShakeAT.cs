using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ShakeAT : ActionTask {

		public BBParameter <float> CaffeineDuration;
        public BBParameter <float> ShakeIntensity;

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
			//deduct the caffeine overtime
            CaffeineDuration.value -= Time.deltaTime;
            if (CaffeineDuration.value < 0) 
			{
				//if its 0 then set move on into the next area
                EndAction(true);
            }
			else if (CaffeineDuration.value > 0)
			{
				shake();
			}
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		private void shake()
		{
			Debug.Log("Man I love coffee");
			float randomVar = Random.Range(-ShakeIntensity.value, ShakeIntensity.value);
			Vector3 shakeDirection = new Vector3(randomVar, randomVar, randomVar);
			ShakeIntensity.value = Mathf.Clamp(ShakeIntensity.value,-0.09f, 0.09f);
            Debug.Log(shakeDirection);
            agent.transform.localPosition = shakeDirection;
		}
	}
}