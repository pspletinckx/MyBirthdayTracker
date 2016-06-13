using MyBirthday.Communicatie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.Messages
{
    public class UpdatePersoonCollectionMesssage
    {
        public List<IPersoon> UpdatePersoonCollection
        {
            get; set;
        }
    }
}
