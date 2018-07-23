using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COGOP_Manager.Module.BusinessObjects
{
    public class Appointment : XPObject
    {
        public Appointment(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _position;
        private DateTime _appointmentStartDate;
        private DateTime _appointmentEndDate;
        //private int appointmentYears;
        private XPCollection<AuditDataItemPersistent> changeHistory;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public DateTime appointmentStartDate
        {
            get
            {
                return _appointmentStartDate;
            }
            set
            {
                SetPropertyValue("AppointmentStartDate", ref _appointmentStartDate, value);
            }
        } // end date appointed

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public DateTime appointmentEndDate
        {
            get
            {
                return _appointmentEndDate;
            }
            set
            {
                SetPropertyValue("AppointmentEndDate", ref _appointmentEndDate, value);
            }
        } // end date ended appointed

    public XPCollection<AuditDataItemPersistent> ChangeHistory
        {
            get
            {
                if (changeHistory == null)
                {
                    changeHistory = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return changeHistory;
            }
        }

    }
}
