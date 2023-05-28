using ApiQuoutes.DTO;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService quoteService;
        public QuotesController(IQuoteService iQuoteService)
        {
            this.quoteService = iQuoteService;
        }

        /*
        //Save Quotes no expose, Is not necesary 
        [HttpPost]
        public ActionResult<String> SaveQuotes()
        {
            quoteService.SaveQuotes();
            return Ok("Transaccion Realizada");
        }*/


        //Get All Quotes Endopint, Endpoint no required but is a plus
        [HttpGet]
        public async Task<ActionResult<BaseResponse>> GetAllQuotes()
        {
   
            var quotes = await quoteService.GetAllQuotes();
            BaseResponse response = new BaseResponse()
            {
                succesfull = true,
                Message = "Transaction OK",
                Response = new QuoteResponse()
                {
                    Quotes = quotes,
                    TotalElements = quotes.Count()
                },
                Status = Ok().StatusCode
            };

            return Ok(response);
        }


        //This Endpoint get Quotes that More Than 10 Words
        //
        [HttpGet("/MoreThanTenWords")]
        public async Task<ActionResult<BaseResponse>> GetQuotesMoreThanTenWords([FromQuery] int limit)
        {
            var quotes = await quoteService.GetQuotesMoreThanTenWords(limit);
            BaseResponse response = new BaseResponse()
            {
                succesfull = true,
                Message = "Transaction OK",
                Response = new QuoteResponse()
                {
                    Quotes = quotes,
                    TotalElements = quotes.Count()
                },
                Status = Ok().StatusCode
            };

            return Ok(response);
        }

        //This Endpoint get Quotes that Less Than 10 Words
        [HttpGet("/LessTenWords")]
        public async Task<ActionResult<BaseResponse>> GetQuotesMoreLessTenWords([FromQuery] int limit)
        {
            var quotes = await quoteService.GetQuotesLessThanTenWords(limit);
            BaseResponse response = new BaseResponse()
            {
                succesfull = true,
                Message = "Transaction OK",
                Response = new QuoteResponse()
                {
                    Quotes = quotes,
                    TotalElements = quotes.Count()
                },
                Status = Ok().StatusCode
            };

            return Ok(response);
        }
    }
}


