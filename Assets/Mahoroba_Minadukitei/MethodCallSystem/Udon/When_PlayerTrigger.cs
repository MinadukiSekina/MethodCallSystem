
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Products
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
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

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            // If it is not destinated, do nothing.
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(enteredCallMethodName)) return;

            if (enteredCallIsGlobal)
            {
                // Call in global.
                otherBehaviour.SendCustomNetworkEvent(enteredCallNetworkTarget, enteredCallMethodName);
            }
            else
            {
                // Call in local.
                otherBehaviour.SendCustomEvent(enteredCallMethodName);
            }
        }

        public override void OnPlayerTriggerStay(VRCPlayerApi player)
        {
            // If it is not destinated, do nothing.
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(stayCallMethodName)) return;

            if (stayCallIsGlobal)
            {
                // Call in global.
                otherBehaviour.SendCustomNetworkEvent(stayCallNetworkTarget, stayCallMethodName);
            }
            else
            {
                // Call in local.
                otherBehaviour.SendCustomEvent(stayCallMethodName);
            }
        }

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            // If it is not destinated, do nothing.
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(exitedCallMethodName)) return;

            if (exitedCallIsGlobal)
            {
                // Call in global.
                otherBehaviour.SendCustomNetworkEvent(exitedCallNetworkTarget, exitedCallMethodName);
            }
            else
            {
                // Call in local.
                otherBehaviour.SendCustomEvent(exitedCallMethodName);
            }
        }

    }
}
