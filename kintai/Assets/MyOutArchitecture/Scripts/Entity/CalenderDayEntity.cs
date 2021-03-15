using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BLDKEscapeOut.View;

namespace BLDKEscapeOut.Entity
{
    [Serializable]
    public class CalenderDayEntity : BaseEntity
    {
        [SerializeField]
        int year;
        public int Year => year;
        [SerializeField]
        int month;
        public int Month => month;
        [SerializeField]
        int day;
        public int Day => day;
        [SerializeField]
        List<ScheduleEntity> scheduleEntities=new List<ScheduleEntity>();
        public IReadOnlyCollection<ScheduleEntity> ScheduleEntities => scheduleEntities;



    }
}