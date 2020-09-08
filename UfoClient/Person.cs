using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO
{
    public class Person
    {

        //Пассажир
        public int PassengerID { get; set; }
        public DateTime ChecklTime { get; set; }
        public string PassengerBorderRouting { get; set; } 
        public string PassengerPersonalNumber { get; set; }
        public string PassengerFio { get; set; }
        public DateTime PassengerDocValidity { get; set; }
        public string PassengerCitizenship { get; set; }
        public string PassengerDocumentNum { get; set; }

        public string Family { get; set; }
        public string Name { get; set; }
        public string FullName { get { return Family + " " + Name; } }
        public DateTime DateOfBirth { get; set; }

        public string Sex { get; set; }
        public string NationalityName { get; set; }
        public string NationalityId { get; set; }
        
        public byte[] ImageArray { get; set; }
    }
    public class Ressemblance
    {
        //Сходство с базой
        public int RessemblancePersonID { get; set; }
        public string RessemblanceFioLat { get; set; }
        public string RessemblanceNationalityCode { get; set; }
        public DateTime RessenblanceDateOfBirth { get; set; }
        public DateTime RessenblanceDocValidity { get; set; }
        public string RessemblancePersonalNumber { get; set; }
        public string RessemblanceFioRus { get; set; }
        public string RessemblanceDocumentNumber { get; set; }
    }
    public class OUDump
    {
        //Сходство с ОУ
        public int OUPersonID { get; set; }
        public int OUID { get; set; }
        public int LevensteinDistance { get; set; }
        public string FIO { get; set; }
        public string OU_BirthDate { get; set; }
        public string OU_NationalityCode { get; set; }
        public string SpecialMark { get; set; }
        public string OUTask { get; set; }
    }
       
}
