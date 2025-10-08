using CustomerOrderService.Entities;
using CustomerOrderService.IDB;

namespace CustomerOrderService.Business
{
    public class UserManager: IUserManager
    {
        private readonly IUserDataManager _userDataManager;
        private readonly ILoggingDataManager _loggingDataManager;
        public UserManager(IUserDataManager userDataManager, ILoggingDataManager loggingDataManager)
        {
            _userDataManager = userDataManager;
            _loggingDataManager = loggingDataManager;
        }

        public UserDto Create(CreateUserDto dto)
        {
            var exists = _userDataManager.GetAll().Any(u => u.Email == dto.Email);
            if (exists) 
                throw new InvalidOperationException($"Email {dto.Email} already exists.");
           
            var userToAdd = new User { Name = dto.Name, Email = dto.Email, Password = dto.Password };

            var user = _userDataManager.Add(userToAdd);
           
            _loggingDataManager.LogAudit("CREATE", "User", $"UserId={user.Id}; Email={user.Email}");

            return Map(user);
        }

        public UserDto? Get(Guid id)
        {
            var user = _userDataManager.Get(id);
            return user is null ? null : Map(user);
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _userDataManager.GetAll().Select(user=>Map(user));
        }

        public UserDto? Update(Guid id,  UpdateUserDto dto)
        {
            var existingUser = _userDataManager.Get(id);
            if (existingUser is null) 
                return null;

            var emailTaken = GetAll().Any(u => u.Email == dto.Email && u.Id != id);
            if (emailTaken) 
                throw new InvalidOperationException($"Email {dto.Email} is already in use.");

            existingUser.Name = dto.Name;
            existingUser.Email = dto.Email;
            existingUser.Password = dto.Password;

            var user = _userDataManager.Update(id, existingUser);

            _loggingDataManager.LogAudit("UPDATE", "User", $"UserId={user.Id}");

            return Map(user);
        }


        private UserDto Map(User user)
        {
            var userDto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
            };
            return userDto;
        }
    }
}
