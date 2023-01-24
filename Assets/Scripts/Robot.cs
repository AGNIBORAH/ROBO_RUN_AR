using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Rigidbody robotBody;
    [SerializeField] private Animator robotAnim;

    private Joystick joystick;

    private void OnEnable() //create a method
    {
        joystick = FindObjectOfType<Joystick>(); //searches the entire scene and finds the jpystick component in the scene.
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the robot
        Vector3 targetDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y); //assign the joystick's x and y value to the 
                                                                                              //x and z value of the vector3.

        //rotate the forward direction of robot to the target direction by 1 degree per frame.
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(direction);

        //moving the robot
        if(joystick.Direction.magnitude > 0) // you are pushing the joystick
        {
            robotBody.AddForce(moveSpeed * transform.forward);
            robotAnim.SetBool("Running", true);
        }
        else
        {
            robotAnim.SetBool("Running", false);
        }
    }
}
