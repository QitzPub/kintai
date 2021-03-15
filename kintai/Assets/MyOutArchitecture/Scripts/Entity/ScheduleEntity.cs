using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BLDKEscapeOut.View;

namespace BLDKEscapeOut.Entity
{
    [Serializable]
    public class ScheduleEntity : BaseEntity
    {
        [SerializeField]
        int eventStartHour;
        public int EventStartHour => eventStartHour;
        [SerializeField]
        int eventEndHour;
        public int EventEndHour => eventEndHour;

        [SerializeField]
        string eventTitle;
        public string EventTitle => eventTitle;

        [SerializeField]
        string eventDescription;
        public string EventDescription => eventDescription;


    }
}