using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour{
	// Normal Movements Variables
	public float walkSpeed;
	public float horizontalSpeed;
	public float verticalSpeed;
	
	private float curSpeed;
	private float maxSpeed;
	
	private Vector3 target;
	
	protected Animator animator;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		target = transform.position;
	}
	void FixedUpdate()
	{
		curSpeed = walkSpeed;
		maxSpeed = curSpeed;
		/*
		if(Input.GetMouseButtonDown(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
		}
		transform.position = Vector3.MoveTowards(transform.position, target, walkSpeed * Time.deltaTime);
		*/
		if ((horizontalSpeed == 0) && (verticalSpeed == 0))
		{
			animator.SetInteger("movementState", 0);
		}
		else if ((horizontalSpeed > 0) && (Mathf.Abs(horizontalSpeed) > Mathf.Abs (verticalSpeed)))
		{
			animator.SetInteger("movementState", 1); //east			
		}
		else if ((horizontalSpeed < 0) && (Mathf.Abs(horizontalSpeed) > Mathf.Abs (verticalSpeed)))
		{
			animator.SetInteger("movementState", 2); //west
		}
		else if ((verticalSpeed < 0) && (Mathf.Abs(horizontalSpeed) < Mathf.Abs (verticalSpeed)))
		{
			animator.SetInteger("movementState", 3); //south
		}
		else if ((verticalSpeed > 0) && (Mathf.Abs(horizontalSpeed) < Mathf.Abs (verticalSpeed)))
		{
			animator.SetInteger("movementState", 4); //north
		}		
		
		horizontalSpeed = Input.GetAxis("Horizontal")*curSpeed;
		verticalSpeed = Input.GetAxis("Vertical")*curSpeed;
		
		rigidbody2D.velocity = new Vector2(Mathf.Lerp(0, horizontalSpeed, 0.8f),
		                                   Mathf.Lerp(0, verticalSpeed, 0.8f));
	}
}
