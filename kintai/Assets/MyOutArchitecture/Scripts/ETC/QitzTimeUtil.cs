using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QitzTimeUtil 
{

    public const double ALLOWABLE_DIFF_TIME_LOCAL_TIME_FROM_SERVER_TIME = 60*20;

    public string FroatToMinAndSeconds(float time)
    {
        int min = (int)(time / 60);
        int second = (int)(time % 60);
        return min.ToString("00") + ":" + second.ToString("00");
    }

    public string FroatToMin(float time)
    {
        int min = (int)(time / 60)%60;
        return min.ToString();
    }
    public string FroatToHour(float time)
    {
        int hour = (int)(time / (60 * 60));
        return "" + hour;
    }

    public string FroatToMinLowerFigureCuted(float time)
    {
        int min = (int)(time / 60);
        int second = (int)(time % 60);
        return min.ToString("00") + ":" + second.ToString("00");
    }

    public string FroatToMinOnly(float time)
    {
        int min = (int)(time / 60);
        return min.ToString("00") + ":" + "00";
    }

    public string FroatToHourAndMinite(float time)
    {
        int min = (int)(time / 60)%60;
        int hour = (int)(time / (60*60));
        return hour + "<size=60>h</size>" + min + "<size=60>m</size>";
    }

    public int FromToMinVal(float time)
    {
        return (int)(time / 60);
    }

    public DateTime NowDataTime
    {
        get
        {
            return DateTime.Now;
        }
    }

    public double CurrentTimeStamp
    {
        get
        {
            return (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }

    public double MinToSeconds(int min)
    {
        return min * 60;
    }

    public DateTime GetLocalDataTimeFromTimeStamp(double timeStamp)
    {
        return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timeStamp).ToLocalTime();
    }

    public double GetTimeStampFromDataTime(DateTime dateTime)
    {
        return (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }

    public DateTime GetFutureDateTime(double addTime)
    {
        return NowDataTime.AddSeconds(addTime).ToLocalTime();
    }

    public bool GetAcrossTowDaysFlag(double currentTime, double targetTime)
    {
        var currentDateString = GetLocalDataTimeFromTimeStamp(currentTime).ToLongDateString();
        var targetDateString = GetLocalDataTimeFromTimeStamp(targetTime).ToLongDateString();
        return currentDateString != targetDateString;
    }
}
