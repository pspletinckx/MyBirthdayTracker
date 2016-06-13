using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.Communicatie.DataServices
{
    public interface IDataService
    {
        #region methodes voor personen
        List<IPersoon> GetPersonen();
        #endregion
        IPersoon GetPersoon(int persoonid);

        void AddPersoon(IPersoon persoon);

        Boolean DeletePersoon(int persoonid);
    }
}
