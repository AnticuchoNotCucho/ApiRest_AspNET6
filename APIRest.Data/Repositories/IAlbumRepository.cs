using APIRest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRest.Data.Repositories
{
    public interface IAlbumRepository 
    {
        Task<IEnumerable<Album>> GetAllAlbums();
        Task<Album> GetAlbum(int id);
        Task<bool> InsertAlbum(Album album);
        Task<bool> UpdateAlbum(Album album);
        Task<bool> DeleteAlbum(int id);
    }
}
