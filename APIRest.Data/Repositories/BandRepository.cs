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

        protected MySqlConnection DbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteBand(Band band)
        {
            var db = DbConnection();
            var sql = @"Delete FROM Bands where idBands = @idBand";
            var result =await  db.ExecuteAsync(sql, new { idBand = band.idBands });
            return result > 0;
        }

        public async Task<IEnumerable<Band>> GetAllBands()
        {
            var db = DbConnection();
            var sql = @" Select * From Bands;";
            return await db.QueryAsync<Band>(sql, new { }) ;
        }

        public async Task<Band> GetDetails(int id)
        {
            var db = DbConnection();
            var sql = @" Select idBands, Name From Bands where idBands = @Id ";
            return await db.QueryFirstOrDefaultAsync<Band>(sql, new { Id = id });
        }

        public async Task<bool> InsertBand(Band band)
        {
            var db = DbConnection();
            var sql = @" Insert into Bands(Name) values(@Name)";
           var result = await db.ExecuteAsync(sql, new{ band.Name});
            return result > 0;
        }

        public async Task<bool> UpdateBand(Band band)
        {
            var db = DbConnection();
            var sql = @" Update Bands SET Name = @Name where idBands = @idBand";
            var result = await db.ExecuteAsync(sql, new { band.idBands});
            return result > 0;
        }
        //public async Task<Band> GetAlbums(int id)
        //{
        //    var db = DbConnection();
        //    var sql = @"Select * from Bands where idBands = @ID;" +
        //        "Select * from album where idBands = @ID";
        //    var multi = await db.QueryMultipleAsync(sql, new {ID = id});
        //    var bands = await multi.ReadSingleOrDefaultAsync<Band>();
        //    if (bands != null)
        //        bands.Albums = (await multi.ReadAsync<Album>()).ToList();
        //    return bands;

        //}
        public async Task<List<Band>> GetBandsAlbums()
        {
            var db = DbConnection();
            var sql = @"Select * from Bands b left join album a on b.idBands = a.idBands";
            var bandDict = new Dictionary<int, Band>();

            var bands = await db.QueryAsync<Band, Album, Band>(sql, (band, album) =>
            {
                if (!bandDict.TryGetValue(band.idBands, out var currentBand))
                {
                    currentBand = band;
                    bandDict.Add(currentBand.idBands, currentBand);
                }
                currentBand.Albums.Add(album);
                return currentBand;
            },
            splitOn: "idBands");
            return bands.Distinct().ToList();
        }
    }
}
