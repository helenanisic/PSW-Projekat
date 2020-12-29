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
        public IActionResult Create(FeedbackCommentDTO feedbackComment)
        {
            if (HttpContext.Session.GetString("UserId") is null || !(ModelState.IsValid) || _feedbackService.Create(CreateFeedbackDTO(feedbackComment.Comment)) == Guid.Empty)
                return BadRequest();
            return BadRequest();
        }

        private FeedbackDTO CreateFeedbackDTO(string comment)
        {
            FeedbackDTO feedback = new FeedbackDTO()
            {
                Comment = comment,
                PatientId = new Guid(HttpContext.Session.GetString("UserId"))
            };
            return feedback;
        }
    }
}