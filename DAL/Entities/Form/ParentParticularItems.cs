using Core;

namespace DAL.Entities.Form
{
    public class ParentParticularItems : BaseEntity
    {
        public string ParentName1 { get; set; }
        public string PassportNo1 { get; set; }
        public string MobileNo1 { get; set; }
        public string Email1 { get; set; }
        public string ParentName2 { get; set; }
        public string PassportNo2 { get; set; }
        public string MobileNo2 { get; set; }
        public string Email2 { get; set; }
        public string HomeTelNo { get; set; }
        public string StreetName { get; set; }
        public string BlockNo { get; set; }
        public string FloorNo { get; set; }
        public string UnitNo { get; set; }
        public string BuildingName { get; set; }
        public string PostalCode { get; set; }
        public string HouseholdIncome { get; set; }
    }
}
