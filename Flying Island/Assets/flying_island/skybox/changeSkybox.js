#pragma strict

 
//public var space_skybox : Material; 
//public var Timer : float = 10f;


//space_skybox = Resources.Load("space_skybox.mat", typeof(Material)) as Material;

function OnTriggerEnter(other : Collider){
    RenderSettings.skybox = Resources.Load("space_skybox") as Material;
    Debug.Log ('TESTR0');
}