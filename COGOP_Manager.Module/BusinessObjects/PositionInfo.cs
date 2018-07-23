using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COGOP_Manager.Module.BusinessObjects
{
    public class PositionInfo : XPObject
    {
        public PositionInfo(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private TextOnlyEnum _PositionLevel;
        public string _Name;
        public DateTime _StartDate;
        public DateTime _EndDate;
        private XPCollection<AuditDataItemPersistent> changeHistory;

        public enum TextOnlyEnum { National, Parish, Local }

        public TextOnlyEnum PositionLevel
        {
            get { return _PositionLevel; }
            set { SetPropertyValue("PositionLevel", ref _PositionLevel, value); }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
            }
        } // end Name

        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                SetPropertyValue("StartDate", ref _StartDate, value);
            }
        } // end Start Date

        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                SetPropertyValue("EndDate", ref _EndDate, value);
            }
        } // end End Date

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

        [Association]
        public XPCollection<Member> Members
        {
            get
            {
                return GetCollection<Member>("Members");
            }
        }

    }
}
