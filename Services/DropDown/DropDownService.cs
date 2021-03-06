

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.DropDown
{
    public class DropDownService : IDropDownService
    {

        public DropDownService()
        {

        }

        public Task<List<string>> FilterDropDown()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<string>> GetDropDownByCode(string code)
        {
            throw new System.NotImplementedException();
        }
    }
}
