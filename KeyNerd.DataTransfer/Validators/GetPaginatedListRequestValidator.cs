using FluentValidation;
using KeyNerd.DataTransfer.Requests;

namespace KeyNerd.DataTransfer.Validators
{
    public class GetPaginatedListRequestValidator : AbstractValidator<GetPaginatedListRequest>
    {
        public GetPaginatedListRequestValidator()
        {
            RuleFor(x => x.ItemsPerPage).Must(ItemsPerPage => ItemsPerPage > 0);
            RuleFor(x => x.CurrentPage).Must(ItemsPerPage => ItemsPerPage > 0);
        }

    }
}
