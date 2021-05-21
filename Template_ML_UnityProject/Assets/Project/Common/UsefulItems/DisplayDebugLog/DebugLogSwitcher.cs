using UnityEngine;

public class DebugLogSwitcher : MonoBehaviour
{
    [SerializeField, Tooltip("このキーを3秒長押しすると表示非表示切り替える")]
    KeyCode switchKey = KeyCode.C;//default : C of Console
    GameObject _debugLogPanel;
    [SerializeField]
    float pushDownDuration = 2.5f;
    float _timeCount = 0f;
    InputManager _InputManager;
    public void Start()
    {
        _debugLogPanel = transform.GetChild(0).gameObject; //子にはpanelしかない想定。
        _InputManager = FindObjectOfType<InputManager>();
    }
    private void Update()
    {
        if (GetInput())
        {
            _timeCount += Time.deltaTime;
            if (_timeCount >= pushDownDuration)
            {
                _debugLogPanel.SetActive(!_debugLogPanel.activeSelf);
                if (_debugLogPanel.activeSelf) Debug.Log("Activate Debug Log View");
                _timeCount = 0f;
            }
        }
        else
        {
            _timeCount = 0f;
        }
    }
    bool GetInput()
    {
        if (Input.GetKey(switchKey))
        {
            return true;
        }
        else
        {
            //バンパーボタン、トリガーを同時に長押しでパネル表示/非表示
            if (_InputManager.BumperPressed && _InputManager.TriggerPressed)
            {
                return true;
            }
        }
        return false;
    }
}
