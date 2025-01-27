using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Conditions {

	public class BathroomBreakButtonCT : ConditionTask {
		public bool Pressed;
		public Button BathroomButton;
		public BBParameter<bool> pressed;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//add listener to the button which is required
			BathroomButton.GetComponent<Button>().onClick.AddListener(BathroomBreakBoolean);
			if(pressed.value == true)
			{
				//if its pressed then set the varaible to go to the bathroom true
                return true;

            }
			else
			{
				//if not just return false
                return false;

            }
			
		}

		private void BathroomBreakBoolean()
		{
			Debug.Log("NEED BATHROOM NOW");
			//set the variable to true
			pressed.value = true;
        }
	}
}