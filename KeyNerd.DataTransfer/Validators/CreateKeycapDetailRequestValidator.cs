using FluentValidation;
using KeyNerd.DataTransfer.Requests;

namespace KeyNerd.DataTransfer.Validators
{
    public class CreateKeycapDetailRequestValidator : AbstractValidator<CreateKeycapDetailRequest>
    {
        public CreateKeycapDetailRequestValidator()
        {
            RuleFor(x => x.Profile).IsInEnum();
            RuleFor(x => x.Size).IsInEnum();
        }

    }
}
