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
    public class PersonalInfo : XPObject
    {
        public PersonalInfo(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        public string _Address;
        public District _District;
        public Parish _Parish;
        public string _Phone2;
        public string _Phone3;
        public string _NextOfKin;
        public string _NextKinNo;
        public string _Email;
        public string _WorkEmail;
        public string _Notes;
        private TextOnlyEnum _EducationLevel;
        public string _ContactPerson;
        public string _ContactNumber;
        private DateTime _BirthDate;
        public string _Occupation;
        private XPCollection<AuditDataItemPersistent> changeHistory;

        [Size(1080)]
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                SetPropertyValue("Address", ref _Address, value);
            }
        } // end Address

        [Association]
        public District District
        {
            get
            {
                return _District;
            }
            set
            {
                SetPropertyValue("District", ref _District, value);
            }
        }

        [Association]
        public Parish Parish
        {
            get
            {
                return _Parish;
            }
            set
            {
                SetPropertyValue("Parish", ref _Parish, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Phone2
        {
            get
            {
                return _Phone2;
            }
            set
            {
                SetPropertyValue("Phone2", ref _Phone2, value);
            }
        } // end Phone 2

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Phone3
        {
            get
            {
                return _Phone3;
            }
            set
            {
                SetPropertyValue("Phone3", ref _Phone3, value);
            }
        } // end Phone 3

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NextOfKin
        {
            get
            {
                return _NextOfKin;
            }
            set
            {
                SetPropertyValue("NextOfKin", ref _NextOfKin, value);
            }
        } // end NextOfKin

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NextKinNo
        {
            get
            {
                return _NextKinNo;
            }
            set
            {
                SetPropertyValue("NextKinNo", ref _NextKinNo, value);
            }
        } // end NextKinNo

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetPropertyValue("Email", ref _Email, value);
            }
        } // end Email

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string WorkEmail
        {
            get
            {
                return _WorkEmail;
            }
            set
            {
                SetPropertyValue("WorkEmail", ref _WorkEmail, value);
            }
        } // end Work Email

        [Size(2048)]
        public string Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                SetPropertyValue("Notes", ref _Notes, value);
            }
        } // end Notes

        public enum TextOnlyEnum { AsscoiateDegree, DegreeOrBachelors, Diploma, Masters, PhD, SecondaryOrLess }

        public TextOnlyEnum EducationLevel
        {
            get { return _EducationLevel; }
            set { SetPropertyValue("EducationLevel", ref _EducationLevel, value); }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ContactPerson
        {
            get
            {
                return _ContactPerson;
            }
            set
            {
                SetPropertyValue("ContactPerson", ref _ContactPerson, value);
            }
        } // end Contact Person

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ContactNumber
        {
            get
            {
                return _ContactNumber;
            }
            set
            {
                SetPropertyValue("ContactNumber", ref _ContactNumber, value);
            }
        } // end ContactNumber

        public DateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                SetPropertyValue("BirthDate", ref _BirthDate, value);
            }
        } // end Birth Date

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Occupation
        {
            get
            {
                return _Occupation;
            }
            set
            {
                SetPropertyValue("Occupation", ref _Occupation, value);
            }
        } // end Occupation

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
