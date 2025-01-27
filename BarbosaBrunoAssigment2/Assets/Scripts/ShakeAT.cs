using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ShakeAT : ActionTask {

		public BBParameter <float> CaffeineDuration;
        public BBParameter <float> ShakeIntensity;
        public BBParameter<float> MaxCaffeineDuration;
        public BBParameter<float> MaxShakeIntensity;
        private Vector3 originalPosition;

        public BBParameter<int> currentState;
        //private float MaxShakeIntensity = 0.2f;
        //private float MaxCaffeineDuration = 7f;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			originalPosition = agent.transform.position;

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			currentState.value = 1;


		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//deduct the caffeine overtime
            
            if (CaffeineDuration.value == 0) 
			{
				//if its 0 then set move on into the next area
				
                EndAction(true);
            }
			else if (CaffeineDuration.value > 0)
			{
				caffeineDeduction();
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
			//clamp value of shakeness
            ShakeIntensity.value = Mathf.Clamp(ShakeIntensity.value, -0.2f, 0.2f);
			//get random value
            float randomVar = Random.Range(-ShakeIntensity.value, ShakeIntensity.value);
			Vector3 shakeDirection = new Vector3(randomVar, randomVar, randomVar);
			

            //shake the character
            agent.transform.localPosition = originalPosition + shakeDirection;
			//send them back to initial location so they dont "shake away"
			agent.transform.localEulerAngles = originalPosition;
		}

		private void caffeineDeduction()
		{
			//decrease caffeine over time
            CaffeineDuration.value -= Time.deltaTime;
			//lock it to minimum 0
			CaffeineDuration.value = Mathf.Max(CaffeineDuration.value, 0);
			//lerp the intensity so that it slows down with the caffeine duration
			ShakeIntensity = Mathf.Lerp(0, MaxShakeIntensity.value, CaffeineDuration.value / MaxCaffeineDuration.value);

        }

	}
}