using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>

/// </summary>
public class MyCameraController : MonoBehaviour
{
	#region Fields
	/// <summary>
	/// Unityちゃんオブジェクト
	/// </summary>
	private GameObject unitychan;

	/// <summary>
	/// Unityちゃんとの距離差
	/// </summary>
	private float difference;

	private Vector3 position;
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
		// Unityちゃん取得
		this.unitychan = GameObject.Find("unitychan");

		// Unityちゃんとカメラのｚ座標の差
		this.difference = unitychan.transform.position.z - this.transform.position.z;
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update ()
	{
		position.x = 0;
		position.y = this.transform.position.y;
		position.z = this.unitychan.transform.position.z - difference;
		this.transform.position = position;
	}
	#endregion
}
