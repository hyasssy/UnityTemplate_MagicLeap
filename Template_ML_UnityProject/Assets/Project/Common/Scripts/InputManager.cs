using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.MagicLeap;
using System;

public class InputManager : MonoBehaviour
{
    private MLInput.Controller _controller;
    public UnityEvent HomeButtonDown;
    // public UnityEvent HomeButtonEnter;
    public UnityEvent HomeButtonUp;
    public bool HomeButtonPressed { get; private set; } = false;
    public UnityEvent BumperDown;
    // public UnityEvent BumperEnter;
    public UnityEvent BumperUp;
    public bool BumperPressed { get; private set; } = false;
    public UnityEvent TriggerDown;
    // public UnityEvent TriggerEnter;
    public UnityEvent TriggerUp;
    public bool TriggerPressed { get; private set; } = false;

    void Start()
    {
        // Start input
        MLInput.Start(); //入力取得開始
        MLInput.OnControllerButtonDown += OnButtonDown; //ボタン押下に任意の関数を適用
        MLInput.OnControllerButtonUp += OnButtonUp;  //ボタンから手を離したときに任意の関数を適用
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }
    void OnDestroy()
    {
        MLInput.OnControllerButtonDown -= OnButtonDown;
        MLInput.OnControllerButtonUp -= OnButtonUp;
        MLInput.Stop();
    }
    void Update()
    {
        CheckTrigger();
        // if (BumperPressed)
        // {
        //     BumperEnter.Invoke();
        // }
        // if (HomeButtonPressed)
        // {
        //     HomeButtonEnter.Invoke();
        // }
    }

    void OnButtonUp(byte controller_id, MLInput.Controller.Button button)
    {
        // Callback - Button Up
        if (button == MLInput.Controller.Button.Bumper)
        {
            BumperUp.Invoke();
            BumperPressed = false;
        }

        if (button == MLInput.Controller.Button.HomeTap)
        {
            HomeButtonUp.Invoke();
            HomeButtonPressed = false;
        }
    }

    void OnButtonDown(byte controller_id, MLInput.Controller.Button button)
    {
        // Callback - Button Down
        if (button == MLInput.Controller.Button.Bumper)
        {
            BumperDown.Invoke();
            BumperPressed = true;
        }

        if (button == MLInput.Controller.Button.HomeTap)
        {
            HomeButtonDown.Invoke();
            HomeButtonPressed = true;
        }
    }
    void CheckTrigger()
    {
        if (_controller == null)
        {
            return;
        }
        //トリガーの閾値はとりあえず0.5で設定。
        if (_controller.TriggerValue > 0.5f)
        {
            if (!TriggerPressed)
            {
                TriggerDown.Invoke();
                TriggerPressed = true;
            }
            // else
            // {
            //     TriggerEnter.Invoke();
            // }
        }
        else
        {
            if (TriggerPressed)
            {
                TriggerUp.Invoke();
                TriggerPressed = false;
            }
        }
    }
}
