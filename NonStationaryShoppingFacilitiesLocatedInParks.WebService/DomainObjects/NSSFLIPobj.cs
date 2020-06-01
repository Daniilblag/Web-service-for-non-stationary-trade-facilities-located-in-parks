using System;
using System.Collections.Generic;
using System.Text;

namespace NSSFLIPobj.DomainObjects
{
    public class NSSFLIPobj : DomainObject
    {
        public string Number { get; set; }
        public string NameObj { get; set; }
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
}
