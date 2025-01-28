using System;

namespace Nitou.IO {

    public interface IUnityProjectPath {

        public string RootFolder { get; }



        public bool IsAssetsPath => RootFolder == "Assets";
        public bool IsPackagesPath => RootFolder == "Packages";
    }
}
