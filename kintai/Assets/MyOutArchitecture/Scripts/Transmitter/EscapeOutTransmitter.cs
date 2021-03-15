using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLDKEscapeOut.UseCase;
using BLDKEscapeOut.Entity;
using BLDKEscapeOut.Actore;
using System;

namespace BLDKEscapeOut.Transmitter
{
    public class EscapeOutTransmitter : BaseTransmitter, IEscapeOutTransmitter
    {

        public GachaTrunUseCase GachaTrunUseCase { get; private set; } = new GachaTrunActore();

        [SerializeField]
        AudioPlayActore audioPlayActore;

        public AudioPlayUseCase AudioPlayUseCase => audioPlayActore;

        CreateInvoiceUseCase createInvoiceActor = new StubCreateInvoiceActor();
        public CreateInvoiceUseCase CreateInvoiceUseCase => createInvoiceActor;

        PostAttendUseCase postAttendActore = new StubPostAttendActore();
        public PostAttendUseCase PostAttendUseCase => postAttendActore;

        GetCalenderInformationUseCase getCalendarInformationActor = new StubGetCalenderInformationActore();
        public GetCalenderInformationUseCase GetCalenderInformationUseCase => getCalendarInformationActor;

        AddCalenderScheduleUseCase addCalendarScheduleActor = new StubAddCalenderScheduleActore();
        public AddCalenderScheduleUseCase AddCalenderScheduleUseCase => addCalendarScheduleActor;
    }
}