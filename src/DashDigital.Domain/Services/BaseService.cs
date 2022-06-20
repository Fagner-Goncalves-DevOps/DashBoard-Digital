using DashDigital.Domain.Intefaces;
using DashDigital.Domain.Models;
using DashDigital.Domain.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace DashDigital.Domain.Services
{
    public abstract class BaseService
    {
        // essa classse ela e a base de todos os servicos,

        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if(validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}