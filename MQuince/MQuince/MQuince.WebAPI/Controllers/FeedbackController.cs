using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Entities;
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
            Feedback feedback = CreateFeedbackFromDTO(feedbackComment.Comment, new Guid(id), false);
            if (!(ModelState.IsValid) || _feedbackService.Create(feedback) == Guid.Empty)
                return BadRequest();
            return Ok();


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
        [Authorize(Roles = "Admin")]
        public IActionResult Update(ViewFeedbackDTO feedback)
        {
            Feedback updatedFeedback = _feedbackService.Update(new FeedbackDTO() { Comment = feedback.Comment, PatientId = feedback.PatientId, Published = feedback.Published }, feedback.Id);
            if (updatedFeedback != null)
                return Ok(updatedFeedback);
            return BadRequest();
            
        }

        private Feedback CreateFeedbackFromDTO(String comment, Guid patientId, bool published, Guid? id = null)
           => id == null ? new Feedback(comment, patientId, published)
               : new Feedback(id.Value, comment, patientId, published);
    }
}