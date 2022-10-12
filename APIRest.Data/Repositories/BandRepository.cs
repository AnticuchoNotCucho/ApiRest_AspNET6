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
    public class BandRepository : IBandRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public BandRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteBand(Band band)
        {
            var db = dbConnection();
            var sql = @"Delete FROM Bands where idBands = @idBand";
            var result =await  db.ExecuteAsync(sql, new { idBand = band.idBand });
            return result > 0;
        }

        public async Task<IEnumerable<Band>> GetAllBands()
        {
            var db = dbConnection();
            var sql = @" Select idBands, Name From Bands";
            return await db.QueryAsync <Band>(sql, new { }) ;
        }

        public async Task<Band> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @" Select idBands, Name From Bands where idBands = @Id ";
            return await db.QueryFirstOrDefaultAsync<Band>(sql, new { Id = id });
        }

        public async Task<bool> InsertBand(Band band)
        {
            var db = dbConnection();
            var sql = @" Insert into Bands(Name) values(@Name)";
           var result = await db.ExecuteAsync(sql, new{ band.Name});
            return result > 0;
        }

        public async Task<bool> UpdateBand(Band band)
        {
            var db = dbConnection();
            var sql = @" Update Bands SET Name = @Name where idBands = @idBand";
            var result = await db.ExecuteAsync(sql, new { band.idBand});
            return result > 0;
        }
    }
}
