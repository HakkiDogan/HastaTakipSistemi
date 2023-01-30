using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PaitentUpdateValidator : AbstractValidator<Patient>
    {
        public PaitentUpdateValidator()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Hasta adını boş geçemezsiniz");
            RuleFor(x => x.Ad).MaximumLength(30).WithMessage("Maskismum 30 karakter olmalı");
            RuleFor(x => x.Tel).NotEmpty().WithMessage("Telefon numarası boş geçemezsiniz");
            RuleFor(x => x.Tel).MaximumLength(11).WithMessage("Maskismum 11 karakter olmalı");
            RuleFor(x => x.DogumTarihi).NotEmpty().WithMessage("Doğum tarihini boş geçemezsiniz");
            RuleFor(x => x.Adres).NotEmpty().WithMessage("Adres alanını boş geçemezsiniz");
            RuleFor(x => x.Adres).MaximumLength(100).WithMessage("Maskismum 30 karakter olmalı");
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Hasta soyadını boş geçemezsiniz");
            RuleFor(x => x.Soyad).MaximumLength(20).WithMessage("Maskismum 20 karakter olmalı");

        }
    }
}
