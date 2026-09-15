using UnityEngine;

// <summary>
// カメラでプレイヤーを追従するスクリプト
public class CameraFollowing : MonoBehaviour
{
    public Transform target;//追従する目標
    public Vector3 offset = new Vector3(0f,2.5f,-20f);//カメラの位置のオフセット
    public float followSpeed = 5f;//カメラの追従速度

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;//カメラの現在位置を計算
        //カメラを少しずつ近づける
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition, 
            followSpeed * Time.deltaTime);
    }
}
