using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class GameData : MonoBehaviour {

	public static GameData instance;
	public PlayerData myData;

	// Use this for initialization
	void Start () {
		if (instance == null) {

			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		if (myData == null || !myData.isInitialised()) {
			myData = new PlayerData();
		}
	}

	public void Save(string path){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + path, FileMode.Open);
		bf.Serialize (file, myData);
		file.Close ();
	}

	public void Load(string path){
		if (File.Exists (Application.persistentDataPath + path)) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);
			myData = (PlayerData)bf.Deserialize(file);
			file.Close();
		}
	}
}

[Serializable]
public class PlayerData{
	bool[] trophies;

	public PlayerData(){
		trophies = new bool[10];
		for (int i=0; i < 10; i++) {
			trophies[i] = false;
		}
	}

	public void getTrophy(int trophyID){
		if (trophyID >= 0 && trophyID < 10) {
			trophies [trophyID] = true;
		}
	}
	
	public bool isInitialised(){
		if (trophies == null || trophies.Length == 0) {
			return false;
		}
		return true;
	}
}
