
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Minadukitei.Products
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class EnableChanger_Local : UdonSharpBehaviour
    {
        [SerializeField] private GameObject[] targetObjects;
        
        public void ChangeEnableLocal()
        {
            foreach(GameObject targetObject in targetObjects)
            {
                if (targetObject == null) continue;
                targetObject.SetActive(!targetObject.activeSelf);
            }
        }
    }
}
