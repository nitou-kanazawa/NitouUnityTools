#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

// [REF]
//  qiita: Unityで独自の設定のUIを提供できるSettingsProviderの紹介と設定ファイルの保存について https://qiita.com/sune2/items/a88cdee6e9a86652137c


namespace Nitou.Tools.ProjectFolder {

    public sealed class FolderIconSettingsProvider : SettingsProvider {

        private SerializedObject _settings;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public FolderIconSettingsProvider(string path, SettingsScope scopes) : base(path, scopes) {

        }

        /// <summary>
        /// アクティブ時の処理．
        /// </summary>
        public override void OnActivate(string searchContext, VisualElement rootElement) {

            var instance = FolderIconSettingsSO.instance;

            // ※ScriptableSingletonを編集可能にする
            instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            _settings = new SerializedObject(instance);
        }

        /// <summary>
        /// GUI描画．
        /// </summary>
        public override void OnGUI(string searchContext) {

            using (new EditorGUILayout.HorizontalScope()) {
                GUILayout.Space(10f);
                using (new EditorGUILayout.VerticalScope()) {

                    using (var changeCheck = new EditorGUI.ChangeCheckScope()) {

                        // Behaviour
                        EditorGUILayout.LabelField("Behaviour", EditorStyles.boldLabel);
                        //EditorGUILayout.PropertyField(_settings.FindProperty("hierarchyObjectMode"));

                        EditorGUILayout.Space();

                        // Drawer
                        //EditorGUILayout.LabelField("Drawer", EditorStyles.boldLabel);
                        //EditorGUILayout.PropertyField(_settings.FindProperty("showHierarchyToggles"), new GUIContent("Show Toggles"));
                        //EditorGUILayout.PropertyField(_settings.FindProperty("showComponentIcons"));
                        //var showTreeMap = _settings.FindProperty("showTreeMap");
                        //EditorGUILayout.PropertyField(showTreeMap);
                        //if (showTreeMap.boolValue) {
                        //    EditorGUI.indentLevel++;
                        //    EditorGUILayout.PropertyField(_settings.FindProperty("treeMapColor"), new GUIContent("Color"));
                        //    EditorGUI.indentLevel--;
                        //}

                        // Details
                        //var showSeparator = _settings.FindProperty("showSeparator");
                        //EditorGUILayout.PropertyField(showSeparator, new GUIContent("Show Row Separator"));
                        //if (showSeparator.boolValue) {
                        //    EditorGUI.indentLevel++;
                        //    EditorGUILayout.PropertyField(_settings.FindProperty("separatorColor"), new GUIContent("Color"));
                        //    EditorGUI.indentLevel--;
                        //    var showRowShading = _settings.FindProperty("showRowShading");
                        //    EditorGUILayout.PropertyField(showRowShading);
                        //    if (showRowShading.boolValue) {
                        //        EditorGUI.indentLevel++;
                        //        EditorGUILayout.PropertyField(_settings.FindProperty("evenRowColor"));
                        //        EditorGUILayout.PropertyField(_settings.FindProperty("oddRowColor"));
                        //        EditorGUI.indentLevel--;
                        //    }
                        //}

                        if (changeCheck.changed) {
                            _settings.ApplyModifiedProperties();
                            FolderIconSettingsSO.instance.Save();
                        }
                    }
                }
            }

        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private void Draw() {

        }


        /// ----------------------------------------------------------------------------
        #region Static

        /// <summary>
        /// 独自のSettingsProviderを返すことで、設定項目を追加する．
        /// </summary>
        [SettingsProvider]
        public static SettingsProvider CreateSettingProvider() {

            // 第三引数のkeywordsは、検索時にこの設定項目を引っかけるためのキーワード
            return new FolderIconSettingsProvider(ModuleInfo.SettingsMenuPath, SettingsScope.Project) {
                label = "Folder Icons",
                keywords = new HashSet<string>(new[] { "Nitou, Tool, Project, Icon" })
            };
        }

        #endregion
    }
}
#endif