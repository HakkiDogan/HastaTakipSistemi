using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PatientValidator : AbstractValidator<Patient>
    {

        public PatientValidator()
        {
             
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Hasta adını boş geçemezsiniz");
            RuleFor(x => x.Ad).MaximumLength(30).WithMessage("Maskismum 30 karakter olmalı");
            RuleFor(x => x.TC).NotEmpty().WithMessage("TC alanını boş geçemezsiniz");
            RuleFor(x => x.TC).MaximumLength(11).WithMessage("Maskismum 11 karakter olmalı");
            RuleFor(x => x.Tel).NotEmpty().WithMessage("Telefon numarası boş geçemezsiniz");
            RuleFor(x => x.Tel).MaximumLength(11).WithMessage("Maskismum 11 karakter olmalı");
            RuleFor(x => x.DogumTarihi).NotEmpty().WithMessage("Doğum tarihini boş geçemezsiniz");
            RuleFor(x => x.Adres).NotEmpty().WithMessage("Adres alanını boş geçemezsiniz");
            RuleFor(x => x.Adres).MaximumLength(100).WithMessage("Maskismum 30 karakter olmalı");
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Hasta soyadını boş geçemezsiniz");
            RuleFor(x => x.Soyad).MaximumLength(20).WithMessage("Maskismum 20 karakter olmalı");
            RuleFor(x => x.Cinsiyet).NotEmpty().WithMessage("Cinsiyet alanını boş geçemezsiniz");
            RuleFor(x => x.TC).Must(UniqueTC).WithMessage("TC zaten kayıtlı");
            

        }

        private bool UniqueTC(string TC)
        {
            Context _c = new Context();

            var checkTC = _c.Patients.Where(x => x.TC == TC).FirstOrDefault();

            if (checkTC == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





    }
}
