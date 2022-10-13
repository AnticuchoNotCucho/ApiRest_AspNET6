using APIRest.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace APIRest.Data.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MySqlConfiguration _connectionString;

        public AlbumRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection DbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteAlbum(int id)
        {
            var db = DbConnection();
            var sql = @"Delete from album where idAlbum = @ID";
            var result = await db.ExecuteAsync(sql, new { ID = id });
            return result > 0;
            
        }

        public async Task<Album> GetAlbum(int id)
        {
            var db = DbConnection();
            var sql = @"Select idBands, idAlbum, AlbumName from album where idAlbum = @ID";
            return await db.QueryFirstOrDefaultAsync<Album>(sql, new {ID = id});
        }

        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            var db = DbConnection();
            var sql = @"Select * from album";
            return await db.QueryAsync<Album>(sql, new {});
        }

        public async Task<bool> InsertAlbum(Album album)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAlbum(Album album)
        {
            throw new NotImplementedException();
        }
    }
}
