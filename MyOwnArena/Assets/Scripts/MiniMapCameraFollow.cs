using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraFollow : MonoBehaviour
{
    [SerializeField] private MiniMapSettings settings;
    [SerializeField] private float cameraHeight;
    
    private void Awake()
    {
        settings = GetComponentInParent<MiniMapSettings>();
        cameraHeight = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = settings.targetToFollow.transform.position;
        transform.position = new Vector3(targetPosition.x, targetPosition.y + cameraHeight, targetPosition.z);

        if(settings.rotateWithTheTarget)
        {
            Quaternion targetRotation = settings.targetToFollow.transform.rotation;

            transform.rotation = Quaternion.Euler(90, targetRotation.eulerAngles.y, 100);
        }
    }
}
