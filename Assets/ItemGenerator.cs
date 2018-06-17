using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>

/// </summary>
public class ItemGenerator : MonoBehaviour
{
	#region Fields
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

	/// <summary>
	/// プレイヤープレハブ
	/// </summary>
	private GameObject playerPrefab;

	/// <summary>
	/// レーンの最終位置保存
	/// </summary>
	private GameObject prevLanes = null;

	/// <summary>
	/// 障害物作成最大距離差
	/// </summary>
	private readonly float createLimitDistance = 45.0f;

	/// <summary>
	/// 難易度
	/// </summary>
	Difficulty mode;

	/// <summary>
	/// 難易度と生成頻度のテーブル
	/// </summary>
	private Dictionary<Difficulty, int> difficulty = new Dictionary<Difficulty, int>
	{
		{Difficulty.Easy,       1},
		{Difficulty.Normal,     4},
		{Difficulty.Hard,       7},
		{Difficulty.Lunatic,    10},
	};
	#endregion

	#region Properties
	#endregion

	#region Enums
	public enum Difficulty
	{
		Easy,
		Normal,
		Hard,
		Lunatic,
	}
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
		this.playerPrefab = GameObject.Find("unitychan");
		this.mode = (Difficulty)Random.Range((int)Difficulty.Easy, (int)Difficulty.Lunatic);
		Debug.Log(mode.ToString());
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		var distance = System.Math.Abs(this.goalPos - playerPrefab.transform.position.z);
		bool isCreate = Random.Range(0, 100) < difficulty[mode] && distance > createLimitDistance
			? true
			: false;

		if (isCreate && !playerPrefab.GetComponent<UnityChanController>().IsEnd)
		{
			if (Random.Range(0, 20) <= 1)
			{
				CreateObstacleLane(ConePrefab);
			}
			else
			{
				int item = Random.Range(1, 11);     // アイテム種ランダム生成
				if (1 <= item && item <= 6)
				{
					CreateItem(CoinPrefab);
				}
				if (7 <= item && item <= 9)
				{
					CreateItem(CarPrefab);
				}
			}
		}
	}

	/// <summary>
	/// アイテムレーン作成
	/// </summary>
	/// <param name="itemPrefab">アイテムプレハブ</param>
	private void CreateObstacleLane(GameObject itemPrefab)
	{
		var zPosition = playerPrefab.transform.position.z + Random.Range(-5.0f, 5.0f) + createLimitDistance;
		var laneDistance = this.prevLanes == null
			? Random.Range(1, 3 * difficulty[mode])
			: System.Math.Abs(this.prevLanes.transform.position.z - zPosition);

		if (laneDistance > 20.0f / difficulty[mode])
		{
			for (float j = -1; j <= 1; j += 0.4f)
			{
				// コーンをx軸方向に一直線に生成
				var cone = Instantiate(itemPrefab) as GameObject;
				cone.transform.position = new Vector3(4 * j, cone.transform.position.y, zPosition);
				this.prevLanes = cone;
			}
		}
	}

	/// <summary>
	/// アイテム作成
	/// </summary>
	/// <param name="itemPrefab">アイテムプレハブ</param>
	private void CreateItem(GameObject itemPrefab)
	{
		var obstacle = Instantiate(itemPrefab) as GameObject;
		var zRandomOffset = playerPrefab.transform.position.z + createLimitDistance + Random.Range(-5.0f, 5.0f);
		obstacle.transform.position = new Vector3(xPosRange * Random.Range(-1, 2), obstacle.transform.position.y, zRandomOffset);
	}
	#endregion
}
