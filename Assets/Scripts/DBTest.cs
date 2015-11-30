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
    StartCoroutine (funcName);
  }

  const string HOST = "http://example-elb-1795101482.ap-northeast-1.elb.amazonaws.com/";

  /////////////////////////////////////////////////
  class SelectUserPost {
    public int Id { get; set;}
  };
  /////////////////////////////////////////////////
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
      Debug.Log("RECIEVE Id:" + user.Id+ "Name:" + user.Name + ", Score:" + user.Score);
    }
  }
    

  /////////////////////////////////////////////////
  class UpdateUserPost {
    public int Id { get; set;}
    public int AddScore { get; set;}
  };
  /////////////////////////////////////////////////
  /*
   * USER UPDATE
   */
  IEnumerator UpdateUser() {
    string url = "test_user_update";
    UpdateUserPost sendData = new UpdateUserPost();
    sendData.Id = 2;
    sendData.AddScore += 123;

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
      Debug.Log("RECIEVE Id:" + user.Id+ "Name:" + user.Name + ", Score:" + user.Score);
    }
  }

  /////////////////////////////////////////////////
  class CreateUserPost {
    public string Name { get; set;}
  };
  /////////////////////////////////////////////////
  /*  
   * USER CREATE
   */
  IEnumerator CreateUser() {
    string url = "test_user_create";
    CreateUserPost sendData = new CreateUserPost();
    sendData.Name = "fromUnity";

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
      Debug.Log("RECIEVE Id:" + user.Id+ "Name:" + user.Name + ", Score:" + user.Score);
    }
  }

  /////////////////////////////////////////////////
  class UserItemPost {
    public int UserId { get; set;}
    public int ItemId { get; set;}
    public int Num { get; set;}
  };
  /////////////////////////////////////////////////
  /*  
   * USER ITEM SAVE 
   */
  IEnumerator SaveUserItem() {
    string url = "test_user_item_create";
    UserItemPost sendData = new UserItemPost();
    sendData.UserId = 1;
    sendData.ItemId = 1;
    sendData.Num = 10;

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
      Debug.Log ("text:" + www.text);
    }
  }

  /*  
   * USER ITEM DELETE 
   */
  IEnumerator DeleteUserItem() {
    string url = "test_user_item_delete";
    UserItemPost sendData = new UserItemPost();
    sendData.UserId = 1;
    sendData.ItemId = 1;

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
      Debug.Log ("text:" + www.text);
    }
  }

  /////////////////////////////////////////////////
  class CreateUserLogPost {
    public int Id { get; set;}
    public int Value { get; set;}
  };
  /////////////////////////////////////////////////
  /*  
   * USER LOG CREATE 
   */
  IEnumerator CreateUserLog() {
    string url = "test_user_log_create";
    CreateUserLogPost sendData = new CreateUserLogPost();
    sendData.Id = 2;
    sendData.Value += 9999;

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
      Debug.Log ("text:" + www.text);
    }
  }

  /*  
   * USER MISC TEST 
   */
  IEnumerator MiscUser() {
    string url = "test_user_misc";
    // とりあえず空データ
    UpdateUserPost sendData = new UpdateUserPost();

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
      Debug.Log ("text:" + www.text);
    }
  }

  /**
   * TOKEN TEST
   */
  IEnumerator TokenTest() {
    string url = "token_test";
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

    using (WWW www = new WWW(HOST + url, form)) {
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
