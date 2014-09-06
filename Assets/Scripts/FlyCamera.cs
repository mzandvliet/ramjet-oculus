using UnityEngine;
using System.Collections;

public class FlyCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    private Vector2 _translationInput;
    private Vector2 _rotationInput;

	// Update is called once per frame
	void Update () {
	    float forward = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");
        
        float lookVertical = Input.GetAxis("Mouse Y");
        float lookHorizontal = Input.GetAxis("Mouse X");

	    _translationInput = Vector2.Lerp(_translationInput, new Vector2(strafe, forward), 10f * Time.deltaTime);
        _rotationInput = Vector2.Lerp(_rotationInput, new Vector2(lookHorizontal, lookVertical), 10f * Time.deltaTime);

	    transform.rotation = 
            Quaternion.Euler(0f, _rotationInput.x*100f * Time.deltaTime, 0f) *
            transform.rotation *
            Quaternion.Euler(_rotationInput.y * 100f * Time.deltaTime, 0f, 0f);

        transform.Translate(
            new Vector3(
                _translationInput.x * 10f * Time.deltaTime,
                0f,
                _translationInput.y * 10f * Time.deltaTime), Space.Self);
	}
}
