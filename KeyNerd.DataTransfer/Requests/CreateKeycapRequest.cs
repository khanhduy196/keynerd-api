using Microsoft.AspNetCore.Http;

namespace KeyNerd.DataTransfer.Requests
{
    public class CreateKeycapRequest
    {
        #region Members

        #endregion

        #region Properties

        public string Name { get; set; }

        public List<CreateKeycapDetailRequest> Details { get; set; }
        public List<IFormFile> Photos { get; set; }

        #endregion

        #region Constructors

        #endregion

        #region Methods


        #endregion

        #region Events


        #endregion
    }
}
