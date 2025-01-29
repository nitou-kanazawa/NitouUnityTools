#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using Nitou.IO;

namespace Nitou.Tools.ProjectFolder {

    [InitializeOnLoad]
    internal sealed class CustomFolder {

        /// <summary>
        /// �R���X�g���N�^�i�ÓI�j�D
        /// </summary>
        static CustomFolder() {

            EditorApplication.projectWindowItemOnGUI -= DrawFolderIcon;
            EditorApplication.projectWindowItemOnGUI += DrawFolderIcon;
        }


        /// --------------------------------------------------------------------
        // Private Method

        private static void DrawFolderIcon(string guid, Rect rect) {

            if (Event.current.type != EventType.Repaint) return;

            // �p�X�`�F�b�N
            var path = AssetDatabase.GUIDToAssetPath(guid);
            if (string.IsNullOrEmpty(path)) return;
            if (!PathUtils.IsDirectory(path)) return;

            var fileName = PathUtils.GetFileName(path);


            /*
            // Icon�摜�̎擾
            (bool isExist, Texture texture) = IconDictionaryCreator.GetIconTexture(fileName);
            if (!isExist ||texture == null) {
                return;
            }

            // Icon�摜�̔��f
            Rect imageRect;
            if (rect.height > 20) {
                imageRect = new Rect(rect.x - 1, rect.y - 1, rect.width + 2, rect.width + 2);
            } else if (rect.x > 20) {
                imageRect = new Rect(rect.x - 1, rect.y - 1, rect.height + 2, rect.height + 2);
            } else {
                imageRect = new Rect(rect.x + 2, rect.y - 1, rect.height + 2, rect.height + 2);
            }                      
            GUI.DrawTexture(imageRect, texture); 
            */
        }

    }
}
#endif