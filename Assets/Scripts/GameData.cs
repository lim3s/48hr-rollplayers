using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameData : MonoBehaviour {

	public static GameData data;

	PlayerData myData;

	// Use this for initialization
	void Start () {
		if (data == null) {
			DontDestroyOnLoad (gameObject);
			data = this;
		} else if (data != this) {
			Destroy(gameObject);
		}
		if (myData == null) {
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

	public void getTrophy(int trophyID){
		myData.getTrophy (trophyID);
	}
}

[Serializable]
class PlayerData{
	public float health;
	bool[] trophies;

	public PlayerData(){
		trophies = new bool[10];
		for (int i=0; i < 10; i++) {
			trophies[i] = false;
		}
		this.health = 100;
	}

	public void getTrophy(int trophyID){
		trophies [trophyID] = true;
	}
}
