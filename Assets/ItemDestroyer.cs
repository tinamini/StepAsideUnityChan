using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>

/// </summary>
public class ItemDestroyer : MonoBehaviour
{
	#region Fields
	/// <summary>
	/// カメラオブジェクト
	/// </summary>
	private new GameObject camera;
	#endregion

	#region Properties
	#endregion

	#region Methods
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Awake()
	{
		
	}

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start ()
	{
		camera = GameObject.Find("Main Camera");
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update ()
	{
		if (camera.transform.position.z > this.transform.position.z)
		{
			Destroy(this.gameObject);
		}
	}
	#endregion
}
