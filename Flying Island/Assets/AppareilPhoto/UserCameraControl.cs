using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class UserCameraControl : MonoBehaviour
{

    public Texture CameraTexture;
    private Fisheye fisheyeScript;
    private bool cameraEnable = false;

	// Use this for initialization
	void Start ()
	{
	    fisheyeScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Fisheye>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp("f"))
	    {
	        cameraEnable = !cameraEnable;
	        fisheyeScript.enabled = !fisheyeScript.enabled;
	    }
	}


    void OnGUI() {
        if (CameraTexture != null && cameraEnable)
        {
            GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),CameraTexture);
        }
    }
}
