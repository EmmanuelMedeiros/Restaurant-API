using Microsoft.AspNetCore.Mvc;
using APIFaturamento.Models.Interface;
using APIFaturamento.Models;

namespace APIFaturamento.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class BillingController :ControllerBase {

        private readonly ILogger<BillingController> _logger;
        private readonly IBillingInterface BillingImplementation;
        public BillingController(ILogger<BillingController> logger, IBillingInterface billingImplementation) {
            _logger = logger;
            BillingImplementation = billingImplementation;
        }

        [HttpGet]
        public IActionResult Get() {
            try {
               return Ok(BillingImplementation.GetAll());
            }catch (Exception ex) {
                throw;
            }
        }

        [HttpPost] 
        public IActionResult Post([FromBody] long money){

                try {

                    Billing billing = new Billing();
                    billing.Today();
                    billing.IdGenerate();
                    billing.MoneyEarned = money;
                    return Ok(BillingImplementation.Create(billing));

                }catch(Exception ex) {
                throw;                             
            } 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id) {
           if(id == null || id.Length < 36 || id.Length > 36) {
                return BadRequest();
            } else {
                return Ok(BillingImplementation.GetById(id));
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Billing billing) {
            try {
                var _billing = BillingImplementation.Update(billing);
                if(_billing != null ) {
                    return Ok(_billing);
                } else {
                    return NotFound();
                }
            }catch(Exception error) {
                throw;
            }
        }
    }
}
