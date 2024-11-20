/*
 * File: Demo Preview Camera
 * Name: DemoPreviewCamera.cs
 * Author: DeathwatchGaming
 * License: MIT 
 */

using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DemoPreviewCamera : MonoBehaviour
{
	[Header("Input Customizations")]
        
		[Tooltip("The vertical movement input string")]
		[SerializeField] private string _verticalMoveInput = "Vertical";	
        
		[Tooltip("The horizontal movement input string")]
		[SerializeField] private string _horizontalMoveInput = "Horizontal";

		[Tooltip("The mouse scrollwheel input string")]
		[SerializeField] private string _mouseScrollWheelInput = "Mouse ScrollWheel";			
        
		[Tooltip("The mouse Y input string")]            
		[SerializeField] private string _mouseYInput = "Mouse Y";
        
		[Tooltip("The mouse X input string")]
		[SerializeField] private string _mouseXInput = "Mouse X";
        
		[Tooltip("The left increase movement speed input keycode key")]
		[SerializeField] private KeyCode _plusSpeedLeftKey = KeyCode.LeftShift;

		[Tooltip("The right increase movement speed input keycode key")]
		[SerializeField] private KeyCode _plusSpeedRightKey = KeyCode.RightShift;

		[Tooltip("The left decrease movement speed input keycode key")]
		[SerializeField] private KeyCode _minusSpeedLeftKey = KeyCode.LeftControl;

		[Tooltip("The right decrease movement speed input keycode key")]
		[SerializeField] private KeyCode _minusSpeedRightKey = KeyCode.RightControl;

		[Tooltip("The plus camera lift movement input keycode key")]
		[SerializeField] private KeyCode _plusLiftKey = KeyCode.Q;

		[Tooltip("The minus camera lift movement input keycode key")]
		[SerializeField] private KeyCode _minusLiftKey = KeyCode.E;

		[Tooltip("The cursor lock input keycode key")]
		[SerializeField] private KeyCode _cursorLockKey = KeyCode.End;

		[Tooltip("The camera minus field of view input keycode key")]
		[SerializeField] private KeyCode _minusFOVKey = KeyCode.Z;

		[Tooltip("The camera plus field of view input keycode key")]
		[SerializeField] private KeyCode _plusFOVKey = KeyCode.X;

	[Header("Amounts")]

		[Tooltip("The camera rotation mouse sensitivity amount")]
		[SerializeField] private float _mouseSensitivity = 90;

		[Tooltip("The camera default movement speed amount")]
		[SerializeField] private float _defaultMoveSpeed = 10;

		[Tooltip("The camera increased movement speed multiplier amount")]
		[SerializeField] private float _plusSpeedMultiplier = 3;

		[Tooltip("The camera decreased movement speed multiplier amount")]
		[SerializeField] private float _minusSpeedMultiplier = 0.25f;

		[Tooltip("The camera lift speed amount")]
		[SerializeField] private float _cameraLiftSpeed = 4;

		[Tooltip("The field of view amount")]
		[SerializeField] private float _cameraFOV = 60f;

		[Tooltip("The zoom ratio amount")]
		[SerializeField] private float _zoomRatio = 0.5f;

	private float _horizontalRotation = 0.0f;
	private float _verticalRotation = 0.0f;
	private float currentFieldOfView = 0f;
	private float mouseScroll = 0f;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		_horizontalRotation += Input.GetAxis(_mouseXInput) * _mouseSensitivity * Time.deltaTime;
		_verticalRotation += Input.GetAxis(_mouseYInput) * _mouseSensitivity * Time.deltaTime;
		_verticalRotation = Mathf.Clamp(_verticalRotation, -90, 90);

		transform.localRotation = Quaternion.AngleAxis(_horizontalRotation, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(_verticalRotation, Vector3.left);

		if (Input.GetKey(_plusSpeedLeftKey) || Input.GetKey(_plusSpeedRightKey))
		{
			transform.position += transform.forward * (_defaultMoveSpeed * _plusSpeedMultiplier) * Input.GetAxis(_verticalMoveInput) * Time.deltaTime;
			transform.position += transform.right * (_defaultMoveSpeed * _plusSpeedMultiplier) * Input.GetAxis(_horizontalMoveInput) * Time.deltaTime;
		}

		else if (Input.GetKey(_minusSpeedLeftKey) || Input.GetKey(_minusSpeedRightKey))
		{
			transform.position += transform.forward * (_defaultMoveSpeed * _minusSpeedMultiplier) * Input.GetAxis(_verticalMoveInput) * Time.deltaTime;
			transform.position += transform.right * (_defaultMoveSpeed * _minusSpeedMultiplier) * Input.GetAxis(_horizontalMoveInput) * Time.deltaTime;
		}

		else
		{
			transform.position += transform.forward * _defaultMoveSpeed * Input.GetAxis(_verticalMoveInput) * Time.deltaTime;
			transform.position += transform.right * _defaultMoveSpeed * Input.GetAxis(_horizontalMoveInput) * Time.deltaTime;
		}

		if (Input.GetKey(_plusLiftKey)) 
		{ 
			transform.position += transform.up * _cameraLiftSpeed * Time.deltaTime; 
		}

		if (Input.GetKey(_minusLiftKey)) 
		{ 
			transform.position -= transform.up * _cameraLiftSpeed * Time.deltaTime; 
		}

		if (Input.GetKeyDown(_cursorLockKey) && Cursor.lockState == CursorLockMode.Locked)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
            
		else if (Input.GetKeyDown(_cursorLockKey) && Cursor.lockState == CursorLockMode.None)
		{			
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		currentFieldOfView = _cameraFOV;

		mouseScroll = Input.GetAxis(_mouseScrollWheelInput);

        if (mouseScroll > 0)
		{
			_cameraFOV = ++currentFieldOfView;
		}

        else if (mouseScroll < 0)
		{
			_cameraFOV = --currentFieldOfView;
		}

		if (Input.GetKey(_minusFOVKey))
		{
			_cameraFOV = --currentFieldOfView;
		}

		else if (Input.GetKey(_plusFOVKey))
		{
			_cameraFOV = ++currentFieldOfView;
		}

		GetComponent<Camera>().fieldOfView = _cameraFOV + _zoomRatio * Time.deltaTime;

	}

}
