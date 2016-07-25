using UnityEngine;
using System.Collections;



[RequireComponent (typeof (CharacterController))] 

public class PlayerController : MonoBehaviour {

    //Handling Variables
    public float rotationSpeed = 450;
    public float walkSpeed = 5;
    public float runSpeed = 0;

    //System variables
    private Quaternion targetRotation;

    //Components
    private CharacterController controller;


	// Use this for initialization
	void Start () {
        controller = GetComponent <CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }

        Vector3 motion = input;
        motion += Vector3.up * -8;
                    //if == 1             and                      1  * by .7 or 1
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;
        motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;


        controller.Move(motion * Time.deltaTime);


	}
}
