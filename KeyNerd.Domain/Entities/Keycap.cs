using KeyNerd.Infrastructure.Persistence;

namespace KeyNerd.Domain.Entities
{
    public class Keycap : AuditableEntity
    {
        #region Members

        #endregion

        #region Properties

        public const int NAME_MAX_LENGTH = 1000;

        public long Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public List<KeycapDetail> Details { get; set; }
        public List<KeycapPhoto> Photos { get; set; }

        #endregion

        #region Constructors

        #endregion

        #region Methods


        #endregion

        #region Events


        #endregion
    }
}
