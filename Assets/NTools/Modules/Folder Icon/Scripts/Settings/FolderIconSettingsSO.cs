#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Nitou.Tools.ProjectFolder {

    [FilePath(
        "ProjectSettings/ProjectFolderSettingsSO.asset",
        FilePathAttribute.Location.ProjectFolder
    )]
    internal sealed class FolderIconSettingsSO : ScriptableSingleton<FolderIconSettingsSO> {

        /// <summary>
        /// ÉfÅ[É^Çï€ë∂Ç∑ÇÈ
        /// </summary>
        public void Save() => Save(true);
    }
}
#endif