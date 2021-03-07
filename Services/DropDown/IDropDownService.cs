using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.DropDown
{
    public interface IDropDownService
    {
        Task<List<SelectListItem>> GetDropDownByType(string code);

        //Task<List<string>> FilterDropDown();
    }
}
