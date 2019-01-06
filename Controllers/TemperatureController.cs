using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Library;
using Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eksamen19122018.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private string connectionstring = "Server=tcp:thefarmand.database.windows.net,1433;Initial Catalog=Thefarmand;Persist Security Info=False;User ID=Thefarmand;Password=Killer1963;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/Temperature
        [HttpGet(Name = "GetAll")]
        public IEnumerable<Meassurement> Get()
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand query = new SqlCommand("SELECT * FROM meassurement", conn);
            conn.Open();
            SqlDataReader laeser = query.ExecuteReader();
            List<Meassurement> TempList = new List<Meassurement>();
            if (laeser.HasRows)
            {
                while (laeser.Read())
                {
                    Meassurement tl = new Meassurement
                    {      
                        Id = Convert.ToInt32(laeser[0]),
                        Pressure = Convert.ToDouble(laeser[1]),
                        Humidity = Convert.ToDouble(laeser[2]),
                        Temperature = Convert.ToDouble(laeser[3]),
                        Timestamp = Convert.ToDateTime(laeser[4])
                    };
                    TempList.Add(tl);
                }
            }
            conn.Close();
            return TempList;
        }

        // GET: api/Temperature/1
        [HttpGet("{id}", Name = "GetOne")]
        public List<Meassurement> GetOne(int id)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand query = new SqlCommand($"SELECT * FROM  meassurement WHERE id={id}", conn);
            conn.Open();
            SqlDataReader laeser = query.ExecuteReader();
            List<Meassurement> tl = new List<Meassurement>();

            if (laeser.HasRows)
            {
                while (laeser.Read())
                {
                    Meassurement cs = new Meassurement
                    {
                        Id = Convert.ToInt32(laeser[0]),
                        Pressure = Convert.ToDouble(laeser[1]),
                        Humidity = Convert.ToDouble(laeser[2]),
                        Temperature = Convert.ToDouble(laeser[3]),
                        Timestamp = Convert.ToDateTime(laeser[4])
                    };
                    tl.Add(cs);
                }
            }
            conn.Close();
            return tl;
        }

        // POST: api/Temperature/
        [HttpPost]
        public void Post([FromBody] Meassurement value)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand query = new SqlCommand($"INSERT INTO meassurement (pressure, humidity, temperature)" +
                                              $" VALUES({value.Pressure}, {value.Humidity}, {value.Temperature})", conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }

        // PUT: api/Temperature/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Meassurement value)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand query = new SqlCommand($"UPDATE meassurement SET pressure = {value.Pressure}, humidity = {value.Humidity}, temperature = {value.Temperature} WHERE id={id}", conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }



        // DELETE: api/Temperature/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand query = new SqlCommand($"DELETE FROM meassurement WHERE id = {id}", conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }
    }
}
