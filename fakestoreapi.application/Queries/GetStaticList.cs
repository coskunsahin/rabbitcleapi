using fakestoreapi.application.Common.Interfaces;
using fakestoreapi.application.ViewModels;
using fakestoreapi.domain.Entities;
using fakestoreapi.rabbit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fakestoreapi.application.Queries
{
    public class GetStaticList : IRequest<IEnumerable<Raporlar>>
    {

        public class GetStaticListHandler : IRequestHandler<GetStaticList, IEnumerable<Raporlar>>
        {
            private readonly IRabitMQProducer _rabitMQProducer;
            public GetStaticListHandler(IRabitMQProducer rabitMQProducer)
            {
               _rabitMQProducer= rabitMQProducer;
            }
            public async Task<IEnumerable<Raporlar>> Handle(GetStaticList query, CancellationToken cancellationToken)
            {

                List<Raporlar> raporlarlistesi = new List<Raporlar>();
                raporlarlistesi.Add(new Raporlar { Raportname = "Raporlar", Rapordiractory = "https://localhost:5001/api/Raporlar/2", Mesaj = "1.rapor" });
                raporlarlistesi.Add(new Raporlar { Raportname = "Raporlar", Rapordiractory = "https://localhost:5001/api/Raporlar", Mesaj = "2.rapor" });
                raporlarlistesi.Add(new Raporlar { Raportname = "Contact", Rapordiractory = "https://localhost:5001/api/Contact", Mesaj = "3.rapor" });
                raporlarlistesi.Add(new Raporlar { Raportname = "Contact", Rapordiractory = "https://localhost:5001/api/Contact/34", Mesaj = "4.rapor" });
                _rabitMQProducer.SendProductMessage(raporlarlistesi);
                return raporlarlistesi;
            }

            
        }
    }
    
    }

