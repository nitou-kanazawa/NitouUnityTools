using Nitou.IO;

namespace Nitou.Tools.Shared {

    /// <summary>
    /// UPMパッケージの各種設定を管理する静的クラス．
    /// </summary>
    public static class PackageInfo {

        /// <summary>
        /// パッケージ名．
        /// </summary>
        public static readonly string PackageName = "com.nitou.ntools";

        /// <summary>
        /// パッケージのディレクトリパス．
        /// </summary>
        public static readonly PackageDirectoryPath PackagePath = null;

        /// <summary>
        /// ProjectSettingsのメニューパス．
        /// </summary>
        public static readonly string ProjectSettingsMenuPath = "Project/Nitou Tools/";

        /// <summary>
        /// Preferenceのメニューパス．
        /// </summary>
        public static readonly string PreferenceMenuPath = "Preference/Nitou Tools/";

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        static PackageInfo() {
            PackagePath = new PackageDirectoryPath(PackageName, "NTools");
        }
    }
}
