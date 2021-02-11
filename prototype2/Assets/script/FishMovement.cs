using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
	public Vector2 speed = new Vector2(20.0f, 20.0f);
	private Vector2 movement;
	private float inputX;
	private float inputY;

	private float frenzy = 0.0f;
	public bool frenzyReset = false;

	private float suffocateTimer = 0.0f;

	private int frenzyCount = 0;

	private restart restartScript;

	void Start()
    {
		restartScript = gameObject.GetComponent<restart>();
	}
	

	void Update()
	{
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");
		
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		if (movement.x == 0.0f && movement.y == 0.0f)
        {
			suffocateTimer += Time.deltaTime;
        }
		else
        {
			suffocateTimer = 0.0f;
        }

		

		var dist = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;

		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;

		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);

		if (movement != Vector2.zero)
		{
			float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

		if (frenzyReset)
        {
			frenzy = 0.0f;
			speed.x = 15.0f;
			speed.y = 15.0f;
			frenzyReset = false;
			frenzyCount = 0;
        }
		else
        {
			frenzy += Time.deltaTime;
		}

		
		if (frenzy >= 2.0f)
        {
			frenzy = 0.0f;
			frenzyCount++;
			float increase = speed.x * 1.25f;

			if (increase > 40.0f)
			{
				increase = 40.0f;
			}

			speed.x = increase;
			speed.y = increase;
        }

		if (frenzyCount == 5)
        {
			restartScript.Invoke("DieMessage", 0f);
			gameObject.GetComponent<AudioSource>().Play();
			restartScript.Invoke("Restart", 1f);
		}

		if (suffocateTimer >= 1.5f)
		{
			restartScript.Invoke("DieMessage", 0f);
			gameObject.GetComponent<AudioSource>().Play();
			restartScript.Invoke("Restart", 1f);
		}
	}


	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	
	}
