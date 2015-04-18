var isQuitButton = false;
static var music = 0;

function OnMouseEnter(){
	renderer.material.color = Color.red;
}

function OnMouseExit(){
	renderer.material.color = Color.black;
}

function OnMouseUp(){
	if (this.name == "txt_play1"){
		Application.LoadLevel(2);
		music = 1;
	}
	else if (this.name == "txt_play2"){
		Application.LoadLevel(3);
		music = 2;
	}		
}