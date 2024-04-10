using System;

namespace KeyNerd.Infrastructure.Persistence
{
    public abstract class AuditableEntity
    {
        #region Members

        #endregion

        #region Properties

        public string CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        #endregion

        #region Constructors

        #endregion

        #region Methods


        #endregion

        #region Events


        #endregion
    }
}
