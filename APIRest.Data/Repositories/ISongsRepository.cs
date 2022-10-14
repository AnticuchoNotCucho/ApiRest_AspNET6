using APIRest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRest.Data.Repositories
{
    public interface ISongsRepository
    {
        Task<IEnumerable<Songs>> GetSongs();
        Task<Songs> GetSong(int idSongs, int idAlbum);
        Task<bool> InsertSong(Songs song);
        Task<bool> UpdateSong(Songs song);
        Task<bool> DeleteSong(int idAlbum, int idSongs);
    }
}
