public var faceValue = 0;

public var quieto = false;
public var prevPosition;

public var dieComp;

function OnTriggerEnter( other : Collider ) {

	dieGameObject = GameObject.Find("Dice1");

	dieComp = dieGameObject.GetComponent("DieValue");

	dieComp.currentValue = 7 - faceValue;

	//Debug.LogError(dieValueComponent.currentValue);

}

function FixedUpdate(){
	dice = GameObject.Find("Dice1");
	
	if (prevPosition != dice.transform.position){
		prevPosition = dice.transform.position;
		quieto = false;
	} else if (!quieto){
		quieto = true;
		//GameObject.Find("pjCono").transform.position = GameSystem.Tiles[dieComp.currentValue].Position;
		//dieValueComponent = dice.GetComponent("DieValue");
		//dieValueComponent.currentValue = 7 - faceValue;
		//Debug.LogError("Quieto: " + (7 - faceValue));
		//Debug.LogError(dieComp.currentValue);
	}
}