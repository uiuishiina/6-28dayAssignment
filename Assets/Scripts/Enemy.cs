using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    /// <summary>  
    /// プレイヤー  
    /// </summary>  
    [SerializeField] private Player player_ = null;
	[SerializeField] private float viewRadian = 30.0f;
	public bool playerbool { get; private set; } = false;
	/// <summary>  
	/// ワールド行列   
	/// </summary>  
	private Matrix4x4 worldMatrix_ = Matrix4x4.identity;

    /// <summary>  
    /// ターゲットとして設定する  
    /// </summary>  
    /// <param name="enable">true:設定する / false:解除する</param>  
    public void SetTarget(bool enable)
    {
        // マテリアルの色を変更する  
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.materials[0].color = enable ? Color.red : Color.white;
    }

	/// <summary>
	/// 開始処理
	/// </summary>
	public void Start()
    {
    }

    /// <summary>  
    /// 更新処理  
    /// </summary>  
    public void Update()
    {
		//var normalZ = new Vector3(0, 0, 1);
		//var enemyForward = transform.forward;
		//var enemyForward = worldMatrix_ * normalZ;
		var enemyForward = transform.forward;
		// エネミーの視野角の Cos 値
		var enemyViewCos = Mathf.Cos(viewRadian);

		// ターゲット可能な敵の一覧を更新する
		// 敵からプレイヤーまでの向きを単位ベクトルで取得する
		var playerToEnemy = (player_.transform.position - transform.position).normalized;

		// 内積を取得する
		var dot = Vector3.Dot(enemyForward, playerToEnemy);

		// 内積の結果がプレイヤーの視野角より大きい場合はターゲット出来る
		if (enemyViewCos <= dot)
		{
			playerbool = true;
		}
		else
		{
			playerbool = false;
		
		}
		EnemyMove();
	}
	void EnemyMove()
	{

	}
}
