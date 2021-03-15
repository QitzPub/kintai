using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLDKEscapeOut.IRepository;
using System;
using BLDKEscapeOut.Actore;
using BLDKEscapeOut.Entity;
using UniRx;

namespace BLDKEscapeOut.UseCase
{
    public interface IEscapeOutTransmitter
    {
        GachaTrunUseCase GachaTrunUseCase { get; }
        AudioPlayUseCase AudioPlayUseCase { get; }
        CreateInvoiceUseCase CreateInvoiceUseCase { get; }
        PostAttendUseCase PostAttendUseCase { get; }
        GetCalenderInformationUseCase GetCalenderInformationUseCase { get; }
        AddCalenderScheduleUseCase AddCalenderScheduleUseCase { get; }
    }
}