using UnityEngine;

namespace Nitou.Tools.Hierarchy {

    /// <summary>
    /// ヒエラルキーにヘッダーを描画するコンポーネント．
    /// </summary>
    [AddComponentMenu("Nitou/Hierarchy Header")]
    public sealed class HierarchyHeader : HierarchyObject {

#if UNITY_EDITOR

        /// <summary>
        /// Color of the Hierarchy displayed in the Inspector.
        /// </summary>
        [ColorUsage(false)]
        [SerializeField] Color _menuColor = Color.white;
#endif
    }

}