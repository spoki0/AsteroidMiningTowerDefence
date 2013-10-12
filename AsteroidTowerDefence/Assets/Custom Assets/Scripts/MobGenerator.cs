﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobGenerator : MonoBehaviour {
	
	public enum State {
		Idle, 
		Initialize,
		Setup,
		SpawnMob
	}
	
	public GameObject[] mobPrefabs; 		//an array to hold all prefabs of mobs we want to spawn
	public GameObject[] spawnPoints;        //this array will hold a reference to the spawnpoints
	
	
	public State state;		
	
	
	void Awake(){
		state = MobGenerator.State.Initialize;
	}
	
	
	//this is our local variable that holds our current state
	// Use this for initialization
	IEnumerator Start () {
	
		while(true){
			switch(state){
			case State.Initialize:
				Initialize();
				break;
			case State.Setup:
				Setup();
				break;
			case State.SpawnMob:
				SpawnMob();
				break;
			
			
			}
			
			yield return 0;
		}
	}
	
	private void Initialize(){
		Debug.Log ("***We are in the Initialize function***");
		
		if(!CheckForMobPrefabs()){
			return;
		}
		
		if(!CheckForSpawnPoints()){
			return;
		}
		
		state = MobGenerator.State.Setup;
	}
	
	private void Setup(){
		Debug.Log ("***We are in the Setup function***");
		state = MobGenerator.State.SpawnMob;
	}
	
	private void SpawnMob(){
		Debug.Log ("***We are in the SpawnMob function***");
		
		GameObject[] gos = AvailableSpawnPoints();
		
		for(int cnt = 0; cnt < gos.Length; cnt++){
			GameObject go = Instantiate(mobPrefabs[Random.Range(0, mobPrefabs.Length)],
										gos[cnt].transform.position,
										Quaternion.identity
										)as GameObject;
			
		}
		
		state = MobGenerator.State.Idle;
	}
	
	
	//check to see that we have at least one mob prefab to spawn
	private bool CheckForMobPrefabs(){
		if(mobPrefabs.Length > 0){
			return true;
		} else {
			return false;
		}
		
	}
	
	
	
	//check to see if we have at least one spawnpoint to spawn mobs at
	private bool CheckForSpawnPoints(){
		if(spawnPoints.Length > 0){
			return true;
		} else {
			return false;
		}
		
	}
	
	
	//generate a list of available spawnpoints that do not have any mobs childed to it
	private GameObject[] AvailableSpawnPoints(){
		List<GameObject> gos = new List<GameObject>();
		
		
		for(int cnt = 0; cnt < spawnPoints.Length; cnt++){
			if(spawnPoints[cnt].transform.childCount == 0){
				Debug.Log ("***Spawn Point Available***");
				gos.Add(spawnPoints[cnt]);
				
			}
			
		}
		
		return gos.ToArray ();
		
	}
	
}
