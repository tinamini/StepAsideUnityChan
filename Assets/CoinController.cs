using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>

/// </summary>
public class CoinController : MonoBehaviour
{
	#region Fields
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
		// 回転開始角度設定
		this.transform.Rotate(0, Random.Range(0, 360), 0);
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update ()
	{
		// 回転
		this.transform.Rotate(0, 3, 0);
	}
	#endregion
}
