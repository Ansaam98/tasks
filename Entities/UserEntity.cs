using System.Collections.Generic;

namespace tasks.Entities
{
    public class UserEntity
    {
        public int id { get; set; }
        public string Username { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public List<TaskEntity> Tasks { get; set; }

    }
}