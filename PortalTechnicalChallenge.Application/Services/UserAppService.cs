using AutoMapper;
using MediatR;
using PortalTechnicalChallenge.Application.Interfaces;
using PortalTechnicalChallenge.Application.Services;
using PortalTechnicalChallenge.Application.Validation.User;
using PortalTechnicalChallenge.Application.ViewModels.User;
using PortalTechnicalChallenge.Domain.Core.Bus;
using PortalTechnicalChallenge.Domain.Core.Notifications;
using PortalTechnicalChallenge.Domain.Entities;
using PortalTechnicalChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// service de usuario  - CRUD
/// </summary>

namespace TechnicalChallenge.Application.Services
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly CreateUserValidation _userValidation;
        private readonly UpdateUserValidation _userUpdateValidation;
        private readonly IMapper _mapper;

        public UserAppService(IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            CreateUserValidation createUserValidation,
            UpdateUserValidation updateUserValidation,
            IMapper mapper) : base(uow, bus, notifications)
        {
            _userValidation = createUserValidation;
            _userUpdateValidation = updateUserValidation;
            _mapper = mapper;
        }

        public UserViewModel AddIfNotExists(CreateUserViewModel createUserViewModel)
        {
            try
            {
                var isValid = CheckModelErrors(_userValidation.Validate(createUserViewModel));

                if (isValid)
                {
                    var userExists = _uow.Users.GetByEmail(createUserViewModel.Email);
                    if(userExists != null)
                        _bus.RaiseEvent(new DomainNotification("", "Já existe um usuario com esse email"));

                    var user = _mapper.Map<User>(createUserViewModel);

                    BeginTransaction();
                    _uow.Users.Add(user);
                    Commit();

                    return _mapper.Map<UserViewModel>(user);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return null;
        }

        public UserViewModel UpdateUser(UpdateUserViewModel updateUserViewModel)
        {
            try
            {
                var isValid = CheckModelErrors(_userUpdateValidation.Validate(updateUserViewModel));

                if (isValid)
                {
                    var verifyEmail = _uow.Users.GetByEmail(updateUserViewModel.Email);
                    if (verifyEmail != null)
                        _bus.RaiseEvent(new DomainNotification("", "Já existe um usuario com esse email"));

                    var user = _uow.Users.GetById(updateUserViewModel.Id);

                    var userUpdate = _mapper.Map<UpdateUserViewModel, User>(updateUserViewModel,user);

                    BeginTransaction();
                    _uow.Users.Update(userUpdate);
                    Commit();

                    return _mapper.Map<UserViewModel>(userUpdate);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return null;
        }


        public UserViewModel GetByEmail(string email)
        {
            var user = _uow.Users.GetByEmail(email);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

        public UserViewModel GetById(int id)
        {
            var user = _uow.Users.GetById(id);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }


        public void Delete(int id)
        {
            try
            {
                var user = _uow.Users.GetById(id);
                if (user is null)
                    return;

                BeginTransaction();
                _uow.Users.Remove(user.Id);
                Commit();
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

        }


        public async Task<List<UserViewModel>> GetAll(int pageNumber, int pageSize)
        {
            var user = await _uow.Users.GetAllAsync(pageNumber, pageSize);
            var userViewModel = _mapper.Map<List<UserViewModel>>(user);
            return userViewModel;
        }


    }
}
