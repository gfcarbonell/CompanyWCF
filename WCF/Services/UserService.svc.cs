using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Data;
using WCF.Repository;

namespace WCF.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UserService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UserService.svc o UserService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UserService : IUserService
    {
        IUserRepository IUserRepository =  new UserRepository();

        public UserService()
        {

        }

        public UserService(IUserRepository IUserRepository)
        {
            this.IUserRepository = IUserRepository;
        }

        public bool Delete(int Id)
        {
            return this.IUserRepository.Delete(Id);
        }

        public ICollection<User> Get()
        {
            return this.IUserRepository.Get();
        }

        public User GetById(int Id)
        {
            return this.IUserRepository.GetById(Id);
        }

        public User Save(User entity)
        {
            return this.IUserRepository.Save(entity);
        }

        public User Update(User entity)
        {
            return this.IUserRepository.Update(entity);
        }
    }
}
