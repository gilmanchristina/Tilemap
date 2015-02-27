using UnityEngine;
using System.Collections;

public class HSController : MonoBehaviour
{
	private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
	public string addScoreURL = "http://localhost/Unity/addscore.php"; //be sure to add a ? to your url
	public string highscoreURL = "http://localhost/Unity/display.php";
	public string FullMonsterURL = "http://localhost/Unity/FullMonsterData.php";
	public string[] monsterName;
	public string[] monsterData;
	public Vector3 gridPosition = Vector3.zero;
	public static int Block;
	public bool[] button1;
	public string[] monsterRow; 
	MD5 _MD5 = new MD5();
	//savecreate guidatabase = new savecreate();
	WWW hs_get;
	WWW mr_get;

	void Start(){
		StartCoroutine(GetScores());
	}

	void Update(){
	} 

	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores(string Name, int Hit_Dice){
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = _MD5.Md5Sum(name + Hit_Dice + secretKey);
		string post_url = addScoreURL + "Name=" + WWW.EscapeURL(name) + "&Hit_Dice=" + Hit_Dice + "&hash=" + hash;
		
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done		
		if (hs_post.error != null){
			print("There was an error posting the high score: " + hs_post.error);
		}
	}
	
	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	IEnumerator GetScores(){
		hs_get = new WWW(highscoreURL);
		mr_get = new WWW(FullMonsterURL);

		yield return hs_get;
		string data = hs_get.text;
		monsterName = data.Split(',');

		data = mr_get.text;
		monsterData = data.Split(',');
		
		if (hs_get.error != null){
			print("There was an error getting the high score: " + hs_get.error);
		}
		else{
		}
	}			
}