using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.Communicatie.Data
{
    public interface IDataOperations
    {
        //crud
        void Save();
        void Search();
        void Save(Guid id);
        void Delete(Guid id);
    }
}
