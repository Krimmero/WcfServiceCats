using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceCats
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public bool AddCat(Cat cat)
        {
            return DataBaseHelper.AddCat(cat);
        }

        public bool RemoveCat(Cat cat)
        {
            return DataBaseHelper.RemoveCat(cat);
        }

        public bool UpdateCat(Cat cat)
        {
            return DataBaseHelper.UpdateCat(cat);
        }

        public List<string> ListAllCats()
        {
            return DataBaseHelper.ListAllCats();
        }
        
    }
}
