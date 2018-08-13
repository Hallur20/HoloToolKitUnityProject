using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeScript : MonoBehaviour, IInputClickHandler, ISpeechHandler {
    public Material blue, red;
    private GameObject currentGameobject = null;

    public void OnInputClicked(InputClickedEventData eventData)
    {
            if (currentGameobject != null)
            {
                Debug.Log("youre looking at: " + currentGameobject.name);
            }
            else
            {
                Debug.Log("youre looking at nothing.");
            }
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        if (eventData.RecognizedText.Equals("hello")) {
            Debug.Log("hellooooo");
        }
    }

    // Use this for initialization



    void Start () {

                //InputManager.Instance.PushFallbackInputHandler(gameObject);

    }


    // Update is called once per frame
    void Update () {
        Vector3 headPos = Camera.main.transform.position;
        Vector3 gazePos = Camera.main.transform.forward;
        RaycastHit hitInfo;

        if (Physics.Raycast(headPos, gazePos, out hitInfo, 20.0f, Physics.DefaultRaycastLayers)) {
            currentGameobject = hitInfo.collider.gameObject;
            hitInfo.collider.GetComponent<Renderer>().material = blue;
        } else if (currentGameobject != null)
        {
           currentGameobject.GetComponent<Renderer>().material = red;
            currentGameobject = null;
        }
	}
}
