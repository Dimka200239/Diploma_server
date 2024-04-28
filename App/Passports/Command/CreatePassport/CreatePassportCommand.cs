﻿using MediatR;

namespace App.Passports.Command.CreatePassport
{
    public class CreatePassportCommand : IRequest<CreatePassportResult>
    {
        public int AdultPatientId { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string Code { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
