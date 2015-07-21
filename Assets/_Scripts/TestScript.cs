using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TestScript : MonoBehaviour {

	public int Count = 1;
	
	public GameObject NormalPrefab;
	
	void Start() 
	{
		DateTime begin = DateTime.UtcNow;
		
		TestNormal ();
		//TestFactory ();
		
		print ("time elapsed : " + (DateTime.UtcNow - begin).TotalSeconds);
	}
	
	private void TestNormal() {
		for (int i=0; i<Count; i++) {
			NormalCreateInstance ();
		}
	}
	
	private void TestFactory() {
		for (int i=0; i<Count; i++) {
			FactoryCreateInstance ();
		}
	}
	
	private GameObject NormalCreateInstance() {
		GameObject instance = Instantiate (NormalPrefab);
		return instance;
	}
	
	private GameObject FactoryCreateInstance() 
	{
		GameObject instance = new GameObject ("Instance");
		PrefabScript prefab = instance.AddComponent<PrefabScript> ();

		string path = "_Textures/t";
		List<Sprite> list = new List<Sprite> ();

		for (int i=1; i<=40; i++) {
			Sprite s = Resources.Load<Sprite>(path + (i) + ".png");
			list.Add(s);
		}

		prefab.Sprites = list.ToArray ();
			
		return instance;
	}
}
