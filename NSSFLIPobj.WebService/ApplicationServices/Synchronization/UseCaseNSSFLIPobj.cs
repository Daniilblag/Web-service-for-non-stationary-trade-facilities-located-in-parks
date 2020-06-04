using System;
using System.Collections.Generic;
using System.Net;
using NSSFLIPobj.DomainObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace NSSFLIPobj.ApplicationServices.Synchronization
{
    public class NSSFLIPobj_Cell
    {
        public int global_id { get; set; }
        public int Number { get; set; }
        public NSSFLIPobj_inf Cells { get; set; }
    }

    public class NSSFLIPobj_inf
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string AdminArea { get; set; }
        public string District { get; set; }
        public string Adress { get; set; }
        public string CodAdrIP { get; set; }
        public string AreaObj { get; set; }
        public string KindObj { get; set; }
        public string Specialization { get; set; }
        public string PlacementPeriod { get; set; }
        public string TypeOfContract { get; set; }
        public string ContractStatus { get; set; }
        public string NumberOfContract { get; set; }
        public string NameOfBusinessEntity { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractFinishDate { get; set; }
        public string GroundsForConcluding { get; set; }
        public string TradingStartDate { get; set; }
    }


    public class UseCaseNSSFLIPobj
    {
        static string remoteUri = "https://apidata.mos.ru/v1/datasets/61356/rows?api_key=aa284d4afd4fc64eab7198014a34847c";

        List<NSSFLIPobj_Cell> nssflipobj_cells;

        public List<nssflipobj> nssflipobjs = new List<nssflipobj>();

        public UseCaseNSSFLIPobj()
        {
            
            WebRequest request = WebRequest.Create(remoteUri);
            WebResponse response = request.GetResponse();

            
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string line = stream.ReadToEnd();

            JArray jsonArray = JArray.Parse(line);

            nssflipobj_cells = JsonConvert.DeserializeObject<List<NSSFLIPobj_Cell>>(jsonArray.ToString());


            for (int i = 0; i < nssflipobj_cells.Count; i++)
            {
                nssflipobjs.Add(new nssflipobj()
                {
                    Number = nssflipobj_cells[i].Cells.Number,
                    Name = nssflipobj_cells[i].Cells.Name,
                    AdminArea = nssflipobj_cells[i].Cells.AdminArea,
                    District = nssflipobj_cells[i].Cells.District,
                    Adress = nssflipobj_cells[i].Cells.Adress,
                    CodAdrIP = nssflipobj_cells[i].Cells.CodAdrIP,
                    AreaObj = nssflipobj_cells[i].Cells.AreaObj,
                    KindObj = nssflipobj_cells[i].Cells.KindObj,
                    Specialization = nssflipobj_cells[i].Cells.Specialization,
                    PlacementPeriod = nssflipobj_cells[i].Cells.PlacementPeriod,
                    TypeOfContract = nssflipobj_cells[i].Cells.TypeOfContract,
                    ContractStatus = nssflipobj_cells[i].Cells.ContractStatus,
                    NumberOfContract = nssflipobj_cells[i].Cells.NumberOfContract,
                    NameOfBusinessEntity = nssflipobj_cells[i].Cells.NameOfBusinessEntity,
                    ContractStartDate = nssflipobj_cells[i].Cells.ContractStartDate,
                    ContractFinishDate = nssflipobj_cells[i].Cells.ContractFinishDate,
                    GroundsForConcluding = nssflipobj_cells[i].Cells.GroundsForConcluding,
                    TradingStartDate = nssflipobj_cells[i].Cells.TradingStartDate
                });
            }
        }

    }
}