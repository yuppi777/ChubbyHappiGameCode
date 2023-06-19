using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraView : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    public void MoveCamera(float y_sensi)
    {

        //float y_Rotation = Input.GetAxis("Mouse Y");

        //float maxLimit = 60, minLimit = 360 - maxLimit;


        //y_Rotation = y_Rotation * y_sensi;
        //_camera.transform.Rotate(-y_Rotation, 0, 0);


        float y_Rotation = Input.GetAxis("Mouse Y");

        float maxLimit = 60f; // 上方向の最大回転制限
        float minLimit = 300f; // 下方向の最大回転制限（360度 - 上方向の最大回転制限）

        // 現在のカメラの回転角度を取得
        Vector3 currentRotation = _camera.transform.localRotation.eulerAngles;

        // マウスのY軸移動量を感度に乗算
        y_Rotation *= y_sensi;

        // 新しい回転角度を計算
        float newRotationX = currentRotation.x - y_Rotation;

        // 上方向の制限を適用
        if (newRotationX > maxLimit && newRotationX < 180f)
        {
            newRotationX = maxLimit;
        }
        // 下方向の制限を適用
        else if (newRotationX < minLimit && newRotationX > 180f)
        {
            newRotationX = minLimit;
        }

        // カメラの回転を更新
        _camera.transform.localRotation = Quaternion.Euler(newRotationX, currentRotation.y, currentRotation.z);

    }
}
