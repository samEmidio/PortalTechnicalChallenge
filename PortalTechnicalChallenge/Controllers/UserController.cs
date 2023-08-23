using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortalTechnicalChallenge.Application.Interfaces;
using PortalTechnicalChallenge.Application.ViewModels.User;
using PortalTechnicalChallenge.Domain.Core.Bus;
using PortalTechnicalChallenge.Domain.Core.Notifications;
using PortalTechnicalChallenge.Domain.Entities;
using PortalTechnicalChallenge.Filter;


/// <summary>
/// controller de usuario - CRUD
/// </summary>

namespace TechnicalChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
		private readonly IMediatorHandler _bus;
		private readonly DomainNotificationHandler _notifications;
		private readonly IConfiguration configuration;
		private readonly ILogger<UserController> logger;
		private readonly IUserAppService _userApplicationService;
		private readonly IMapper _mapper;

		public UserController(
		   IMediatorHandler bus,
		   IMediatorHandler mediator,
		   INotificationHandler<DomainNotification> notifications,
		   IConfiguration configuration,
		   ILogger<UserController> logger,
		   IUserAppService userApplicationService,
		   IMapper mapper
		   ) : base(notifications, mediator)
		{
			_notifications = (DomainNotificationHandler)notifications;
			this._bus = bus;
			this.configuration = configuration;
			this.logger = logger;
			_userApplicationService = userApplicationService;
			_mapper = mapper;
		}


		[HttpPost]
		public IActionResult Create([FromBody] CreateUserViewModel createUserViewModel)
        {
			
            var userViewModel = _userApplicationService.AddIfNotExists(createUserViewModel);

			var user = _mapper.Map<User>(userViewModel);

            if (!IsValidOperation())
                return BadRequest(new
                {
                    success = false,
                    errors = _notifications.GetAndClearNotifications().Select(n => n.Value)
                });


            return CreatedAtRoute(nameof(GetUserById), new { id = user.Id }, _mapper.Map<UserViewModel>(user));

        }


        [HttpPut]
        public IActionResult Update([FromBody] UpdateUserViewModel updateUserViewModel)
        {

            var userViewModel = _userApplicationService.UpdateUser(updateUserViewModel);

            var user = _mapper.Map<User>(userViewModel);

            if (!IsValidOperation())
                return BadRequest(new
                {
                    success = false,
                    errors = _notifications.GetAndClearNotifications().Select(n => n.Value)
                });


            return CreatedAtRoute(nameof(GetUserById), new { id = user.Id }, _mapper.Map<UserViewModel>(user));

        }


        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult GetUserById(int id)
        {

            var userViewModel = _userApplicationService.GetById(id);

            var user = _mapper.Map<User>(userViewModel);

			if(user is not null)
                return Ok(_mapper.Map<UserViewModel>(user));

			return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var userViewModel = _userApplicationService.GetById(id);

            var user = _mapper.Map<User>(userViewModel);

            if(user is null)
                return NoContent();

            _userApplicationService.Delete(user.Id);

            if (!IsValidOperation())
                return BadRequest(new
                {
                    success = false,
                    errors = _notifications.GetAndClearNotifications().Select(n => n.Value)
                });

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var response = await _userApplicationService.GetAll(validFilter.PageNumber, validFilter.PageSize);
            return Ok(response);
        }


    }
}
