using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float scrollSpeed = 10;

    [SerializeField]
    private float movementSpeed = 10;


    [SerializeField]
    private float minOrthoSize = 5;

    [SerializeField]
    private float maxOrthoSize = 10;


    private Camera gameplayCamera;

    private float xAxis;
    private float yAxis;

    // Start is called before the first frame update
    void Start()
    {
        gameplayCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        gameplayCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        if (gameplayCamera.orthographicSize >= maxOrthoSize)
        {
            gameplayCamera.orthographicSize = maxOrthoSize; 
        }
        else if (gameplayCamera.orthographicSize <= minOrthoSize)
        {
            gameplayCamera.orthographicSize = minOrthoSize;
        }

        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        gameplayCamera.transform.Translate(new Vector3(xAxis, yAxis, 0.0f) * Time.deltaTime * movementSpeed);
    }
}
