using DAL.Interface.Interfaces;

namespace DAL.Interface.Entities
{
    public class DalUserEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DalRoleEntity DalRole { get; set; }
    }
}
