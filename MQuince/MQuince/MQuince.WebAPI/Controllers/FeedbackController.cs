using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController([FromServices] IFeedbackService feedbackService)
        {
            this._feedbackService = feedbackService;
        }

        [HttpPost]
        public IActionResult Create(CreateFeedbackDTO feedbackComment)
        {
            if (HttpContext.Session.GetString("UserId") is null)
                return BadRequest();
            
            FeedbackDTO feedback = new FeedbackDTO()
            {
                Comment = feedbackComment.Comment,
                PatientId = new Guid(HttpContext.Session.GetString("UserId")),
                Published = false
            };
            
            _feedbackService.Create(feedback);
            return Ok();
        }
    }
}