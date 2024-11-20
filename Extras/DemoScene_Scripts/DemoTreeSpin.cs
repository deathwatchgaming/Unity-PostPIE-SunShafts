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

	private void Update()
	{
		Vector3 _treeSpin = new Vector3(0, 0, _treeSpinSpeed);
		transform.Rotate(_treeSpin.x, _treeSpin.y, _treeSpin.z * Time.deltaTime);
	}
    
}
