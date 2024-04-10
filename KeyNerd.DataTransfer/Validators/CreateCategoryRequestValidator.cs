using FluentValidation;
using KeyNerd.DataTransfer.Requests;

namespace KeyNerd.DataTransfer.Validators
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        #region Members

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(0, 100);
        }

        #endregion

        #region Methods


        #endregion

        #region Events


        #endregion
    }
}
