using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.Core.Domain.Data;
using FrameWork.Core.Domain.Enums;
using PhoneBook.Core.Domain.Contacts.Commands;
using PhoneBook.Core.Domain.Contacts.Repositories;

namespace PhoneBook.Core.ApplicationService.Contacts.CommandHandlers
{
    public class ContactEditCommandHandler : CommandHandler<ContactUpdateCommand>
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ICommandContactRepository contactRepository;
        private readonly IQueryConactRepository queryConactRepository;

        public ContactEditCommandHandler(IUnitOfWork unitofWork, ICommandContactRepository contactRepository, IQueryConactRepository queryConactRepository)
        {
            this.unitofWork = unitofWork;
            this.contactRepository = contactRepository;
            this.queryConactRepository = queryConactRepository;
        }

        public override CommandResult Handle(ContactUpdateCommand command)
        {


            var contact = contactRepository.Load(command.Id);

            if (contact == null)
                return new CommandResult(EnuResultStatusCode.NotFound, false, "یافت نشد");


            var tempContact = queryConactRepository.GetByFullName(command.FirstName + " " + command.LastName);


            if (contact != null && tempContact!=null && contact.Id != tempContact.Id)
                return new CommandResult(EnuResultStatusCode.LogicError, false, "نام و نام خانوادگی تکراری است");

            contact.FirstName = command.FirstName;
            contact.LastName = command.LastName;


            unitofWork.Commit();

            return new CommandResult(EnuResultStatusCode.Success, true);
        }
    }
}
