/***************************************************************
* Filename:       	InputManager.cs                            *
* Authors:        	Ophelia Carlin                             *
* Version Authors:	Ophelia Carlin                             *
* Current Version:  0.0.1                                      *
* Previous Version: 0.0.0                                      *
* Creation Date:  	May 7, 2026                                *
* Last Modified:  	May 7, 2026                                *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset (Procedurogue Generation)     *
* Purpose:        	Manager script to handle Unity's input     * 
*                   system.                                    *
* Version Changes:	Created and hopefully finished.            *
****************************************************************/

using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using System;
using UnityEditor.Rendering.LookDev;
using UnityEngine.Animations;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine.TextCore.Text;

public class InputManager : MonoBehaviour
{

    public static InputManager _singletonInstance;

    public static InputManager SingletonInstance
    {
        get
        {
            return _singletonInstance;
        }
    }
    private InputAction _selectInputAction;
    private InputAction _deselectInputAction;
    private InputAction _aimInputAction;
    private InputAction _cameraInputAction;
    private InputAction _pauseInputAction;

    [SerializeField]
    private InputActionAsset _theActionMap;
    public bool SelectInput { get; private set; }
    public bool DeselectInput { get; private set; }
    public Vector2 AimInput { get; private set; }
    public Vector2 CameraInput { get; private set; }
    public bool PauseInput { get; private set; }

    private bool isGameplayAllowed = false;

/**********************************************************************************/
    /*                                                                                */
    /* Function name: Awake                                                           */
    /* Description: If one doesn't exist, creates a singleton for input action        */
    /*              manager. Also assigns the input variables.                        */
    /* Parameters: None                                                               */           
    /* Return Value: N/A                                                              */
    /*                                                                                */
/**********************************************************************************/

    void Awake()
    {
        // Boilerplate code
        if (_singletonInstance == null)
        {
            _singletonInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _selectInputAction = _theActionMap.FindActionMap("MenuNavigation").FindAction("Select");
        _deselectInputAction = _theActionMap.FindActionMap("MenuNavigation").FindAction("Deselect");
        _aimInputAction = _theActionMap.FindActionMap("MenuNavigation").FindAction("Aim");
        _cameraInputAction = _theActionMap.FindActionMap("MenuNavigation").FindAction("CameraInput");
        _pauseInputAction = _theActionMap.FindActionMap("MenuNavigation").FindAction("PauseInput");

        _selectInputAction.Enable();
        _deselectInputAction.Enable();
        _aimInputAction.Enable();
        _cameraInputAction.Enable();
        _pauseInputAction.Enable();
    }

    private void Update()
    {
        SelectInput = _selectInputAction.WasPressedThisFrame();
        DeselectInput = _deselectInputAction.WasPressedThisFrame();
        //_selectInputAction.performed += context => SelectInput = true;
        //_selectInputAction.canceled += context => SelectInput = false;
        _aimInputAction.performed += context => AimInput = context.ReadValue<Vector2>();
        _aimInputAction.canceled += context => AimInput = Vector2.zero;
    }

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: OnEnable                                                        */
    /* Description: Enables the action map on enable.                                 */
    /* Parameters: None                                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    private void OnEnable()
    {
        _theActionMap.Enable();
    }
/**********************************************************************************/
    /*                                                                                */
    /* Function name: OnEnable                                                        */
    /* Description: Disables the action map on disable.                               */
    /* Parameters: None                                                               */           
    /* Return Value: N/A                                                              */
    /*                                                                                */
/**********************************************************************************/
    private void OnDisable()
    {
        _theActionMap.Disable();
    }

/**********************************************************************************/
    /*                                                                                */
    /* Function name: ToggleGameplayControls                                          */
    /* Description: A simple public function that just enables or disables player     */
    /*              controls depending on whether or not they're currently active.    */
    /* Parameters: None                                                               */           
    /* Return Value: N/A                                                              */
    /*                                                                                */
/**********************************************************************************/
    public void ToggleGameplayControls()
    {
        if (isGameplayAllowed == false)
        {
            _selectInputAction.Enable();
            _deselectInputAction.Enable();
            _aimInputAction.Enable();
            _cameraInputAction.Enable();
            _pauseInputAction.Enable();
            isGameplayAllowed = true;
        }
        else
        {
            _selectInputAction.Disable();
            _deselectInputAction.Disable();
            _aimInputAction.Disable();
            _cameraInputAction.Disable();
            _pauseInputAction.Disable();
            isGameplayAllowed = false;
        }
    }

/**********************************************************************************/
    /*                                                                                */
    /* Function name: GetMouse3DPosition                                              */
    /* Description: A function that uses the mouse's current position to fire a       */
    /*              raycast from the camera, giving a rough approximation of its      */
    /*              location in 3D space.                                             */
    /* Parameters:  None.                                                             */
    /* Return Value: Vector3                                                          */
    /*                                                                                */
/**********************************************************************************/
    public Vector3 GetMouse3DPosition()
    {
        Ray Mouse3DPositionChecker = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Mouse3DPosition;
        Physics.Raycast(Mouse3DPositionChecker, out Mouse3DPosition);
        
        return Mouse3DPosition.transform.position;
    }

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetMouse3DTarget                                                */
    /* Description: A function that uses the mouse's current position to fire a       */
    /*              raycast from the camera, returning the item that it hits          */
    /*              at the location of the mouse                                      */
    /* Parameters:  None.                                                             */
    /* Return Value: Vector3                                                          */
    /*                                                                                */
    /**********************************************************************************/
    public RaycastHit GetMouse3DTarget()
    {
        Ray Mouse3DPositionChecker = Camera.main.ScreenPointToRay(AimInput);
        RaycastHit Mouse3DPosition;
        Physics.Raycast(Mouse3DPositionChecker, out Mouse3DPosition);

        return Mouse3DPosition;
    }

}