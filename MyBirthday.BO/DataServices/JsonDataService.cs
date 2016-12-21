using GalaSoft.MvvmLight.Messaging;
using MyBirthday.BO.Messages;
using MyBirthday.BO.Models;
using MyBirthday.Communicatie.DataServices;
using MyBirthday.Communicatie.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.BO.DataServices

{
    public class JsonDataService : IDataService
    {
        readonly string dataFolder =
                   AppDomain.CurrentDomain.BaseDirectory + @"Data\";
        private string bestandsnaam;

        public void AddPersoon(IPersoon persoon)
        {
            bestandsnaam = "Personen.json";
            // Locatie van de File (XML, JSON, TXT, CSV)
            // Defesief programmeren
            // -> Check of Folder bestaat


            // LaboStep: 30-Check of de Data Folder bestaat
            //							Indien niet create folder
            if (!Directory.Exists(dataFolder))
                Directory.CreateDirectory(dataFolder);

            // LaboStep: 31-Create a local Collection of StoreTypes

            var _personen = new List<IPersoon>();

            // LaboStep: 32-Adding a try ... catch
            // Always when you work with files or databases
            try
            {
                // LaboStep: 33-Check if the file exists, yes - Get all the data  
                if (File.Exists(string.Format(@"{0}\{1}", dataFolder, bestandsnaam)))
                {
                    _personen = GetPersonen();
                }


                // LaboStep: 34-Check if the ModelID == 0; Create new object - give ID  value 1
                if ((persoon as Persoon).PersoonId == 0)
                {
                    // bepalen van vorige StoreTypeId via LINQ
                    // variabele = voorwaarde ? true : false
                    int newId = _personen.Count == 0 ? 0 :
                            _personen.Cast<Persoon>().ToList().Select(i => i.PersoonId).Max();

                    // newId++ | ++newId
                    (persoon as Persoon).PersoonId = ++newId;  // create the Id
                    _personen.Add((persoon as Persoon));  // add to the collection
                }
                //The code when you edit a answer
                else
                {
                    // LaboStep: 35-Update het selected Item with the new data
                    // Selecteer het eerste element uit de lijst welke voldoet aan de vergelijking
                    // -> in de lambda expressie of wanneer er niets is gevonden 
                    // -> selecteer de standaard waarde.
                    var item = _personen.FirstOrDefault(
                                type => (type as Persoon).PersoonId ==
                                                    (persoon as Persoon).PersoonId);

                    (item as Persoon).voornaam = (persoon as Persoon).voornaam;

                    // opvangen van eventuele NullReferenceExceptions
                    var storeTypeModel = item as Persoon;
                    if (storeTypeModel != null)
                    {
                        var typeModel = persoon as Persoon;
                        if (typeModel != null) storeTypeModel.Foto = typeModel.Foto;
                    }
                }

                // LaboStep: 36 - Create the necessary XML objects for writing the data from an Object collection to XML file
                // vervangen door    
                //json
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter()); // nodig voor datums
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(dataFolder+""+bestandsnaam))
                using(JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, persoon);
                }



                //LaboStep: 37-Sending the UpdateStoreTypeCollectionMessage with the collection
                Messenger.Default.Send(new UpdatePersoonCollectionMesssage
                {
                    UpdatePersoonCollection = _personen
                }
                                                            );


            }
            catch (Exception ex)
            {
                //
                throw new Exception(ex.Message);

                //LaboStep: 38-Send the Exception Message through a MVVM Message too the ViewModel

            }


        }

        public bool DeletePersoon(int persoonid)
        {
            throw new NotImplementedException();
        }

        public List<IPersoon> GetPersonen()
        {
            bestandsnaam = "Personen.json";
            // LaboStep: 20-Create a local collection of StoreTypes
            var personen = new List<Persoon>();

            try
            {

                // LaboStep: 21-Check of file bestaat
                if (File.Exists(string.Format(@"{0}\{1}", dataFolder, bestandsnaam)))
                {
                    // LaboStep: 22-Creation of a XMLSerializer object
                    using (StreamReader r = new StreamReader(dataFolder+""+bestandsnaam))
                    {
                        string json = r.ReadToEnd();
                        List<Persoon> items = JsonConvert.DeserializeObject<List<Persoon>>(json);
                    }

                }
                // LaboStep: 23-Return the local collection
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return personen.ToList<IPersoon>();
        }

        public IPersoon GetPersoon(int persoonid)
        {
            throw new NotImplementedException();
        }
    }

}
