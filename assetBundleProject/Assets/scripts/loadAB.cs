using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class loadAB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("assetBundleRequest");
    }
    void loadABlocal() {
        AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/aa.bb");
        GameObject obj = ab.LoadAsset<GameObject>("Capsule");
        Instantiate(obj);
    }

    void loadABFromMemory() {
        AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes("AssetBundles/aa.bb"));
        GameObject obj = ab.LoadAsset<GameObject>("Capsule");
        Instantiate(obj);
    }

    IEnumerator assetBundleRequest() {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes("AssetBundles/aa.bb"));
        yield return request;
        AssetBundle ab = request.assetBundle;
        GameObject obj = ab.LoadAsset<GameObject>("Capsule");
        Instantiate(obj);
    }

    IEnumerator unityWebRequest()
    {
        string url = @"127.0.0.1/AssetBundles/AssetBundles/aa.bb";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return request.SendWebRequest();
        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        GameObject obj = ab.LoadAsset<GameObject>("Capsule");
        Instantiate(obj);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
