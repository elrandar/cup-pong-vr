using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    public Transform mainCamera;
    public Transform leftController;
    public Transform rightController;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            head.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);

            head.position = mainCamera.position;
            head.rotation = mainCamera.rotation;
            leftHand.position = leftController.position;
            leftHand.rotation = leftController.rotation;
            rightHand.position = rightController.position;
            rightHand.rotation = rightController.rotation;


            // MapPosition(head, XRNode.Head);
            // MapPosition(leftHand, XRNode.LeftHand);
            // MapPosition(rightHand, XRNode.RightHand);
        }
    }
 
    void MapPosition(Transform target, XRNode node)
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = position;
        target.rotation = rotation;
    }
}
