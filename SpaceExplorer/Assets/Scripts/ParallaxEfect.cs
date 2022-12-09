using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEfect : MonoBehaviour

{
<<<<<<< HEAD
    [SerializeField] private float parallaxMutiplier;
    
    private Transform cameraTransform;//referencia al componete de transform de la camera 
    private Vector3 previousCameraPosition;//posicion anterior de la camara
    private float spriteWidth, startPosition;
=======

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;
>>>>>>> parent of 7fd4af5 (parallax update)
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;


    }

    // Update is called once per frame
    void LateUpdate()
    {
<<<<<<< HEAD
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x)* parallaxMutiplier;
        float moveAmount = cameraTransform.position.x * (1 - parallaxMutiplier);

        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = cameraTransform.position;

        if (moveAmount > startPosition + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPosition += spriteWidth;
        }
        else if (moveAmount < startPosition - spriteWidth) {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPosition -= spriteWidth;
        }
=======
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x)*0.3f;
        transform.Translate(new Vector3(deltaX, 0, 0));
>>>>>>> parent of 7fd4af5 (parallax update)
    }
}
