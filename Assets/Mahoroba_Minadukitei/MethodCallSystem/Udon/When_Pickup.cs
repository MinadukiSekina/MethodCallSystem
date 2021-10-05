
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Products
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class When_Pickup : UdonSharpBehaviour
    {

        [Tooltip("処理を実行するUdon")]
        [SerializeField] private UdonBehaviour otherBehaviour;

        [Header("プレイヤーが持った時")]
        [Tooltip("チェック時、グローバルに呼び出します。")]
        [SerializeField] private bool pickedUpCallIsGlobal;
        [Tooltip("呼び出し時の通知先。pickedUpCallIsGlobalがチェック時のみ有効。")]
        [SerializeField] private VRC.Udon.Common.Interfaces.NetworkEventTarget pickedUpCallNetworkTarget;
        [Tooltip("呼び出す処理の名前を指定してください。()は不要です。")]
        [SerializeField] private string pickedUpCallMethodName;

        [Header("プレイヤーが離した時")]
        [Tooltip("チェック時、グローバルに呼び出します。")]
        [SerializeField] private bool droppedCallIsGlobal;
        [Tooltip("呼び出し時の通知先。droppedCallIsGlobalがチェック時のみ有効。")]
        [SerializeField] private VRC.Udon.Common.Interfaces.NetworkEventTarget droppedCallNetworkTarget;
        [Tooltip("呼び出す処理の名前を指定してください。()は不要です。")]
        [SerializeField] private string droppedCallMethodName;

        [Header("プレイヤーがUseで押下した時※Auto Hold指定時のみ")]
        [Tooltip("チェック時、グローバルに呼び出します。")]
        [SerializeField] private bool useDownedCallIsGlobal;
        [Tooltip("呼び出し時の通知先。useDownedCallIsGlobalがチェック時のみ有効。")]
        [SerializeField] private VRC.Udon.Common.Interfaces.NetworkEventTarget useDownedCallNetworkTarget;
        [Tooltip("呼び出す処理の名前を指定してください。()は不要です。")]
        [SerializeField] private string useDownedCallMethodName;

        [Header("プレイヤーがUse押下から戻した時※Auto Hold指定時のみ")]
        [Tooltip("チェック時、グローバルに呼び出します。")]
        [SerializeField] private bool useUppedCallIsGlobal;
        [Tooltip("呼び出し時の通知先。useUppedCallIsGlobalがチェック時のみ有効。")]
        [SerializeField] private VRC.Udon.Common.Interfaces.NetworkEventTarget useUppedCallNetworkTarget;
        [Tooltip("呼び出す処理の名前を指定してください。()は不要です。")]
        [SerializeField] private string useUppedCallMethodName;

        // Interact is not called.

        public override void OnPickup()
        {
            // If it is not destinated, do nothing.
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(pickedUpCallMethodName)) return;

            if (pickedUpCallIsGlobal)
            {
                // Call in global.
                otherBehaviour.SendCustomNetworkEvent(pickedUpCallNetworkTarget, pickedUpCallMethodName);
            }
            else
            {
                // Call in local.
                otherBehaviour.SendCustomEvent(pickedUpCallMethodName);
            }
        }

        public override void OnDrop()
        {
            // If it is not destinated, do nothing.
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(droppedCallMethodName)) return;

            if (droppedCallIsGlobal)
            {
                // Call in global.
                otherBehaviour.SendCustomNetworkEvent(droppedCallNetworkTarget, droppedCallMethodName);
            }
            else
            {
                // Call in local.
                otherBehaviour.SendCustomEvent(droppedCallMethodName);
            }
        }

        public override void OnPickupUseDown()
        {
            // If it is not destinated, do nothing.
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(useDownedCallMethodName)) return;

            if (useDownedCallIsGlobal)
            {
                // Call in global.
                otherBehaviour.SendCustomNetworkEvent(useDownedCallNetworkTarget, useDownedCallMethodName);
            }
            else
            {
                // Call in local.
                otherBehaviour.SendCustomEvent(useDownedCallMethodName);
            }
        }

        public override void OnPickupUseUp()
        {
            // If it is not destinated, do nothing.
            if (otherBehaviour == null) return;
            if (string.IsNullOrWhiteSpace(useUppedCallMethodName)) return;

            if (useUppedCallIsGlobal)
            {
                // Call in global.
                otherBehaviour.SendCustomNetworkEvent(useUppedCallNetworkTarget, useUppedCallMethodName);
            }
            else
            {
                // Call in local.
                otherBehaviour.SendCustomEvent(useUppedCallMethodName);
            }
        }
    }
}
