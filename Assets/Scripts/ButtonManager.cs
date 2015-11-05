using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

  public void OnClickButton(){
    //Connectコルーチンの実行
    StartCoroutine (Connect());
  }

  private IEnumerator Connect(){
    string url = "http://192.168.56.101/unity_test.php";

    //WWWForm:WWWクラスを使用してwebサーバにポストするフォームデータを生成するヘルパークラス
    WWWForm wwwForm = new WWWForm();

    //AddFieldでfieldに値を格納                
    wwwForm.AddField ("text", "bjklf");

    //WWWオブジェクトにURL,WWWFormをセットすることでPOST,GETを行える。
    WWW www = new WWW(url, wwwForm);

    //実行
    yield return www;
    if (www.error == null) {
      Debug.Log(www.text);
    }
  }
}
