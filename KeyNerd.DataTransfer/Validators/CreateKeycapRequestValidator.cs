using FluentValidation;
using KeyNerd.DataTransfer.Requests;
using KeyNerd.Domain.Entities;

namespace KeyNerd.DataTransfer.Validators
{
    public class CreateKeycapRequestValidator : AbstractValidator<CreateKeycapRequest>
    {
        #region Members

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public CreateKeycapRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(0, Keycap.NAME_MAX_LENGTH);
            //RuleFor(x => x.Details).Must(details => details != null && details.Count() > 0);
            //RuleForEach(x => x.Details).SetValidator(new CreateKeycapDetailRequestValidator()); 
        }

        #endregion

        #region Methods


        #endregion

        #region Events


        #endregion
    }
}
