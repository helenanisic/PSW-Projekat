using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IUserService _userService;

        public FeedbackController([FromServices] IFeedbackService feedbackService, IUserService userService)
        {
            this._feedbackService = feedbackService;
            this._userService = userService;
        }


        [HttpPost]
        [Authorize(Roles = "Patient")]
        public IActionResult Create(FeedbackCommentDTO feedbackComment)
        {
            string token = Request.Headers["Authorization"];
            var id = _userService.GetIdFromJwtToken(token.Split(" ")[1]);

            if (!(ModelState.IsValid) || _feedbackService.Create(CreateFeedbackDTO(feedbackComment.Comment, new Guid(id))) == Guid.Empty)
                return BadRequest();
            return Ok();


        }

        private FeedbackDTO CreateFeedbackDTO(string comment, Guid id)
        {
            FeedbackDTO feedback = new FeedbackDTO()
            {
                Comment = comment,
                PatientId = id
            };
            return feedback;
        }

        [HttpGet("GetNotPublishedFeedbacks")]
        public IEnumerable<ViewFeedbackDTO> GetNotPublishedFeedbacks()
        {
            return _feedbackService.GetNotPublishedFeedbacks();

        }
        [HttpGet("GetPublishedFeedbacks")]
        public IEnumerable<ViewFeedbackDTO> GetPublishedFeedbacks()
        {
            return _feedbackService.GetPublishedFeedbacks();

        }
        [HttpPut("Update")]
        public IActionResult Update(ViewFeedbackDTO feedback)
        {
            if(_feedbackService.Update(new FeedbackDTO() { Comment = feedback.Comment, PatientId = feedback.PatientId, Published = feedback.Published}, feedback.Id))
                return Ok();
            return BadRequest();
        }
    }
}