using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
//using UniRx;
//using UniRx.Triggers;

// NTP同期時刻を管理するクラス
public class NtpServerDateGatter : MonoBehaviour {

    private DateTime ntpDate;   // NTP同期時刻
    private float rcvAppDate;   // NTP通信時のアプリ時刻

    private IPEndPoint ipAny;
    private UdpClient sock;
    private Thread thread;
    private volatile bool threadRunning = false;
    private byte[] rcvData;

    // 初期化
    void Start()
    {
        // リクエスト実行
        SyncDate();
        // 時刻表示(デバッグ用)
        StartCoroutine(ShowSyncDate());
    }

    // 同期時刻の表示
    private IEnumerator ShowSyncDate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (Date == null && UnityEngine.Application.internetReachability != NetworkReachability.NotReachable)
            {
                errorDataTimeCount++;
            }
            else
            {
                //Debug.Log("Receive date : " + Date.ToString());
            }
        }
    }

    // アプリケーション終了時処理
    void OnApplicationQuit()
    {
        if (thread != null)
        {
            thread.Abort();
        }
        if (sock != null)
        {
            sock.Close();
        }
    }

    // 時刻同期を行う
    public void SyncDate()
    {
        // リクエスト実行
        threadRunning = true;
        thread = new Thread(new ThreadStart(Request));
        thread.Start();

        // リクエスト待機コルーチン実行
        StartCoroutine(WaitForRequest());

        Debug.Log("Thread is started.");
    }

    // NTPサーバに対してリクエストを実行する
    private void Request()
    {
        // ソケットを開く
        ipAny = new IPEndPoint(IPAddress.Any, 123);
        sock = new UdpClient();

        // リクエスト送信
        byte[] sndData = new byte[48];
        sndData[0] = 0xB;
        sock.Send(sndData, sndData.Length, "time.google.com", 123);

        // データ受信
        rcvData = sock.Receive(ref ipAny);

        // 実行中フラグクリア
        threadRunning = false;
    }

    // リクエスト待機コルーチン
    private IEnumerator WaitForRequest()
    {
        // リクエスト終了まで待機
        while (threadRunning)
        {
            yield return 0;
        }

        // アプリ時刻保存
        rcvAppDate = Time.realtimeSinceStartup;

        // 受信したバイナリデータをDateTime型に変換
        ntpDate = new DateTime(1900, 1, 1);
        var high = (double)BitConverter.ToUInt32(new byte[] { rcvData[43], rcvData[42], rcvData[41], rcvData[40] }, 0);
        var low = (double)BitConverter.ToUInt32(new byte[] { rcvData[47], rcvData[46], rcvData[45], rcvData[44] }, 0);
        ntpDate = ntpDate.AddSeconds(high + low / UInt32.MaxValue);

        // UTC→ローカル日時に変換
        ntpDate = ntpDate.ToLocalTime();
    }


    // NTP同期時刻
    public DateTime Date
    {
        get
        {
            return ntpDate.AddSeconds(Time.realtimeSinceStartup - rcvAppDate);
        }
    }
    public DateTimeEntity CurrentDate
    {
        get
        {
            if (UnityEngine.Application.internetReachability == NetworkReachability.NotReachable)
            {
                return new DateTimeEntity();
            }
            //エラー回数が指定回数を超えた場合は端末時間を返す
            else if (this.ExistServerError)
            {
                return new DateTimeEntity(DateTime.Now);
            }
            return new DateTimeEntity(Date);
        }
    }
    int errorDataTimeCount = 0;
    const int MAX_ERROR_DATA_TIME_COUNT = 30;
    public bool ExistServerError => MAX_ERROR_DATA_TIME_COUNT <= errorDataTimeCount;
    public void ResetServerErrorCount()
    {
        errorDataTimeCount = 0;
    }
}
public enum DateTimeState
{
    EMPTY,
    CONTAINS,
    ERROR,
}
public class DateTimeEntity 
{
    public DateTime Date { get; private set; }
    public DateTimeState DateTimeState { get; private set; }

    public DateTimeEntity AddSecconds(int sec)
    {
        Date = Date.AddSeconds(sec);
        return this;
    }

    public DateTimeEntity(DateTimeState dateTimeState = DateTimeState.EMPTY)
    {
        this.DateTimeState = dateTimeState;
    }

    public DateTimeEntity(DateTime date)
    {
        this.Date = date;
        if (this.Date == null)
        {
            this.DateTimeState = DateTimeState.EMPTY;
        }
        else
        {
            this.DateTimeState = DateTimeState.CONTAINS;
        }

    }

}