using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BLDKEscapeOut.View;

namespace BLDKEscapeOut.Entity
{
    [Serializable]
    public class CalenderMonthEntity : BaseEntity
    {
        [SerializeField]
        int year;
        public int Year => year;
        [SerializeField]
        int month;
        public int Month => month;

        [SerializeField]
        List<CalenderDayEntity> days = new List<CalenderDayEntity>();
        public IReadOnlyCollection<CalenderDayEntity> Days => days;


    }
}