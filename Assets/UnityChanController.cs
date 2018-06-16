﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>

/// </summary>
public class UnityChanController : MonoBehaviour
{
	#region Fields
	/// <summary>
	/// アニメーションコンポ―ネント
	/// </summary>
	private Animator myAnimator;

	/// <summary>
	/// Unityちゃん移動用コンポーネント
	/// </summary>
	private Rigidbody myRigidbody;

	/// <summary>
	/// 前進力
	/// </summary>
	private float forwardForce = 300f;

	/// <summary>
	/// 横の移動力
	/// </summary>
	private float turnForce = 300f;

	/// <summary>
	/// 左右の移動可能範囲
	/// </summary>
	private float movableRange = 3.4f;

	/// <summary>
	/// ジャンプ力
	/// </summary>
	private float upForce = 30.0f;
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
	void Start()
	{
		this.myAnimator = GetComponent<Animator>();
		this.myAnimator.SetFloat("Speed", 1);
		this.myRigidbody = GetComponent<Rigidbody>();
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// 前進
		this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);

		// 左右移動
		if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
		{
			this.myRigidbody.AddForce(-this.turnForce, 0, 0);
		}
		else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
		{
			this.myRigidbody.AddForce(this.turnForce, 0, 0);
		}

		// ジャンプ
		if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
		{
			this.myAnimator.SetBool("Jump", false);
		}
		if(Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
		{
			this.myAnimator.SetBool("Jump", true);
			this.myRigidbody.AddForce(this.transform.up * this.upForce);
		}
	}
	#endregion
}
