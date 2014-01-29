using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Body : MonoBehaviour {
	
	// All Body-objects add themselves to this list
	public static List<Body> sBodies = new List<Body>();

	// This flag must be toggled when the game is over
	public static bool gameOver = false;
	public static int planetsLost = 0;
	public static int planets = 2;
	public static int score = 0;
	public GameObject Explosion;
	
	void OnGUI () {
		GUI.color = Color.yellow;
        GUI.Label(new Rect(15, 15, 100, 20), "SCORE:  " + score);
		
		if(score >= 1000){
   			if(GUI.Button(new Rect(10, 100, 200, 100), "Super Shots - 1000 points")){
    
     		score-=1000;
			}
		}	
		GUI.color = Color.blue;
		if(gameOver){
			if(GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "Game Over")){
				exit = true;
			}
		}
	}
	
	
	// The velocity of the body.
	protected Vector2 mVelocity = new Vector2(0f, 0f);
	public Vector2 Velocity {
		get { return mVelocity; }
	}

	// The mass of the body
	public float mMass;
	public float Health;
	public int Value;
	public bool quit = false;
	public bool exit = false;


	protected virtual void Start () {
		sBodies.Add (this);	
		
	}
	
	
	protected virtual void Update () {
		if (!gameOver) {
			
			UpdateVelocity();
			AddVelocityToPosition();
		} else {
			
			if(exit){
				exit = false;
				quit = false;
				gameOver = false;
				score = 0;
				planetsLost = 0;
				Application.LoadLevel(0);
				
			}
			
		}
	}
	
	void OnApplicationQuit(){
		quit = true;
	}
	
	void OnDestroy() {
		if(!quit && Explosion){
			Instantiate (Explosion, transform.position, transform.rotation);
		}
		sBodies.Remove(this);	
	}





	/* Updates the velocity according to all other bodies.
	 * 
	 * Note: The only "output" of the method is to re-assign
	 * the value of 'mVelocity'. mVelocity should not be affected
	 * by the delta-time.
	 */
	protected virtual void UpdateVelocity() {
		Vector2 acceleration = new Vector2();

		foreach (Body tempBody in sBodies) {
			if (tempBody != this && tempBody.gameObject.activeSelf) {

				Vector3 direction = tempBody.transform.position - transform.position;
				direction.Normalize();

				float distance = Vector3.Distance(transform.position, tempBody.transform.position);

				float pull = mMass * tempBody.mMass / distance * distance;

				acceleration += new Vector2(direction.x * pull, direction.y * pull);
			}
		}

		mVelocity += acceleration * Time.deltaTime;
	}

	protected void AddVelocityToPosition() {
		Vector3 nPos = transform.position;
		nPos.x += mVelocity.x * Time.deltaTime + 0f;
		nPos.y += mVelocity.y * Time.deltaTime + 0f;
		nPos.z += 0f;
		transform.position = nPos;
	}

	protected bool CheckPosition() {
		if (Vector3.Distance(transform.position, new Vector3(0,0,0)) > 600) {
			return false;
		}
		else return true;
	}
	
	public virtual void OnTriggerEnter(Collider collider){
		
		if(gameObject.tag == "Asteroid" && collider.gameObject.tag == "Asteroid"){
			
			//don't do anything.
			
		} else if (gameObject.tag == "Bullet" && collider.gameObject.tag == "Asteroid"){
			
			Destroy(gameObject);
			
			Body asteroid = collider.GetComponent<Body>();
			asteroid.Health--;
			
			if (asteroid.Health == 0){
				score += asteroid.Value;
				Destroy(collider.gameObject);
				
			}
			
			
		} else if (gameObject.tag == "Planet"){
			
			//destroy other.
			Destroy(collider.gameObject);
			
			Body Planet = gameObject.GetComponent<Body>();
				
			Planet.Health -= 1;
			if (Planet.Health == 0){
				
				Destroy(gameObject);
				planetsLost ++;
				
				if (planetsLost >= planets){
					gameOver = true;
				}
				
			}
						
		} 
	}
}
