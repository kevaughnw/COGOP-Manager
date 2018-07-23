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
    [DefaultClassOptions]
    public class Member : XPObject
    {
        private System.Drawing.Image image;
        public Member(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _MemberID;
        private Title _Title;
        private string _LastName;
        private string _FirstName;
        private string _MiddleName;
        private TextOnlyEnum _MartialStatus;
        private TextOnlyEnum1 _Gender;
        private TextOnlyEnum2 _Status;
        private DateTime _DateBaptized;
        private string _Phone;
        private DateTime _MemberSince;
        private XPCollection<AuditDataItemPersistent> changeHistory;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MemberID
        {
            get
            {
                return _MemberID;
            }
            set
            {
                SetPropertyValue("MemberID", ref _MemberID, value);
            }
        } // end Member ID

        [Association]
        public Title Title
        {
            get
            {
                return _Title;
            }
            set
            {
                SetPropertyValue("Title", ref _Title, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                SetPropertyValue("LastName", ref _LastName, value);
            }
        } // end lastname

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                SetPropertyValue("FirstName", ref _FirstName, value);
            }
        } // end firstname

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                SetPropertyValue("MiddleName", ref _MiddleName, value);
            }
        } // end middlename

        [NonPersistent]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName ?? "", LastName ?? "");
            }
        }

        public enum TextOnlyEnum { Divorced, Married, Single, Widowed }

        public TextOnlyEnum MartialStatus
        {
            get { return _MartialStatus; }
            set { SetPropertyValue("MartialStatus", ref _MartialStatus, value); }
        }

        public enum TextOnlyEnum1 { Male, Female }

        public TextOnlyEnum1 Gender
        {
            get { return _Gender; }
            set { SetPropertyValue("Gender", ref _Gender, value); }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public DateTime DateBaptized
        {
            get
            {
                return _DateBaptized;
            }
            set
            {
                SetPropertyValue("DateBaptized", ref _DateBaptized, value);
            }
        } // end date baptized

        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                SetPropertyValue("Phone", ref _Phone, value);
            }
        } // end phone

        public DateTime MemberSince
        {
            get
            {
                return _MemberSince;
            }
            set
            {
                SetPropertyValue("MemberSince", ref _MemberSince, value);
            }
        } // end Memeber Since

        public enum TextOnlyEnum2 { Regular, Deceased, Migrated, Dormant, ShutIn, Visitor }

        public TextOnlyEnum2 Status
        {
            get { return _Status; }
            set { SetPropertyValue("Status", ref _Status, value); }
        }

        [Size(256)]
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public System.Drawing.Image Image
        {
            get { return image; }
            set
            {
                SetPropertyValue("Image", ref image, value);
            }
        }

        [Association, ExplicitLoading]
        public XPCollection<PersonalInfo> Personal
        {
            get
            {
                return GetCollection<PersonalInfo>("Personal");
            }
        }

        [Association, ExplicitLoading]
        public XPCollection<PositionInfo> Position
        {
            get
            {
                return GetCollection<PositionInfo>("Position");
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
