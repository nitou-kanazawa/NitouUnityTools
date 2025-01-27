using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

// [参考]
//  qiita: C#(Unity)でのファイルパスの取得 https://qiita.com/oishihiroaki/items/1a082f3bb32f2e3d88a0
//  はなちる: 絶対パスをAssets/~に変換する https://www.hanachiru-blog.com/entry/2018/10/12/204022
//  _ : フルパスをAssetsパスに変換する方法 https://mizutanikirin.net/unity-assetspath

namespace Nitou.IO {

    public enum Delimiter {
        Slash,
        BackSlash,
    }

    /// <summary>
    /// パス取得に関する汎用メソッド集．
    /// パスの区切り文字は「\\」ではなく「/」を使用する．
    /// </summary>
    public static partial class PathUtils {

        /// --------------------------------------------------------------------
        #region パスの結合

        /// <summary>
        /// path1とpath2を結合したパスを生成する．
        /// </summary>
        public static string Combine(string path1, string path2) {
            return Path.Combine(path1, path2)
                .ReplaceDelimiter();
        }

        /// <summary>
        /// path1~path3を結合したパスを生成する．
        /// </summary>
        public static string Combine(string path1, string path2, string path3) {
            return Path.Combine(path1, path2, path3)
                .ReplaceDelimiter();
        }

        /// <summary>
        /// path1~path4を結合したパスを生成する．
        /// </summary>
        public static string Combine(string path1, string path2, string path3, string path4) {
            return Path.Combine(path1, path2, path3, path4)
                .ReplaceDelimiter();
        }

        /// <summary>
        ///paths全てを結合したパスを生成
        /// </summary>
        public static string Combine(params string[] paths) {
            return Path.Combine(paths)
                .ReplaceDelimiter();
        }
        #endregion


        /// --------------------------------------------------------------------
        // パスの加工

        /// <summary>
        /// 拡張子を変更する．
        /// </summary>
        public static string ChangeExtension(string path, string extension) {
            return Path.ChangeExtension(path, extension)
                .ReplaceDelimiter();
        }

        /// <summary>
        /// 相対パスから絶対パスを取得
        /// </summary>
        public static string GetFullPath(string path) {
            return Path.GetFullPath(path)
                .ReplaceDelimiter();
        }


        /// --------------------------------------------------------------------
        // 取得

        /// <summary>
        /// ディレクトリの名前を取得する．
        /// </summary>
        public static string GetDirectoryName(string path) {
            return Path.GetDirectoryName(path)
                .ReplaceDelimiter();
        }

        /// <summary>
        /// ファイルパスからファイル名を取得する
        /// </summary>
        public static string GetFileName(string path) {
            return Path.GetFileName(path)
                .ReplaceDelimiter();
        }

        /// <summary>
        /// 拡張子なしのファイル名を取得
        /// </summary>
        public static string GetFileNameWithoutExtension(string path) {
            return Path.GetFileNameWithoutExtension(path)
                .ReplaceDelimiter();
        }

        /// <summary>
        /// ファイルパスから拡張子を取得する
        /// </summary>
        public static string GetExtension(string path) {
            return Path.GetExtension(path)
                .ReplaceDelimiter();
        }
               

        /// <summary>
        /// 指定したフォルダ内の全ファイルパスを取得する
        /// </summary>
        public static string[] GetFilesInFolder(string folderPath) {
            return Directory.GetFiles(folderPath, "*");
        }



        /// <summary>
        /// ファイル名に使用できない文字を全て取得する．
        /// </summary>
        public static char[] GetInvalidFileNameChars() {
            return Path.GetInvalidFileNameChars();
        }

        /// <summary>
        /// パスに使用できない文字を全て取得する．
        /// </summary>
        public static char[] GetInvalidPathChars() {
            return Path.GetInvalidPathChars();
        }


        /// <summary>
        /// 指定のパスからルートへのパスだけを取得
        /// </summary>
        public static string GetPathRoot(string path) {
            return Path.GetPathRoot(path)
                .ReplaceDelimiter();
        }


        /// --------------------------------------------------------------------
        // パスの判定

        /// <summary>
        /// 拡張子が付いているか確認する．
        /// </summary>
        public static bool HasExtension(string path) {
            return Path.HasExtension(path);
        }

        /// <summary>
        /// ルートパスか確認する．
        /// </summary>
        public static bool IsPathRooted(string path) {
            return Path.IsPathRooted(path);
        }


        /// --------------------------------------------------------------------
        #region 呼び出し元の取得

        // [REF]
        //  kanのメモ帳: 移動する可能性のある任意のアセットやディレクトリ(フォルダ)のパスを取得する方法 https://kan-kikuchi.hatenablog.com/entry/Get_Path_May_Move
        //  MSDoq: CallerFilePathAttributeクラス https://learn.microsoft.com/ja-jp/dotnet/api/system.runtime.compilerservices.callerfilepathattribute?view=netframework-4.8

        /// <summary>
        /// 呼び出し元のパスを取得
        /// </summary>
        public static string GetSelfPath([CallerFilePath] string sourceFilePath = "") {
            return ReplaceDelimiter(sourceFilePath);
        }

        /// <summary>
        /// 呼び出し元のパス(Assetsから)を取得
        /// </summary>
        public static string GetSelfPathFromAssets([CallerFilePath] string sourceFilePath = "") {
            return (new Uri(Application.dataPath))
                .MakeRelativeUri(new Uri(sourceFilePath))
                .ToString();
        }
        #endregion 


        /// --------------------------------------------------------------------
        // その他

        /// <summary>
        /// ランダムなファイル名を取得
        /// </summary>
        /// <returns></returns>
        public static string GetRandomFileName() {
            return Path.GetRandomFileName()
                .ReplaceDelimiter();
        }

        /// <summary>
        /// 一時ファイルのパスをランダムに作成
        /// </summary>
        public static string GetTempFileName() {
            return Path.GetTempFileName()
                .ReplaceDelimiter();
        }

        /// <summary>
        /// 一時ファイルがあるディレクトリへのパスを取得
        /// </summary>
        public static string GetTempPath() {
            return Path.GetTempPath()
                .ReplaceDelimiter();
        }


        /// <summary>
        /// Windows で使われることがある区切り文字"\"をMacやUnity用の区切り文字"/"に置き換える．
        /// </summary>
        public static string ReplaceDelimiter(this string path) {
            return path.Replace("\\", "/");
        }



        /// --------------------------------------------------------------------
        #region パスの変換（string拡張メソッド）

        /// <summary>
        /// フルパスをアセット以下パス(Assets/..)に変換する
        /// </summary>
        public static string ToAssetsPath(this string fullPath) {
            // "Assets/"位置を取得
            int startIndex = fullPath.IndexOf("Assets/", System.StringComparison.Ordinal);
            if (startIndex == -1) {
                startIndex = fullPath.IndexOf("Assets\\", System.StringComparison.Ordinal);
            }

            // ※含まれない場合は，空文字を返す
            if (startIndex == -1) return "";

            // 加工後パスを返す
            string assetPath = fullPath.Substring(startIndex);
            return assetPath;
        }


        #endregion


        /// --------------------------------------------------------------------
        // Private Method

        public static string GetParentDirectory(string filepath, int n = 1) {
            string dir = filepath;
            for (int i = 0; i < n; i++) {
                dir = Directory.GetParent(dir).FullName;
            }
            return dir.ToAssetsPath();
        }

    }
}