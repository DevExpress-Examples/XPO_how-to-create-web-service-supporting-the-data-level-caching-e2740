using DevExpress.Xpo;

namespace DXSample.PersistentClasses {
    public class Person : XPObject {
        public Person(Session session) : base(session) { }

        private string fName;
        public string Name {
            get {
                return fName;
            }
            set {
                SetPropertyValue("Name", ref fName, value);
            }
        }

        private int fAge;
        public int Age {
            get {
                return fAge;
            }
            set {
                SetPropertyValue("Age", ref fAge, value);
            }
        }
    }
}