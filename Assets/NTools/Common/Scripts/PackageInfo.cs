using Nitou.IO;

namespace Nitou.Tools.Shared{

    /// <summary>
    /// UPMパッケージの各種設定を管理する静的クラス．
    /// </summary>
    internal static class PackageInfo{

        /// <summary>
        /// パッケージ名．
        /// </summary>
        internal static readonly string PackageName = "com.nitou.ntools";

        /// <summary>
        /// パッケージのディレクトリパス．
        /// </summary>
        internal static readonly PackageDirectoryPath PackagePath = null;

        /// <summary>
        /// ProjectSettingsのメニューパス．
        /// </summary>
        internal static readonly string SettingsMenuPath = "Project/Nitou Tools/";

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        static PackageInfo() {
            PackagePath = new PackageDirectoryPath(PackageName, "NTools");
        }
    }
}
