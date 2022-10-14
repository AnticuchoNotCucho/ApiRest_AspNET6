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
        public async Task<bool> DeleteAlbum(int idAlbum, int idBands)
        {
            var db = DbConnection();
            var sql = @"Delete from album where idAlbum = @ID and idBands = @idband";
            var result = await db.ExecuteAsync(sql, new { ID = idAlbum, idband = idBands });
            return result > 0;
            
        }

        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            var db = DbConnection();
            var sql = @"Select * from album";
            return await db.QueryAsync<Album>(sql, new {});
        }

        public async Task<bool> InsertAlbum(Album album)
        {
            var db = DbConnection();
            var sql = @"Insert into album(AlbumName, idBands) values(@name, @idband)";
            var result = await db.ExecuteAsync(sql, new { name = album.AlbumName, idband = album.idBands});
            return result > 0;
        }

        public async Task<bool> UpdateAlbum(Album album)
        {
            var db = DbConnection();
            var sql = @"Update album SET AlbumName = @Name where idAlbum = @id";
            var result = await db.ExecuteAsync(sql, new { id = album.idAlbum, Name = album.AlbumName });
            return result > 0;
        }

        public async Task<Album> GetAlbum(int idAlbum, int idBands)
        {
            var db = DbConnection();
            var sql = @"select * from album where idAlbum = @idalbum and idBands = @idbands";
            return await db.QueryFirstOrDefaultAsync<Album>(sql, new {idalbum = idAlbum, idbands = idBands});
        }
    }
}
