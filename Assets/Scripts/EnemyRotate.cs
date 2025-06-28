using System.Xml.Schema;
using UnityEngine;
using UnityEngine.LowLevel;
using static UnityEngine.GraphicsBuffer;

public class EnemyRotate : MonoBehaviour
{
	[SerializeField] private Player player_ = null;
	[SerializeField] private Enemy Enemy = null;
	[SerializeField] private float MaxRotate = 20.0f;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Enemy.playerbool == false) { return; }
		//vector取得
		var target = (player_.transform.position - transform.position).normalized;
		//正面の単位べく
		var forward = transform.forward;
		// 単位ベクトル同士の内積で cos を求める
		var dot = Vector3.Dot(forward, target);
		if (0.999f < dot) { return; }
		//cosからラジアン取得
		var radian = Mathf.Acos(dot);
		if(radian==0) { return; }
		//ラジアンの制限
		var rota = Mathf.Deg2Rad * MaxRotate;
		if(radian > rota)
		{
			radian = rota;
		}
		var cross = Vector3.Cross(forward, target);
		//絶対値で向きの正負をとる
		radian *= (cross.y / Mathf.Abs(cross.y));
		//弧度法から度数法に変換し反映
		transform.rotation *= Quaternion.Euler(0, Mathf.Rad2Deg * radian, 0);
	}
}
