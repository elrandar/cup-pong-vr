using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;


class ImprovedHandController : MonoBehaviour
{

    [SerializeField] InputActionReference controllerActionGrip;
    [SerializeField] InputActionReference controllerActionTrigger;
    [SerializeField] InputActionReference controllerActionButton;


    private Animator _handAnimator;

    private void Awake()
    {
        controllerActionGrip.action.started += GripPress;
        controllerActionTrigger.action.started += TriggerPress;
        controllerActionButton.action.performed += ButtonPress;

        _handAnimator = GetComponent<Animator>();
    }


    private void ButtonPress(InputAction.CallbackContext obj)
    {
        Transform transform = GetComponent<Transform>();
        PhotonNetwork.Instantiate("Ball", transform.position, transform.rotation);
    }

    private void TriggerPress(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<float>());
        _handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
        _handAnimator.SetFloat("Grip", 0);
    }

    private void GripPress(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<float>());
        _handAnimator.SetFloat("Grip", obj.ReadValue<float>());
        _handAnimator.SetFloat("Trigger", 0);     
    }

}