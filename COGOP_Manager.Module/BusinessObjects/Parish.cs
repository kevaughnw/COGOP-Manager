using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COGOP_Manager.Module.BusinessObjects
{
    public class Parish : XPObject
    {
        public Parish(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _Parish;
        private XPCollection<AuditDataItemPersistent> changeHistory;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DistrictName
        {
            get
            {
                return _Parish;
            }
            set
            {
                SetPropertyValue("DistrictName", ref _Parish, value);
            }
        } // end District Name

        [Association]
        public XPCollection<PersonalInfo> Personal
        {
            get
            {
                return GetCollection<PersonalInfo>("Personal");
            }
        }

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
