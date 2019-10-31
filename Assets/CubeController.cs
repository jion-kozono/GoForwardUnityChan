using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // 地面に接触する時とキューブ同士が積み重なるときはボリュームを0.1にする（追加）
        if (other.gameObject.tag == "cubTag" || other.gameObject.tag == "groundTag")
        {
            GetComponent<AudioSource>().volume = 0.1f;
        }
    }
}