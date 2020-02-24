using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;

    [SerializeField] private Transform myTransform;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speedAmplifier = 1;

    [SerializeField] private float jumpAmplifier = 1;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float speedRun = 1;

    private float lastYposition = 0;
    // Start is called before the first frame update
    enum StateVariables
    {
        forwardMovement
    }
    
    void FixedUpdate()
    {
        float forward = Input.GetAxis("Horizontal");
        float y = (forward < 0) ? 270 : 90;
        Vector3 newRotation = new Vector3(0, y, 0);
        myTransform.eulerAngles = newRotation;

        isGrounded = lastYposition == myTransform.position.y;

        if (Input.GetKey(KeyCode.LeftShift)) {
            speedRun = 2;
        } else {
            speedRun = 1;
        }

        myAnimator.SetFloat(StateVariables.forwardMovement.ToString(), Mathf.Abs(forward * speedRun));

        if ( isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpAmplifier;
        }

        rb.velocity = new Vector3(forward * speedAmplifier * speedRun, rb.velocity.y, rb.velocity.z);

        lastYposition = myTransform.position.y;
    }

    
}
