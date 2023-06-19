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

        float maxLimit = 60f; // ������̍ő��]����
        float minLimit = 300f; // �������̍ő��]�����i360�x - ������̍ő��]�����j

        // ���݂̃J�����̉�]�p�x���擾
        Vector3 currentRotation = _camera.transform.localRotation.eulerAngles;

        // �}�E�X��Y���ړ��ʂ����x�ɏ�Z
        y_Rotation *= y_sensi;

        // �V������]�p�x���v�Z
        float newRotationX = currentRotation.x - y_Rotation;

        // ������̐�����K�p
        if (newRotationX > maxLimit && newRotationX < 180f)
        {
            newRotationX = maxLimit;
        }
        // �������̐�����K�p
        else if (newRotationX < minLimit && newRotationX > 180f)
        {
            newRotationX = minLimit;
        }

        // �J�����̉�]���X�V
        _camera.transform.localRotation = Quaternion.Euler(newRotationX, currentRotation.y, currentRotation.z);

    }
}
