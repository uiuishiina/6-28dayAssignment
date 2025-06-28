using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyRotate : MonoBehaviour
{
	[SerializeField] private Player player_ = null;
	[SerializeField] private Enemy Enemy = null;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Enemy.playertransform == null) { return; }
		//vector取得
		var target = (Enemy.playertransform.position - transform.position);
		//正面の単位べく
		var fowerd = transform.forward;
		// 単位ベクトル同士の内積で cos を求める
		var dot = Vector3.Dot(fowerd, target);
		if (0.999f < dot) { return; }
		//cos取得
		var radian = Mathf.Acos(dot);

		var cross = Vector3.Cross(fowerd, target);
		//絶対値で向きの正負をとる
		radian *= (cross.y / Mathf.Abs(cross.y));

		var rota = Quaternion.Euler(0, Mathf.Rad2Deg * radian, 0);
		transform.rotation *= rota;
	}
}
