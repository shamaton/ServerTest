using System;
using UnityEngine;
using System.Collections;

public class CachingLoadExample : MonoBehaviour
{
  void Start ()
  {
    // Clear Cache
    Caching.CleanCache();

    string url = "https://s3-ap-northeast-1.amazonaws.com/shamototest/wsc/bundleTest.unity3d";

    StartCoroutine (DownloadAndCache ("Cuba",url,1));
  }

  public IEnumerator DownloadAndCache (string assetName, string url, int version = 1)
  {
    // キャッシュシステムの準備が完了するのを待ちます
    while (!Caching.ready)
      yield return null;

    // 同じバージョンが存在する場合はアセットバンドルをキャッシュからロードするか、
    //  またはダウンロードしてキャッシュに格納します。
    using (WWW www = WWW.LoadFromCacheOrDownload (url, version)) {
      yield return www;
      if (www.error != null) {
        throw new Exception ("WWWダウンロードにエラーがありました:" + www.error);
      }

      AssetBundle bundle = www.assetBundle;
      if (assetName == "")
        Instantiate (bundle.mainAsset);
      else
        Instantiate (bundle.LoadAsset (assetName));
      // メモリ節約のため圧縮されたアセットバンドルのコンテンツをアンロード
      bundle.Unload (false);

    } // memory is freed from the web stream (www.Dispose() gets called implicitly)
  }
}