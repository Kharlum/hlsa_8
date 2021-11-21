using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MysqlTestController : ControllerBase
    {
        private readonly ILogger<MysqlTestController> _logger;
        private readonly IConfiguration _configuration;

        public MysqlTestController(ILogger<MysqlTestController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("GetWithoutIndex")]
        public async Task<KeyValuePair<string, DateTime>?> GetWithoutIndex([FromQuery] DateTime datebirth, [FromQuery] int flushLogLevel = 0)
        {
            using var connection = Connection(flushLogLevel);
            await connection.OpenAsync();

            using var commandInsert = new MySqlCommand("INSERT INTO users (firstname, datebirth) VALUES (@firstname, @datebirth);", connection);
            commandInsert.Parameters.AddWithValue("@firstname", GetRandomName());
            commandInsert.Parameters.AddWithValue("@datebirth", datebirth);
            await commandInsert.ExecuteNonQueryAsync();

            using var commandSelect = new MySqlCommand("SELECT firstname, datebirth FROM users WHERE datebirth = @datebirth;", connection);
            commandSelect.Parameters.AddWithValue("@datebirth", datebirth.ToString("yyyy-MM-dd"));
            using var reader = await commandSelect.ExecuteReaderAsync();
            var response = new List<KeyValuePair<string, DateTime>>();
            while (await reader.ReadAsync())
            {
                response.Add(new KeyValuePair<string, DateTime>(reader.GetString(0), reader.GetDateTime(1)));
            }
            return null;
        }

        [HttpGet("GetWithIndexBTREE")]
        public async Task<KeyValuePair<string, DateTime>?> GetWithIndexBTREE([FromQuery] DateTime datebirth, [FromQuery] int flushLogLevel = 0)
        {
            using var connection = Connection(flushLogLevel);
            await connection.OpenAsync();

            using var commandInsert = new MySqlCommand("INSERT INTO users_with_btree (firstname, datebirth) VALUES (@firstname, @datebirth);", connection);
            commandInsert.Parameters.AddWithValue("@firstname", GetRandomName());
            commandInsert.Parameters.AddWithValue("@datebirth", datebirth);
            await commandInsert.ExecuteNonQueryAsync();

            using var command = new MySqlCommand("SELECT firstname, datebirth FROM users_with_btree WHERE datebirth = @datebirth;", connection);
            command.Parameters.AddWithValue("@datebirth", datebirth.ToString("yyyy-MM-dd"));
            using var reader = await command.ExecuteReaderAsync();
            var response = new List<KeyValuePair<string, DateTime>>();
            while (await reader.ReadAsync())
            {
                response.Add(new KeyValuePair<string, DateTime>(reader.GetString(0), reader.GetDateTime(1)));
            }
            return null;
        }

        private string GetRandomName()
        {
            var random = new Random();
            return $"TestUser_{random.Next()}";
        }

        private MySqlConnection Connection(int flushLogLevel)
        {
            var key = flushLogLevel == 1 ? "Log1" : flushLogLevel == 2 ? "Log2" : "Log";
            return new MySqlConnection(_configuration[$"ConnectionStrings:{key}"]);
        }
    }
}
