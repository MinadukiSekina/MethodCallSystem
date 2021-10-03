
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Products
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class When_PlayerTrigger : UdonSharpBehaviour
    {
        [Tooltip("処理を実行するUdon")]
        [SerializeField] private UdonBehaviour otherBehaviour;

        [Header("プレイヤーが範囲内に入った時")]
        [Tooltip("チェック時、グローバルに呼び出します。")]
        [SerializeField] private bool enteredCallIsGlobal;
        [Tooltip("呼び出し時の通知先。enteredCallIsGlobalがチェック時のみ有効。")]
        [SerializeField] private VRC.Udon.Common.Interfaces.NetworkEventTarget enteredCallNetworkTarget;
        [Tooltip("呼び出す処理の名前を指定してください。()は不要です。")]
        [SerializeField] private string enteredCallMethodName;
        
        [Header("プレイヤーが範囲内に居る時")]
        [Tooltip("チェック時、グローバルに呼び出します。")]
        [SerializeField] private bool stayCallIsGlobal;
        [Tooltip("呼び出し時の通知先。stayCallIsGlobalがチェック時のみ有効。")]
        [SerializeField] private VRC.Udon.Common.Interfaces.NetworkEventTarget stayCallNetworkTarget;
        [Tooltip("呼び出す処理の名前を指定してください。()は不要です。")]
        [SerializeField] private string stayCallMethodName;
        
        [Header("プレイヤーが範囲内から出た時")]
        [Tooltip("チェック時、グローバルに呼び出します。")]
        [SerializeField] private bool exitedCallIsGlobal;
        [Tooltip("呼び出し時の通知先。exitedCallIsGlobalがチェック時のみ有効。")]
        [SerializeField] private VRC.Udon.Common.Interfaces.NetworkEventTarget exitedCallNetworkTarget;
        [Tooltip("呼び出す処理の名前を指定してください。()は不要です。")]
        [SerializeField] private string exitedCallMethodName;

        [Tooltip("各イベントで受け取っているPlayerAPI")]
        [HideInInspector] public VRCPlayerApi eventPlayer;

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            // 指定が無ければ処理しない
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(enteredCallMethodName)) return;

            // PlayerAPIの格納
            eventPlayer = player;

            if (enteredCallIsGlobal)
            {
                // グローバルで呼び出し
                otherBehaviour.SendCustomNetworkEvent(enteredCallNetworkTarget, enteredCallMethodName);
            }
            else
            {
                // ローカルで呼び出し
                otherBehaviour.SendCustomEvent(enteredCallMethodName);
            }
        }

        public override void OnPlayerTriggerStay(VRCPlayerApi player)
        {
            // 指定が無ければ処理しない
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(stayCallMethodName)) return;

            // PlayerAPIの格納
            eventPlayer = player;

            if (stayCallIsGlobal)
            {
                // グローバルで呼び出し
                otherBehaviour.SendCustomNetworkEvent(stayCallNetworkTarget, stayCallMethodName);
            }
            else
            {
                // ローカルで呼び出し
                otherBehaviour.SendCustomEvent(stayCallMethodName);
            }
        }

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            // 指定が無ければ処理しない
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(exitedCallMethodName)) return;

            // PlayerAPIの格納
            eventPlayer = player;

            if (exitedCallIsGlobal)
            {
                // グローバルで呼び出し
                otherBehaviour.SendCustomNetworkEvent(exitedCallNetworkTarget, exitedCallMethodName);
            }
            else
            {
                // ローカルで呼び出し
                otherBehaviour.SendCustomEvent(exitedCallMethodName);
            }
        }

    }
}
