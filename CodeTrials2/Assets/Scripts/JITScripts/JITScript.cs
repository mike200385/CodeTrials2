using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * Handles all Just In Time Instructions and Promts in the game using an extensive switch statement
 */ 
public class JITScript : MonoBehaviour { 
	// JUST IN TIME INSTRUCTIONS

	public Text wordDisplay;
	public string jitName;
	public AudioSource getScientistChime, enterBriefDialogue;
	bool toggleZoom;
	GameObject player;

	// Use this for initialization
	void Start () {
		toggleZoom = false;
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	// Update is called once per frame
	void Update () {

	}
	/**
	 * Uses a switch sttement to change the text of the word displayer
	 * Also manages other objects in certain levels
	 */ 
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			switch (this.jitName) {

			//Hub Level
			case "HubIntro":
				wordDisplay.text = "Welcome to the Hub Room Codex. This room has many teleporters that will" +
					"send you to different parts of the ship in order to rescue the ship's scientists!\n\n" +
					"Head over to the terminal in the middle of the room to pick which room to go to first.\n\n" +
					"You can visit the rooms in any order you want, just be sure to save the scientists!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "HubTerminal":
				wordDisplay.text = "This terminal contains a switch statment, which is a code statement" +
					"that executes a certain command based on the 'case' it matches.\n\n" +
					"You need to set a variable called doorNumber to the number of the case you want to execute.\n" +
					"Head to the terminal and try it out. Use the Green Help Buttons if you feel lost.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "HubFinal":
				wordDisplay.text = "This final room has been locked and you can only get past after saving " +
					"at least 7 scientists! It will unlock itself once at least 7 scientistd are safe.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "HubCamera":
				if (toggleZoom) {
					player.GetComponent<PlayerMovement> ().setCamSize (6.4f);
					toggleZoom = !toggleZoom;
				} else {
					player.GetComponent<PlayerMovement> ().setCamSize(9.5f);
					toggleZoom = !toggleZoom;
				}
				break;

			case "NestedForCamera":
				if (toggleZoom) {
					player.GetComponent<PlayerMovement> ().setCamSize (8.0f);
					toggleZoom = !toggleZoom;
				} else {
					player.GetComponent<PlayerMovement> ().setCamSize(12.0f);
					toggleZoom = !toggleZoom;
				}
				break;

			//Array Level
			case "ArrayBriefing":
				wordDisplay.text = "There are more scientists to be saved using Arrays! \n\n" +
				"An array is a list of elements of the same type. \n\n" +
				"Arrays count their elements starting at 0! Remember that!\n\n" +
				"Arrays can be accessed like this: array_Name[num] Where num is a number.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "ArrayChallenge1":
				wordDisplay.text = "It seems some of the holo-platforms are disabled, which means you can't get across!" +
					"\nUse this terminal to try and fix them. Turn on the First, Third, and Last platforms.\n" +
					"Watch out for weird array indexes\n\n" +
					"Press 'C' to change the camera and look at the holo-platforms.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "ArrayChallenge2":
				wordDisplay.text = "The counter-weight platform is down, but you need to get across. " +
					"Hmm, see those weighted boxed up there, they seem linked to this terminal!\n\n" +
					"Put your coding skills to the test and drop a total of 14lbs on the platform.\n\n" +
					"Press 'V' to change the camera and look at the weighted boxes.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				break;
				//Specifically for managing cams in Arrya level since there are many cameras
			case "ArrayCams":
				GameObject cam = GameObject.Find ("ErrorCamera");
				GameObject cam2 = GameObject.Find ("SecondCameraARRAYACCESS");
				cam2.GetComponent<Camera> ().enabled = false;
				cam.GetComponent<Camera> ().enabled = false;
				break;

			//ARITH JITS
			case "DataTypeBriefing":
				wordDisplay.text = "There's only 1 scientist in here, blocked by 2 doors." +
				"The theme of this room is initialization and arithmetic math. \n \n" +
				"There are many datatypes used in programming such as int, bool, double, string, char, and float. \n" +
				"Ints hold whole numbers, doubles hold decimal values, chars hold single characters, and so on.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "DataTypeChallenge":
				wordDisplay.text = "The code is incomplete! To get past this first door, place the correct datatypes with their variables. You can do it!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "ArithBriefing":
				wordDisplay.text = "There are 5 main operators that are used: +, -, *, /, and %. \n" +
					"The % operator gives the remainder of a division. So 8 % 3 is 2.\n\n" +
					"Remember that the precedence of the operators is (), then *,/,%, followed by +,-.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "ArithChallenge":
				wordDisplay.text = "The code is incomplete! To open the door, set the equation to equal 2, don't give up!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			
			//First generic scientist response
			case "Scientist1":
				string tempTxt = "";
				int temp = Random.Range (1, 5);

				switch (temp) {

				case 1:
					tempTxt = "Thanks for saving me! I'll help find a way to escape from the ship!";
					break;
				case 2:
					tempTxt = "I never thought I'd get out of here! We either have to regain control of the ship" +
					"or bail out of here, and I'd rather bail!";
					break;
				case 3:
					tempTxt = "Took you long enough. Now let's get off this forsaken ship. ASAP.";
					break;
				case 4:
					tempTxt = "Is that you Codex? It is! I knew I was right in telling them to keep you operational!\n" +
					"I'll head to the others and see if we can devise a way out of this mess.";
					break;
				case 5:
					tempTxt = "Thank the heavens you're here. I don't know what I'd do if you didn't come for me!\n" +
					"We need to take an escape pod and head back to central base!";
					break;
				}
				wordDisplay.text = tempTxt;
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.incScientist ();
				playScientistChime ();
				break;
			//Second generic scientis response
			case "Scientist2":
				wordDisplay.text = "Thanks for saving me! Let me help you find an escape route with the others! " +
					"\nHey before you go though, let me tinker with your boots so you can " +
					"jump a little higher. All you have to do is press the space bar while you are " +
					"still jumping to jump again and reach higher places. Who knows, maybe you'll " +
					"find something cool! Or just hit your head. Only one way to find out!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.hasDoubleJump = true;
				GlobalController.Instance.incScientist ();
				playScientistChime ();
				break;
			case "MidLevelScientistArray":
				//solves camera problem in array level
				wordDisplay.text = "Thanks for saving me! We need to find a way to escape the ship ASAP! " +
					"But before we do, I can upgrade your legs and make you move a little faster. " +
					"There, got it. Okay, I am off to the escape vessel.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GameObject sci = GameObject.Find ("MidScientist");
				GlobalController.Instance.incScientist ();
				GlobalController.Instance.hasSpeedUp = true;
				playScientistChime ();
				Destroy (sci,7.0f);
				break;
			
			//CONDITIONAL LEVEL BRIEFINGS
			case "ConditionalBriefing":
				wordDisplay.text = "Three scientists are stuck behind three doors,  \n" +
					"The desktops in this wing operate using conditional logic, complete their code to release the scientists.\n " +
					"Conditional logic is extremely useful in creating if statements and loops.  \n" +
					"Remember these common operators:  \n" +
					"'!' - negation operator. \n '&&' - logical and operator. All conditions in the statement" +
					"must be true. \n '||' - logical or operator. Only one of the conditions need be true.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "BoolOpsBrief":
				wordDisplay.text = "The desktop ahead controls the elevator \n" +
				"and can take you up or down depending on your decision.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "LogicalAndBrief":
				wordDisplay.text = "You have arrived at the Logical And terminal. " +
				"These pylons in the ship's floor must be raised to open the door locking in " +
					"the scientist. Remember the key distinction between AND and OR.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "LogicalOrBrief":
				wordDisplay.text = "You have arrived at the Logical Or terminal. " +
					"These pylons in the ship's floor must be raised to open the door locking in " +
					"the scientist. Remember the key distinction between AND and OR.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "LogicalAndScientistJIT":
				wordDisplay.text = "I don't know what happened, this door just shut behind me. " +
				"We need to get out of here before we crash! I had a friend " +
				"stationed on the basement floor, did you find him?";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.incScientist ();
				GlobalController.Instance.logicalAndComplete = true;
				playScientistChime ();
				break;
			case "LogicalOrScientistJIT":
				wordDisplay.text = "It was so weird, I was just minding my own business staring " +
				"at this wall, and then BAM, big red door! " +
				"Did you get my friend on the upper level? " +
				"He owes me 20 space creds. Are we crashing?";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.incScientist ();
				GlobalController.Instance.logicalOrComplete = true;
				playScientistChime ();
				break;
			case "ExitDoorScientistJIT":
				wordDisplay.text = "Good work! Hurry through the portal, there are more like me to be helped! " +
					"Take these bombs too, don't use them on exterior walls though, because then " +
					"you will get sucked out to space and you'll just be flying around out there until " +
					"you run out of batteries or whatever. Tata!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.incScientist ();
				GlobalController.Instance.hasBombs = true;
				playScientistChime ();
				break;

		//LOOP LEVEL JITS
			case "LoopBriefing":
				wordDisplay.text = "Three scientists are stuck behind doors in this sector. \n" +
					"The desktops in this wing require the use of loops to release the door locks. \n" +
					"Loops are vital to programming, they allow you to perform various statements " +
					"a specific number of times. Ahead are desktops for a simple for loop, \n" +
					"a nested for loop and a simple while loop.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "SingleForBrief":
				wordDisplay.text = "You have arrived at the for loop terminal. Take note of the " +
					"number displayed on the door to solve this puzzle. The number given to the terminal" +
					" must match the displayed number on the door. ";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "NestedForBrief":
				wordDisplay.text = "You have arrived at the nested for loop terminal. \n" +
					"Be sure to look at the grid next to the desktop to discover the correct x, y \n" +
					"coordinate which is the passcode for exit.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "WhileBrief":
				wordDisplay.text = "You have arrived at the while loop terminal. \n" +
					"The scientist is trapped behind the laser, and the laser won't turn off \n" +
					"until the proper condition occurs. Use the desktop to turn off the laser.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			

			//FINAL LEVEL JITS
			case "FinalIntro":
				wordDisplay.text = "This is the escape room! All you need to do is get to the escape pod!\n\n" +
				"There are a few obstacles in your way though.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "IndentBriefing":
				wordDisplay.text = "This test deals with code indentation.\n\n" +
					"Use the onscreen buttons to indent the code so that it's tabbed properly.\n\n" +
					"The convention is that all code in an if/while/loop statement is tabbed once.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "FinalBriefing":
				wordDisplay.text = "You're almost there! The rest of the scientists are at the top of this room\n\n" +
				"You need to use what you've learned in order to make the sum 10, which will turn on the rising platform!\n\n" +
				"This is the final push! Time to finsh what you started!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.scientistAnalytics ();
				playDialogue ();
				break;
			case "FinalCompletion":
				wordDisplay.text = "You've made it! Thank you so much for rescuing us all!\n" +
					"The malware has spread throughout the ship and we can't get it back!\n" +
					"We're going to eject our escape pod and head back to base. We wouldn't be here without you.\n\n" +
					"Thank you a million times!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "FinalBase":
				wordDisplay.text = "Hey! You must be Codex! Thank's so much for saving the scientists! " +
					"The scientists were in trouble and you managed to get a lot done.\n\n" +
					"You learned code!\n" +
					"Honed your skills!\n" +
					"And saved the day!\n\n" +
					"Head to that portal over there to complete your mission. Thank you again!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			//COMPLETE THE LEVEL CONDITIONS
			case "ArithComplete":
				GlobalController.Instance.arithComplete = true;
				break;
			case "CondComplete":
				GlobalController.Instance.condComplete = true;
				break;
			case "ArrayComplete":
				GlobalController.Instance.arrayComplete = true;
				break;
			case "LoopComplete":
				GlobalController.Instance.loopComplete = true;
				break;

			//MISC JITS
			case "RaiseBarriers":
				this.gameObject.SetActive(false);
				//Destroy(this.gameObject);
				break;
			case "EscapePod": // launches the escape pod
				this.gameObject.SetActive (false);
//				Destroy(this.gameObject);
				playScientistChime(); // actually plays escape pod launch sound
				playDialogue(); // actually plays escape pod music
				break;

			case "BombBriefing":
				wordDisplay.text = "Use the left-click to drop a bomb in front you. \n" +
					"Keep a look out for walls like this as you look to escape the ship. \n" +
					"Don't worry, they can't hurt you.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;


				//Story Dialogue
			
			case "StoryOne":
				wordDisplay.text = "I feel selfish writing this, knowing full well how vital our mission is to the planet. \n" +
					"But the fact remains that we are millions of miles away from home and \n" +
					"I have not seen my family in years. \n" +
					"You take these assignments knowing the conditions, but you never appreciate \n" +
					"the magnitude of the commitment.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "StoryTwo":
				wordDisplay.text = "Every month I get transmissions from my son, " +
					"I left him when he was four... and now he is turning 14, and our assignment " +
					"isn’t over for three more years. I missed so many milestones that a parent " +
					"gets to experience just to wake up every day and look at the void. ";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "StoryThree":
				wordDisplay.text = "Another day another round of system checks. " +
					"Nothing went wrong today. For the 3347th time in a " +
					"row. " +
					"I am not even sure what it is that I am " +
					"doing up here? The navigation system isn’t going " +
					"anywhere…this ship is on autopilot.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "StoryFour":
				wordDisplay.text = "Systems all clear again today. " +
					"If I can just override the autopilot system and send us hurtling " +
					"toward the sun…force the crew to abandon the mission...we will lose the ship " +
					"but I can’t take this anymore... " +
					"I need to get out.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "StoryFive":
				wordDisplay.text = "It’s done. I don’t think any of my colleagues suspect me. " +
					"Now I just need to wait it out until the Codex bot activates the escape protocols " +
					"and we can get out of here. I hope he gets everyone. You can replace a ship, " +
					"but I don’t want any of the eight other scientists on board to be left behind. ";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "StorySix":
				wordDisplay.text = "I know that I've committed a crime, and I'll never be able get past this...\n\n" +
					"But humans need love and interaction.\n\n" +
					"None of that exists here...\n" +
					"10 years of repetitive work has taken it's toll...\n\n" +
					"This is my final log...Codex is on his way...I'll see my son soon...";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "SecretScientist":
				wordDisplay.text = "I can't believe it! It worked! Get me out of here! Please " +
					"tell me you got the others. I just " +
					"miss my family so much. Let's go! We have to hurry!";
				Time.timeScale = 0.0f;
				playDialogue ();
				GlobalController.Instance.incScientist ();
				break;
			}
		}
	}
	/// Plays the chime when you save a scientist
	void playScientistChime(){
		getScientistChime.Play ();
		getScientistChime.loop = false;
	}
	/// plays the chime when you enter e text box
	void playDialogue(){
		enterBriefDialogue.Play ();
		getScientistChime.loop = false;
	}
		

}
