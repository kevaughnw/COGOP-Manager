using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COGOP_Manager.Module.BusinessObjects
{
    public class Title : XPObject
    {
        public Title(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _TitleName;
        private XPCollection<AuditDataItemPersistent> changeHistory;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TitleName
        {
            get
            {
                return _TitleName;
            }
            set
            {
                SetPropertyValue("Title", ref _TitleName, value);
            }
        } // end Title

        [Association]
        public XPCollection<Member> Members
        {
            get
            {
                return GetCollection<Member>("Members");
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
