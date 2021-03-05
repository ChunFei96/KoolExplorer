using Core;
using Core.Expansion.Enum;
using DAL.Entities.Form;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Form
{
    public class ApplicationForm : BaseEntity
    {
        [ForeignKey("GeneralInformationItems")]
        public int generalInformationItemsId { get; set; }
        [ForeignKey("ParentParticularItems")]
        public int parentParticularItemsId { get; set; }
        [ForeignKey("ChildParticularItems")]
        public int childParticularItemsId { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; } 
        public virtual GeneralInformationItems generalInformationItems { get; set; }
        public virtual ParentParticularItems parentParticularItems { get; set; }
        public virtual ChildParticularItems childParticularItems { get; set; }
    }
}
