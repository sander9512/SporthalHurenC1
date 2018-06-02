using Moq;
using SporthalHuren.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SporthalHuren.Tests
{
    public class UnitTestProprietorContext
    {
        public Mock<IProprietorRepository> Repo { get; set; }

        public UnitTestProprietorContext()
        {
            Repo = new Mock<IProprietorRepository>();
            Repo.Setup(s => s.Proprietors).Returns(new[]
            {
                new Proprietor
                {
                   ID = 1,
                   Name = "Proprietor A"
                },
                 new Proprietor
                {
                   ID = 2,
                   Name = "Proprietor B"
                },
                  new Proprietor
                {
                   ID = 3,
                   Name = "Proprietor C"
                },
                   new Proprietor
                {
                   ID = 4,
                   Name = "Proprietor D"
                },
                    new Proprietor
                {
                   ID = 5,
                   Name = "Proprietor E"
                },
            });
        }
    }
}
