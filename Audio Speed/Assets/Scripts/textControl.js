var isQuitButton = false;

function OnMouseEnter(){
	renderer.material.color = Color.red;
}

function OnMouseExit(){
	renderer.material.color = Color.black;
}

function OnMouseUp(){
	if (isQuitButton)
		Application.Quit();
	else
		Application.LoadLevel(1);
}