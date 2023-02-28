using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class API : MonoBehaviour
{

    const string BundleFolder = "ftp://epiz_33691855:sb6rjg5p@ftp.epizy.com/htdocs/AssetBundles/";

    public void GetBundleObject(string assetName, UnityAction<GameObject> callback, Transform bundleParent)
    {
        StartCoroutine(GetDisplayBundleRoutine(assetName, callback, bundleParent));
    }

    IEnumerator GetDisplayBundleRoutine(string assetName, UnityAction<GameObject> callback, Transform bundleParent)
    {

        string bundleURL = BundleFolder + assetName + "-";

        bundleURL += "Windows";

        Debug.Log("Requesting bundle at " + bundleURL);

        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log("Network error");
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            if (bundle != null)
            {
                string rootAssetPath = bundle.GetAllAssetNames()[0];
                GameObject _object = Instantiate(bundle.LoadAsset(rootAssetPath) as GameObject, bundleParent);
                bundle.Unload(false);
                callback(_object);
            }
            else
            {
                Debug.Log("Not a valid asset bundle");
            }
        }
    }
}
