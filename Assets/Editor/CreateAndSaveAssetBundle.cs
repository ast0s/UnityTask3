using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateAndSaveAssetBundle
{
    public static string assetBundleDir = "Assets/AssetBundles/";

    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAssetBundles()
    {
        if (Directory.Exists(assetBundleDir))
        {
            Directory.Delete(assetBundleDir, true);
        }

        Directory.CreateDirectory(assetBundleDir);

        BuildPipeline.BuildAssetBundles(assetBundleDir, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows);
        AppendPlatformToFileName("Windows");
        Debug.Log("Windows bundle created");

        RemoveSpacesInFileNames();

        AssetDatabase.Refresh();
        Debug.Log("Proccess complete!");
    }

    static void RemoveSpacesInFileNames()
    {
        foreach (string path in Directory.GetFiles(assetBundleDir))
        {
            string oldName = path;
            string newName = path.Replace(' ', '-');

            File.Move(oldName, newName);
        }
    }

    static void AppendPlatformToFileName(string platform)
    {
        foreach (string path in Directory.GetFiles(assetBundleDir))
        {
            string[] files = path.Split('/');
            string fileName = files[files.Length - 1];

            if (fileName.Contains(".") || fileName.Contains("Bundle"))
            {
                File.Delete(path);
            }
            else if (!fileName.Contains("-"))
            {
                FileInfo info = new FileInfo(path);
                info.MoveTo(path + "-" + platform);
            }
        }
    }
}
