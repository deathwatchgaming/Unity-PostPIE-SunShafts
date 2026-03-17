/*
 * File: Demo Preview Camera (New Input)
 * Name: DemoPreviewCamera.cs
 * Author: DeathwatchGaming
 * License: MIT 
 */
 
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class DemoPreviewCamera : MonoBehaviour
{
	[Header("Input Actionss")]
        
		[Tooltip("The input action asset.")]
		[SerializeField] private InputActionAsset _previewCameraControls;	
        
	[Header("Amounts")]

		[Tooltip("The camera rotation mouse sensitivity amount.")]
		[SerializeField] private float _mouseSensitivity = 90;

		[Tooltip("The camera default movement speed amount")]
		[SerializeField] private float _defaultMoveSpeed = 10;

		[Tooltip("The camera increased movement speed multiplier amount.")]
		[SerializeField] private float _plusSpeedMultiplier = 3;

		[Tooltip("The camera decreased movement speed multiplier amount.")]
		[SerializeField] private float _minusSpeedMultiplier = 0.25f;

		[Tooltip("The camera lift speed amount.")]
		[SerializeField] private float _cameraLiftSpeed = 4;

		[Tooltip("The desired field of view amount.")]
		[SerializeField] private float _cameraFOV = 60f;

		[Tooltip("The zoom ratio amount.")]
		[SerializeField] private float _zoomRatio = 0.5f;

		[Tooltip("The minimum field of view amount.")]
		[SerializeField,Range(float.Epsilon, 179f)] private float _minimumFOV = 1f;
		
		[Tooltip("The maximum field of view amount.")]		
		[SerializeField,Range(float.Epsilon, 179f)] private float _maximumFOV = 118f;

	[Header("Enabled State")]

		[Tooltip("The Preview Camera enabled state")]
		public bool PreviewCameraEnabled = true;

	private float _horizontalRotation = 0.0f;
	private float _verticalRotation = 0.0f;
	private float currentFieldOfView = 0f;
	private float _minFieldOfView = 0f;
	private float _maxFieldOfView = 0f;
	private float mouseScroll = 0f;

	// Input

	private InputAction _moveAction;
	private InputAction _lookAction;
	private InputAction _mouseScrollAction;

	private InputAction _plusSpeedLeftAction;
	private InputAction _plusSpeedRightAction;
	private InputAction _minusSpeedLeftAction;
	private InputAction _minusSpeedRightAction;
	private InputAction _plusLiftAction;
	private InputAction _minusLiftAction;
	private InputAction _cursorLockAction;
	private InputAction _minusFOVAction;
	private InputAction _plusFOVAction;

	private Vector2 _moveInput;
	private Vector2 _lookInput;
	private Vector2 _mouseScrollInput;

	private bool _plusSpeedLeftValue;
	private bool _plusSpeedRightValue;
	private bool _minusSpeedLeftValue;
	private bool _minusSpeedRightValue;
	private bool _plusLiftValue;
	private bool _minusLiftValue;
	private bool _cursorLockValue;
	private bool _minusFOVValue;
	private bool _plusFOVValue;

	// Static

	public static DemoPreviewCamera _demoPreviewCamera;

	private void Awake()
	{
		_moveAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Move");

		_moveAction.performed += context => _moveInput = context.ReadValue<Vector2>();
		_moveAction.canceled += context => _moveInput = Vector2.zero;

		_lookAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Look");

		_lookAction.performed += context => _lookInput = context.ReadValue<Vector2>();
		_lookAction.canceled += context => _lookInput = Vector2.zero;

		_mouseScrollAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Mouse Scroll");

		_mouseScrollAction.performed += context => _mouseScrollInput = context.ReadValue<Vector2>();
		_mouseScrollAction.canceled += context => _mouseScrollInput = Vector2.zero;

		_plusSpeedLeftAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Plus Speed Left");
		_plusSpeedRightAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Plus Speed Right");
		_minusSpeedLeftAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Minus Speed Left");
		_minusSpeedRightAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Minus Speed Right");
		_plusLiftAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Plus Lift");
		_minusLiftAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Minus Lift");
		_cursorLockAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Cursor Lock");
		_minusFOVAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Minus FOV");
		_plusFOVAction = _previewCameraControls.FindActionMap("Preview Camera").FindAction("Plus FOV");
	}

	private void OnEnable()
	{
		_moveAction.Enable();
		_lookAction.Enable();
		_mouseScrollAction.Enable();

		_plusSpeedLeftAction.Enable();
		_plusSpeedRightAction.Enable();
		_minusSpeedLeftAction.Enable();
		_minusSpeedRightAction.Enable();
		_plusLiftAction.Enable();
		_minusLiftAction.Enable();
		_cursorLockAction.Enable();
		_minusFOVAction.Enable();
		_plusFOVAction.Enable();
	}

	private void OnDisable()
	{
		_moveAction.Disable();
		_lookAction.Disable();
		_mouseScrollAction.Disable();

		_plusSpeedLeftAction.Disable();
		_plusSpeedRightAction.Disable();
		_minusSpeedLeftAction.Disable();
		_minusSpeedRightAction.Disable();
		_plusLiftAction.Disable();
		_minusLiftAction.Disable();
		_cursorLockAction.Disable();
		_minusFOVAction.Disable();
		_plusFOVAction.Disable();
	}

	// Start is called before the first frame update 

	private void Start()
	{
		_demoPreviewCamera = this;
		
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Update is called every frame

	private void Update()
	{
		if (PreviewCameraEnabled == true)
		{
			GetComponent<DemoPreviewCamera>().enabled = true;
			//Debug.Log("The Preview Camera is enabled");
			UpdatePreviewCamera();
		}

		else if (PreviewCameraEnabled == false)
		{
			//Debug.Log("The Preview Camera is disabled");
			GetComponent<DemoPreviewCamera>().enabled = false;	
		}
	}

	// UpdatePreviewCamera is called in Update

	private void UpdatePreviewCamera()
	{
		_plusSpeedLeftValue = _plusSpeedLeftAction.IsPressed();
		_plusSpeedRightValue = _plusSpeedRightAction.IsPressed();
		_minusSpeedLeftValue = _minusSpeedLeftAction.IsPressed();
		_minusSpeedRightValue = _minusSpeedRightAction.IsPressed();
		_plusLiftValue = _plusLiftAction.IsPressed();
		_minusLiftValue = _minusLiftAction.IsPressed();
		_cursorLockValue = _cursorLockAction.WasPressedThisFrame();
		_minusFOVValue = _minusFOVAction.WasPressedThisFrame();
		_plusFOVValue = _plusFOVAction.WasPressedThisFrame();

		_horizontalRotation += _lookInput.x * _mouseSensitivity * Time.deltaTime;
		_verticalRotation += _lookInput.y * _mouseSensitivity * Time.deltaTime;
		_verticalRotation = Mathf.Clamp(_verticalRotation, -90, 90);

		transform.localRotation = Quaternion.AngleAxis(_horizontalRotation, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(_verticalRotation, Vector3.left);

		if (_plusSpeedLeftValue || _plusSpeedRightValue)
		{
			transform.position += transform.forward * (_defaultMoveSpeed * _plusSpeedMultiplier) * _moveInput.y * Time.deltaTime;
			transform.position += transform.right * (_defaultMoveSpeed * _plusSpeedMultiplier) * _moveInput.x * Time.deltaTime;
		}

		else if (_minusSpeedLeftValue || _minusSpeedRightValue)
		{
			transform.position += transform.forward * (_defaultMoveSpeed * _minusSpeedMultiplier) * _moveInput.y * Time.deltaTime;
			transform.position += transform.right * (_defaultMoveSpeed * _minusSpeedMultiplier) * _moveInput.x * Time.deltaTime;
		}

		else
		{
			transform.position += transform.forward * _defaultMoveSpeed * _moveInput.y * Time.deltaTime;
			transform.position += transform.right * _defaultMoveSpeed * _moveInput.x * Time.deltaTime;
		}

		if (_plusLiftValue) 
		{ 
			transform.position += transform.up * _cameraLiftSpeed * Time.deltaTime; 
		}

		if (_minusLiftValue) 
		{ 
			transform.position -= transform.up * _cameraLiftSpeed * Time.deltaTime; 
		}

		if (_cursorLockValue && Cursor.lockState == CursorLockMode.Locked)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
            
		else if (_cursorLockValue && Cursor.lockState == CursorLockMode.None)
		{			
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		currentFieldOfView = _cameraFOV;

		mouseScroll = _mouseScrollInput.y;

		if (mouseScroll > 0)
		{
			_cameraFOV = ++currentFieldOfView;
		}

		else if (mouseScroll < 0)
		{
			_cameraFOV = --currentFieldOfView;
		}

		if (_minusFOVValue)
		{
			_cameraFOV = --currentFieldOfView;
		}

		else if (_plusFOVValue)
		{
			_cameraFOV = ++currentFieldOfView;
		}

		_minFieldOfView = Mathf.Clamp(_minimumFOV, float.Epsilon, _maximumFOV);
		_maxFieldOfView = Mathf.Clamp(_maximumFOV, _minimumFOV, 179f);

		_minimumFOV = _minFieldOfView;
		_maximumFOV = _maxFieldOfView;

		_cameraFOV = Mathf.Clamp(currentFieldOfView, _minimumFOV, _maximumFOV);

		GetComponent<Camera>().fieldOfView = _cameraFOV + _zoomRatio * Time.deltaTime;
	}

}
