using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // api/calculator/add?x=10&y=5
        [HttpGet("Calculator/add")]
        public int Add(int x,int y)
        {
            return x + y;
        }
        [HttpGet("Calculator/sum")]
        public int Sum(int x, int y)
        {
            return x + y+1000;
        }
        // api/calculator/sub?x=10&y=5
        [HttpPost]
        public int Sub(int x, int y)
        {
            return x - y;
        }
        // api/calculator/mul?x=10&y=5
        [HttpPut]
        public int Mul(int x, int y)
        {
            return x * y;
        }
        // api/calculator/div?x=10&y=5
        [HttpDelete]
        public int Div(int x, int y)
        {
            return x / y;
        }

    }
}
