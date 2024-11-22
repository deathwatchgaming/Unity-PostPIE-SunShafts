/*
 * File: Demo Tree Spin
 * Name: DemoTreeSpin.cs
 * Author: DeathwatchGaming
 * License: MIT 
 */

using UnityEngine;

public class DemoTreeSpin : MonoBehaviour
{
	[Header("Amounts")]

		[Tooltip("The tree spin speed amount")]
		[SerializeField] private float _treeSpinSpeed = 8f;

	[Header("Enabled State")]

		[Tooltip("The Tree Spin enabled state")]
		public bool TreeSpinEnabled = true;

	// Update is called every frame	

	private void Update()
	{
		if (TreeSpinEnabled == true)
		{
			GetComponent<DemoTreeSpin>().enabled = true;
			//Debug.Log("The Tree Spin is enabled");

			UpdateTreeSpin();
		}

		else if (TreeSpinEnabled == false)
		{
			//Debug.Log("The Tree Spin is disabled");
			GetComponent<DemoTreeSpin>().enabled = false;
		}

	}

	// UpdateTreeSpin is called in Update

	private void UpdateTreeSpin()
	{
		Vector3 _treeSpin = new Vector3(0, 0, _treeSpinSpeed);
		transform.Rotate(_treeSpin.x, _treeSpin.y, _treeSpin.z * Time.deltaTime);
	}	
    
}
