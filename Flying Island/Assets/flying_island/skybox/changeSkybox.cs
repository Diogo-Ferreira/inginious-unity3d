using UnityEngine;
using System.Collections;

public class changeSkybox : MonoBehaviour {

    public Material night_skybox;
    public Material space_skybox;    

    // Use this for initialization
    void Start () {
        RenderSettings.skybox = night_skybox;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider Other)
    {
        RenderSettings.skybox = space_skybox;

        Debug.Log("Changer Skybox");
    }

    void OnTriggerExit(Collider Other)
    {
        Debug.Log("Out");
    }
}
