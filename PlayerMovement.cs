using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public Animator animator;
	// breyta sem vísar í animator stjórann

	public float runSpeed = 40.0f;
	// breyta sem heldur utan um hraða leikmanns þegar hann hreyfir sig

	float horizontalMove = 0.0f;
	// breyta sem heldur utan um hvort leikmaður er að hreyfa sig til hægri eða vinstri

	bool jump = false;
	// breyta um hvort að leikamaður á að hoppa eða ekki, breytan er annað hvort virk eða óvirk, hún byrjar á að vera óvirk
	bool crouch = false;
	// breyta sem segir um hvort að leikmaður á að krjúpa eða ekki, breytan er annað hvort virk eða óvir, hún byrjar óvirk

	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		// uppfærum horizontalMove breytuna eftir því hvort að leikmaður er að hreyfa sig til hægri eða vinstri
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		// tengjum horizonalMove við float breytuna sem skilgreinir hvenær leikmaður spilar animation idle og animation run
		// Abs gildið er svo að horizontal move verði alltaf jákvætt því að run animation er bara spilað ef að gildið er hærra en 0

		if (Input.GetButtonDown("Jump"))
		// ef að ýtt er á takkan sem merktur er jump, í þessu tilfelli er það bil-takkin (merkingu takka er hægt að breyta í project settings í unity)
		{
			jump = true;
			// er jump breytan virkt
			animator.SetBool("IsJumping",true);
			// kveikjum á hopp animation
		}
		if (Input.GetButtonDown("Crouch"))
		// ef að ýtt er á takka sem merktur er crouch
		{
			crouch = true;
			// er crouch breytan virkt
		}
		else if (Input.GetButtonUp("Crouch"))
		// annars ef að ekki er verið að halda niðri crouch takkanum
		{
			crouch = false;
			// verður crouch breytan óvirk
		}
	}

	public void OnLanding(){
		animator.SetBool("IsJumping", false);
		// þegar kallað er á fallið OnLanding() animation IsJumping hættir að spila
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
		// ef að kallað er á fallið OnCrouching() animation IsCrouchong er spilað ef að ifCrouching breytan er virk
	}

	void FixedUpdate()
	{
		// hreyfum leikmann
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
		// eftir að leikmaður er búin að hoppa einu sinni verður jump óvirkt svo að leikmaður haldi ekki áfram að hoppa
	}
}