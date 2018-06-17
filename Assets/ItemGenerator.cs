using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>

/// </summary>
public class ItemGenerator : MonoBehaviour
{
	#region Fields
	/// <summary>
	/// スタート地点
	/// </summary>
	private int startPos = -160;

	/// <summary>
	/// ゴール地点
	/// </summary>
	private int goalPos = 120;

	/// <summary>
	/// アイテム出現範囲(x軸)
	/// </summary>
	private float xPosRange = 3.4f;

	/// <summary>
	/// 車プレハブ
	/// </summary>
	public GameObject CarPrefab;

	/// <summary>
	/// コインプレハブ
	/// </summary>
	public GameObject CoinPrefab;

	/// <summary>
	/// コーンプレハブ
	/// </summary>
	public GameObject ConePrefab;
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
		// 一定距離ごとにアイテム生成
		for (int i = startPos; i < goalPos; i += 15)
		{
			// 出現アイテム ランダム生成
			int num = Random.Range(0, 10);
			if (num <= 1)
			{
				for (float j = -1; j <= 1; j += 0.4f)
				{
					// コーンをx軸方向に一直線に生成
					var cone = Instantiate(ConePrefab) as GameObject;
					cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
				}
			}
			else
			{
				for (int j = -1; j < 2; j++)
				{
					int item = Random.Range(1, 11);     // アイテム種ランダム生成
					int zOffset = Random.Range(-5, 6);  // アイテム配置位置をZ軸座標のオフセット

					// コイン60% コイン30% 何もなし10%
					if (1 <= item && item <= 6)
					{
						var coin = Instantiate(CoinPrefab) as GameObject;
						coin.transform.position = new Vector3(xPosRange * j, coin.transform.position.y, i + zOffset);
					}
					if (7 <= item && item <= 9)
					{
						var car = Instantiate(CarPrefab) as GameObject;
						car.transform.position = new Vector3(xPosRange * j, car.transform.position.y, i + zOffset);
					}
				}
			}
		}
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{

	}
	#endregion
}
