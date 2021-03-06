﻿using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour
{
	public GameObject player;
	public GameObject playerBullet;
	public GameObject enemy;
	public GameObject spawner;

	//Here is a private reference only this class can access
	private static Factory _instance;
	
	//This is the public reference that other classes will use
	public static Factory create {
		get {
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<Factory> ();
			return _instance;
		}
	}

	GameObject InitializeParameters (GameObject created)
	{
		created.SetActive (true);
		created.SendMessage ("SetPlayer", player, SendMessageOptions.DontRequireReceiver);
		return created;
	}

	public GameObject ByReference (GameObject gameObject, Vector2 position, Quaternion rotation)
	{
		return InitializeParameters (ObjectPool.pool.Pull (gameObject, position, rotation));
	}

	public GameObject PlayerBullet (Vector2 position, Quaternion rotation)
	{
		return InitializeParameters (ObjectPool.pool.Pull (playerBullet, position, rotation));
	}
	
	public GameObject Enemy (Vector2 position, Quaternion rotation)
	{
		return InitializeParameters (ObjectPool.pool.Pull (enemy, position, rotation));
	}

	public GameObject Spawner (Vector2 position, Quaternion rotation)
	{
		return InitializeParameters (ObjectPool.pool.Pull (spawner, position, rotation));
	}

}
