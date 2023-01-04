using fakestoreapi.rabbit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakestoreapi.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemReportListController : ControllerBase
    {
        private readonly IRabitMQProducer _rabitMQProducer;
        public SistemReportListController(IRabitMQProducer rabitMQProducer)
        {
            _rabitMQProducer= rabitMQProducer;
        }
        [HttpGet]
        public ActionResult Index()

        {
            
            List<Raporlar> raporlarlistesi = new List<Raporlar>();
            raporlarlistesi.Add(new Raporlar { Raportname = "PEOPLE", Rapordiractory = "https://localhost:5001/api/People/2", Mesaj = "1.rapor" });
            raporlarlistesi.Add(new Raporlar { Raportname = "PEOPLE", Rapordiractory = "https://localhost:5001/api/People", Mesaj = "2.rapor" });
            raporlarlistesi.Add(new Raporlar { Raportname = "Contact", Rapordiractory = "https://localhost:5001/api/Contact", Mesaj = "3.rapor" });
            raporlarlistesi.Add(new Raporlar { Raportname = "Contact", Rapordiractory = "https://localhost:5001/api/Contact/34", Mesaj = "4.rapor" });
            _rabitMQProducer.SendProductMessage(raporlarlistesi);
            return Ok(raporlarlistesi);
        }

    }
}

public class Raporlar
{
    public string Raportname { get; set; }
    public string Rapordiractory { get; set; }
    public string Mesaj { get; set; }

}

