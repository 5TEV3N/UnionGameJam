using UnityEngine;
using System.Collections;

public class BasicAttribute {

	public float baseAttributeMin = 0f; // this will be our attribute, set it to a value between 0 and 1;
	public float baseAttributeMax = 1f;
	public float baseAttributeCurrent;
	public float baseAttributeAdjustAmount; // how much you will adjust the attribute by;


	public BasicAttribute(){
		
	}

	public void AdjustAttribute(string command,float adjustAmount = 0){
		adjustAmount = Mathf.Clamp01 (adjustAmount);
		switch (command) {
		case "AdjustToNumber":
			baseAttributeCurrent = adjustAmount;
			break;
		case "AddAmount":
			baseAttributeCurrent = Mathf.Clamp01 (baseAttributeCurrent += adjustAmount);
			break;
		case "SubtractAmount":
			baseAttributeCurrent = Mathf.Clamp01 (baseAttributeCurrent -= adjustAmount);
			break;
		case "MultiplyByAmount":
			baseAttributeCurrent = Mathf.Clamp01 (baseAttributeCurrent * adjustAmount);
			break;
		case "DivideAmount":
			baseAttributeCurrent = Mathf.Clamp01 (baseAttributeCurrent / adjustAmount);
			break;
		case "SetToMax":
			baseAttributeCurrent = baseAttributeMax;
			break;
		case "SetToMin":
			baseAttributeCurrent = baseAttributeMin;
			break;
		default:
			break;

		}
		
	}

	//Check Value Functions
	public float GetRatio(){
		float ratio = Mathf.Clamp01 (baseAttributeCurrent / baseAttributeMax);
		return ratio;
	}
	public float GetPercentage(){
		float percentage = GetRatio () * 100f;
		return percentage;
	}
	public float GetRatioAsRange(float maxValue){
		float ratioAsRange = GetRatio() * maxValue;
		return ratioAsRange;
	}
}
