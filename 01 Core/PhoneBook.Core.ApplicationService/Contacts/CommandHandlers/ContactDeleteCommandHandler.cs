using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.Core.Domain.Data;
using FrameWork.Core.Domain.Enums;
using PhoneBook.Core.Domain.Contacts.Commands;
using PhoneBook.Core.Domain.Contacts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.ApplicationService.Contacts.CommandHandlers
{
    public class ContactDeleteCommandHandler : CommandHandler<ContactDeleteCommand>
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ICommandContactRepository contactRepository;        

        public ContactDeleteCommandHandler(IUnitOfWork unitofWork, ICommandContactRepository contactRepository)
        {
            this.unitofWork = unitofWork;
            this.contactRepository = contactRepository;          
        }
        public override CommandResult Handle(ContactDeleteCommand command)
        {
            var contact = contactRepository.Load(command.Id);

            if (contact == null)
                return new CommandResult(EnuResultStatusCode.NotFound, false, "یافت نشد");



            contact.Delete();
            


            unitofWork.Commit();

            return new CommandResult(EnuResultStatusCode.Success, true);
        }
    }
}
