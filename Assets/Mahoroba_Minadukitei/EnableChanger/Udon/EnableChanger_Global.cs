
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Products
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class EnableChanger_Global : UdonSharpBehaviour
    {
        [SerializeField] private GameObject[] targetObjects;
        [UdonSynced(UdonSyncMode.None), FieldChangeCallback(nameof(TargetEnables))] private bool[] targetEnables;
        // For stopping OnValueChanged during Start().
        private bool initialized = false;

        public bool[] TargetEnables
        {
            get => targetEnables;
            set
            {
                targetEnables = value;
                SetEnable();
            }
        }

        void Start()
        {
            // Initialize
            TargetEnables = new bool[targetObjects.Length];
            for(int i = 0; i < TargetEnables.Length; i++)
            {
                if (targetObjects[i] == null) continue;
                TargetEnables[i] = targetObjects[i].activeSelf;
            }
            initialized = true;
        }

        public void SetEnable()
        {
            if (!initialized) return;
            for (int i = 0; i < TargetEnables.Length; i++)
            {
                if (targetObjects[i] == null) continue;
                targetObjects[i].SetActive(TargetEnables[i]);
            }
        }

        public void ChangeEnableGlobal()
        {
            for (int i = 0; i < TargetEnables.Length; i++)
            {
                TargetEnables[i] = !TargetEnables[i];
            }
            SetEnable();
            RequestSerialization();
        }
    }
}
