using Grpc.Core;
using UserCrudExample;
using static UserCrudExample.UserService;

namespace UserCrudExample.Services
{
    public class UserService : UserServiceBase
    {
        private static List<User> users = new List<User>(); // ذخیره کاربران در حافظه

        public override Task<User> CreateUser(User request, ServerCallContext context)
        {
            request.Id = users.Count + 1;
            users.Add(request);
            return Task.FromResult(request);
        }

        public override Task<User> GetUser(User request, ServerCallContext context)
        {
            var user = users.FirstOrDefault(u => u.Id == request.Id);
            return Task.FromResult(user ?? new User());
        }

        public override Task<User> UpdateUser(User request, ServerCallContext context)
        {
            var user = users.FirstOrDefault(u => u.Id == request.Id);
            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Code = request.Code;
                user.BirthDate = request.BirthDate;
            }
            return Task.FromResult(user ?? new User());
        }

        public override Task<User> DeleteUser(User request, ServerCallContext context)
        {
            var user = users.FirstOrDefault(u => u.Id == request.Id);
            if (user != null)
            {
                users.Remove(user);
            }
            return Task.FromResult(user ?? new User());
        }
    }
}
