using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Profile;

namespace WcfServiceCats
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool AddCat(Cat cat);

        [OperationContract]
        bool RemoveCat(Cat cat);

        [OperationContract]
        bool UpdateCat(Cat cat);

        [OperationContract]
        IEnumerable<Cat> ListAllCats(Cat cat);




        /*[OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        */
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]

    public class Cat
    {
        private string _name;
        private string _breed;
        private int _age;
        private string _ownersName;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public string Breed
        {
            get { return _breed; }
            set { _breed = value; }
        }

        [DataMember]
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        [DataMember]
        public string OwnersName
        {
            get { return _ownersName; }
            set { _ownersName = value; }
        }
    }
}
