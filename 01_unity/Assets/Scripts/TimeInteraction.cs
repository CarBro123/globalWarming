using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeInteraction : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	public RawImage playButton;
	public RawImage pauseButton;
	public RawImage backButton;
	public RawImage forwardButton;
	public Color normal;
	public Color selected;
	private SteamVR_Controller.Device device;
	private bool isPaused = true;
	private bool menuPressed = false;

	// Use this for initialization
	void Start () {
		playButton.color = normal;
		pauseButton.color = normal;
		forwardButton.color = normal;
		backButton.color = normal;
		pauseButton.enabled = false;
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	

	void FixedUpdate () {
		device = SteamVR_Controller.Input((int)trackedObj.index);

		if (device.GetPressUp (SteamVR_Controller.ButtonMask.ApplicationMenu)) {

			if (isPaused) {
				playButton.color = normal;
				playButton.enabled = false;
				pauseButton.enabled = true;
			
			} else {
				pauseButton.color = normal;
				pauseButton.enabled = false;
				playButton.enabled = true;
			}

			isPaused = !isPaused;
		}

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			if (isPaused) playButton.color = selected;
			else pauseButton.color = selected;
		}


		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad)) {

			Vector2 touchpad = (device.GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis0));

			// Forward Button gedrückt
			if (touchpad.x > 0.15f) {
				forwardButton.color = selected;
			}

			// Backward Button gedrückt
			if (touchpad.x < -0.15f) {
				backButton.color = selected;
			}
		}

		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			forwardButton.color = normal;
			backButton.color = normal;
		}
	}


}
