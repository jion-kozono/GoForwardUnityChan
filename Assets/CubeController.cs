using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 地面に接触する時とキューブ同士が積み重なるときはボリュームを0.1にする（追加）
        if (collision.gameObject.tag == "cubeTag" || collision.gameObject.tag == "groundTag")
        {
            audioSource.PlayOneShot(sound1);
        }
    }
}