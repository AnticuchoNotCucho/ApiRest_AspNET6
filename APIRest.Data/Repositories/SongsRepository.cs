using APIRest.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRest.Data.Repositories
{
    public class SongsRepository : ISongsRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public SongsRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection DbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteSong(int idAlbum, int idSongs)
        {
            var db = DbConnection();
            var sql = @"Delete from Songs where idAlbum = @idalbum and idSongs = @idsongs";
            var result = await db.ExecuteAsync(sql, new { idalbum = idAlbum, idsongs = idSongs });
            return result > 0;
        }

        public async Task<Songs> GetSong(int idSongs, int idAlbum)
        {
            var db = DbConnection();
            var sql = @"Select * from Songs where idSongs = @idsong and idAlbum = @idalbum";
            return await db.QueryFirstOrDefaultAsync<Songs>(sql, new { idsong = idSongs, idalbum = idAlbum });
        }

        public async Task<IEnumerable<Songs>> GetSongs()
        {
            var db = DbConnection();
            var sql = @"Select * from Songs;";
            return await db.QueryAsync<Songs>(sql, new { });
            
        }

        public async Task<bool> InsertSong(Songs song)
        {
            var db = DbConnection();
            var sql = @"Insert into Songs(name, idAlbum) values(@name, @idAlbum)";
            var result = await db.ExecuteAsync(sql, new {name = song.Name, idAlbum = song.idAlbum });
            return result > 0;
        }

        public async Task<bool> UpdateSong(Songs song)
        {
            var db = DbConnection();
            var sql = @"Update Songs SET Name = @name where idSongs = @idsong and idAlbum = @idalbum";
            var result = await db.ExecuteAsync(sql, new {name = song.Name, idsong = song.idSongs, idalbum =song.idAlbum});
            return result > 0;
        }
    }
}
