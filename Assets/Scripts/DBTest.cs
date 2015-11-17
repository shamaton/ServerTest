using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class DBTest : MonoBehaviour {

  public class DBUsers {
    public int id { get; set;}
    public int score { get; set;}
    public string name { get; set;}
  }
  public class DBUsers2 {
    public int Score { get; set;}
    public string Name { get; set;}
  }


  public class RecieveUser {
    public int Id { get; set;}
    public string Name { get; set;}
    public int Score { get; set;}
  }


  public void OnClickButton(string funcName){
    //Connectコルーチンの実行
    //StartCoroutine (SetUserTest());
    StartCoroutine (funcName);
  }

  IEnumerator SetUserTest() {
    string url = "http://192.168.56.101/unity_db_test.php";

    DBUsers sendData = new DBUsers ();
    sendData.id = 1;
    sendData.name = "superman";
    sendData.score = 100;
    WWWForm form = new WWWForm ();
    form.AddField ("user", JsonMapper.ToJson(sendData));
    using (WWW www = new WWW(url, form)) {
      yield return www;
      if (! string.IsNullOrEmpty (www.error)) {
        Debug.Log ("error:" + www.error);
        yield break;
      }
      Debug.Log ("text:" + www.text);
      DBUsers user = JsonMapper.ToObject<DBUsers>(www.text);
      Debug.Log("id:"+user.id+", name:"+user.name+", score:"+user.score);
    }
  }

  const string HOST = "http://localhost:9999/";

  class SelectUserPost {
    public int Id { get; set;}
  };
  /**
   * USER SELECT TEST 
   */
  IEnumerator SelectUser() {
    string url = "test_user_select";

    SelectUserPost sendData = new SelectUserPost();
    sendData.Id = 1;

    Dictionary<string, string> headers = new Dictionary<string, string>();
    headers["Content-Type"] = "application/json; charset=utf-8";

    string dataStr = JsonMapper.ToJson(sendData);
    Debug.Log(dataStr);

    byte[] data = System.Text.Encoding.UTF8.GetBytes(dataStr);


    using (WWW www = new WWW(HOST + url, data, headers)) {

      yield return www;

      if (! string.IsNullOrEmpty (www.error)) {
        Debug.Log ("error:" + www.error);
        yield break;
      }
      //Debug.Log ("text:" + www.text);
      RecieveUser user = JsonMapper.ToObject<RecieveUser>(www.text);
      Debug.Log("RECIEVE Id:" + user.Id+ "Name:" + user.Name + ", Age:" + user.Score);
    }

  }

  IEnumerator UpdateUser() {
    string url = "test_user_create";
    yield return 0;
  }

  IEnumerator CreateUser() {
    string url = "test_user_create";
    yield return 0;
  }

  IEnumerator SaveUserItem() {
    string url = "test_user_create";
    yield return 0;
  }

  IEnumerator DeleteUserItem() {
    string url = "test_user_create";
    yield return 0;
  }

  IEnumerator CreateUserLog() {
    string url = "test_user_create";
    yield return 0;
  }

  IEnumerator MiscUser() {
    string url = "test_user_create";
    yield return 0;
  }

  IEnumerator SetUserTest2() {
    string url2 = "http://localhost:9999/test";

    DBUsers2 sendData = new DBUsers2 ();
    sendData.Name = "superman";
    sendData.Score = 100;

    //string yakinikuToken = "qawsedrftgyhujiklo;p"; // 架空の認証トークン

    Dictionary<string, string> headers = new Dictionary<string, string>(); // ヘッダ情報のHashtable
    //headers["Authorization"] = "Yakiniku " + yakinikuToken; // 架空の認証Yakinikuに思いの詰まった架空のトークンを付与
    //headers["Host"] = "192.168.56.101"; // APIのHOST
    headers["Content-Type"] = "application/json; charset=utf-8"; // UTF8なJsonだよ

    string dataStr = JsonMapper.ToJson(sendData); // Json型を吐き出してくれるメソッドが予めYakinikuDataにはある予定
    Debug.Log (url2);
    Debug.Log(dataStr); //ちなみにこんな値になる感じで→{"shopId":3939,"openTime":"8:00","nearStationName":"PachinkoGUNDAM"}　
    byte[] data = System.Text.Encoding.UTF8.GetBytes(dataStr);


    using (WWW www = new WWW(url2, data, headers)) {
      yield return www;
      if (! string.IsNullOrEmpty (www.error)) {
        Debug.Log ("error:" + www.error);
        yield break;
      }
      Debug.Log ("text:" + www.text);
      DBUsers2 user = JsonMapper.ToObject<DBUsers2>(www.text);
      Debug.Log("final Name:"+user.Name+", Age:"+user.Score);
    }

  }

  IEnumerator TokenTest() {
    string url = "http://localhost:9999/token_test";
    DBUsers2 sendData = new DBUsers2 ();
    sendData.Name = "superman";
    sendData.Score = 100;
   
    Dictionary<string, string> headers = new Dictionary<string, string>();
    headers["Content-Type"] = "application/json; charset=utf-8";

    string toJson = JsonMapper.ToJson(sendData);
    Debug.Log(toJson); //ちなみにこんな値になる感じで→{"shopId":3939,"openTime":"8:00","nearStationName":"PachinkoGUNDAM"}　
    byte[] data = Encoding.UTF8.GetBytes(toJson);

    // トークン作成
    string token = Convert.ToBase64String (data);
    Debug.Log ("token : " + token);

    string res = sha256("apple", "secret_key");
    Debug.Log (res);

    WWWForm form = new WWWForm ();
    form.AddField ("data", toJson);
    form.AddField ("token", token);
    form.AddField ("sha", res);

    using (WWW www = new WWW(url, form)) {
      yield return www;
      if (! string.IsNullOrEmpty (www.error)) {
        Debug.Log ("error:" + www.error);
        yield break;
      }
      Debug.Log ("text:" + www.text);
    }
  }

  private string sha256(string planeStr, string key) {
    System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
    byte[] planeBytes = ue.GetBytes(planeStr);
    byte[] keyBytes = ue.GetBytes(key);
    System.Security.Cryptography.HMACSHA256 sha256 = new System.Security.Cryptography.HMACSHA256(keyBytes);
    byte[] hashBytes = sha256.ComputeHash(planeBytes);
    string hashStr = "";
    foreach(byte b in hashBytes) {
      hashStr += string.Format("{0,0:x2}", b);
    }
    return hashStr;
  }
}
