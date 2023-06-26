using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UraCommand : MonoBehaviour
{

    [SerializeField]
    private CusLook cusLook;

    private void Start()
    {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetKeyDown(KeyCode.Alpha0))
                  .Subscribe(value =>
                  {

                     SceneManagement.Instance.SceneChange("Start");
                      cusLook.AnLookCus();

                  })
                  .AddTo(this);
           



    }


}
