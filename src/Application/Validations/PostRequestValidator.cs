using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Validations
{
    public class PostRequestValidator : AbstractValidator<PostRequest>
    {
        public PostRequestValidator()
        {
            ValidatePostContent();
            ValidatePostTitle();
        }

        private void ValidatePostContent()
        {
            RuleFor(s => s.PostContent)
                .NotEmpty()
                .MaximumLength(300)
                .WithMessage("Post Content should not be empty or greater than 300 char");
        }
        private void ValidatePostTitle()
        {
            RuleFor(s => s.PostTitle)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Post Content should not be empty or greater than 50 char");
        }
    }
}
