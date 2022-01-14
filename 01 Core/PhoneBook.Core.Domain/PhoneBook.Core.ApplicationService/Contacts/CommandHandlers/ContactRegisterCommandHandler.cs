using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.Core.Domain.Data;
using FrameWork.Core.Domain.Enums;
using PhoneBook.Core.Domain.Contacts.Commands;
using PhoneBook.Core.Domain.Contacts.Entities;
using PhoneBook.Core.Domain.Contacts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.ApplicationService.Contacts.CommandHandlers
{
    public class ContactRegisterCommandHandler : CommandHandler<ContactRegisterCommand>
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ICommandContactRepository contactRepository;
        private readonly IQueryConactRepository queryConactRepository;

        public ContactRegisterCommandHandler(IUnitOfWork unitofWork, ICommandContactRepository contactRepository, IQueryConactRepository queryConactRepository)
        {
            this.unitofWork = unitofWork;
            this.contactRepository = contactRepository;
            this.queryConactRepository = queryConactRepository;
        }

        public override CommandResult Handle(ContactRegisterCommand command)
        {
            var contact = queryConactRepository.GetByFullName(command.FirstName + " " + command.LastName);

            if (contact != null)
                return new CommandResult(EnuResultStatusCode.LogicError, false, "نام و نام خانوادگی تکراری است");

            contactRepository.Add(new Contact
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Image = command.Image
            });

            unitofWork.Commit();

            return new CommandResult(EnuResultStatusCode.Success, true);            
        }
    }
}
