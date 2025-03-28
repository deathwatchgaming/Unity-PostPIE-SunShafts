/*
 * File: Preview Camera Altitude
 * Name: PreviewCameraAltitude.cs
 * Author: DeathwatchGaming
 * License: MIT
 */

using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public enum CameraAltitudeType
{
    ft,
    m
}
  
public class PreviewCameraAltitude : MonoBehaviour
{
    // Game Objects
    [Header("Game Object")]

        [Tooltip("The Preview Camera Altitude Parent Game Object")]
        // GameObject _cameraAltitudeParent
        [SerializeField] private GameObject _cameraAltitudeParent;

    // Raw Images
    [Header("Raw Image")]

        [Tooltip("The Preview Camera HUD Interface Altitude Text background raw image")]
        //  RawImage _altitudeBackground
        [SerializeField] private RawImage _altitudeBackground;

    // Altitude Text
    [Header("Altitude Text")]

        [Tooltip("The Preview Camera Interface Altitude Text Mesh Pro Text")]
        // TextMeshProUGUI _cameraAltitudeText
        [SerializeField] private TextMeshProUGUI _cameraAltitudeText;

    // Altitude Unit Type
    [Header("Unit Type")]

        [Tooltip("The Preview Camera Altitude Text Altitude Measurement Unit Type")]
        // CameraAltitudeType _cameraAltitudeType
        [SerializeField] private CameraAltitudeType _cameraAltitudeType;

    // Enabled State
    [Header("Enabled State")]

        [Tooltip("The Preview Camera Altitude enabled state")]
        // bool CameraAltitudeEnabled is true
        public bool CameraAltitudeEnabled = true;

    // PreviewCameraAltitude _previewCameraAltitude
    public static PreviewCameraAltitude _previewCameraAltitude;

    // Start is called before the first frame update

    // private void Start
    private void Start()
    {
        // _previewCameraAltitude
        _previewCameraAltitude = this;

        _cameraAltitudeText.fontSize = 26;
        _cameraAltitudeText.fontStyle = FontStyles.SmallCaps;
        _cameraAltitudeText.enableAutoSizing = true;        
    }

    // Update is called every frame        

    // private void Update
    private void Update()
    {
        // if CameraAltitudeEnabled is true
        if (CameraAltitudeEnabled == true)
        {
            _cameraAltitudeParent.gameObject.SetActive(true);
            _altitudeBackground.gameObject.SetActive(true);
            _cameraAltitudeText.gameObject.SetActive(true);
            GetComponent<PreviewCameraAltitude>().enabled = true;
            //Debug.Log("The Preview Camera Altitude is enabled");
            UpdateHUD();
        }

        // else if CameraAltitudeEnabled is false
        else if (CameraAltitudeEnabled == false)
        {
            //Debug.Log("The Preview Camera Altitude is disabled");
            _cameraAltitudeParent.gameObject.SetActive(false);
            _altitudeBackground.gameObject.SetActive(false);
            _cameraAltitudeText.gameObject.SetActive(false);
            GetComponent<PreviewCameraAltitude>().enabled = false;
        }
        
    }

    // UpdateHUD
    private void UpdateHUD()
    {
        // if _cameraAltitudeType equals CameraAltitudeType ft
        if (_cameraAltitudeType == CameraAltitudeType.ft)
        {
            // _cameraAltitude text is Altitude: ft
            _cameraAltitudeText.text = "Altitude: " + (transform.position.y / 0.3048f).ToString("F0") + " ft";
        }

        // else if _cameraAltitudeType equals CameraAltitudeType m
        else if (_cameraAltitudeType == CameraAltitudeType.m)
        {
            // _cameraAltitude text is Altitude: m
            _cameraAltitudeText.text = "Altitude: " + transform.position.y.ToString("F0") + " m";            
        }

    }    
}
