using APIRest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRest.Data.Repositories
{
    public interface IBandRepository
    {
        Task<IEnumerable<Band>> GetAllBands();
        Task<Band> GetDetails(int id);

        Task<bool> InsertBand(Band band);
        Task<bool> UpdateBand(Band band);
        Task<bool> DeleteBand(Band band);
    }
}
