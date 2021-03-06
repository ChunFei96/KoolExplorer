

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.DropDown
{
    public interface IDropDownService
    {
        Task<List<string>> GetDropDownByCode(string code);

        Task<List<string>> FilterDropDown();
    }
}
