//using fakestoreapi.application.Common.Interfaces;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;
//using fakestoreapi.application.ViewModels;
//using fakestoreapi.application.Queries;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using fakestoreapi.domain.Entities;
//using fakestoreapi.rabbit;

//namespace fakestoreapi.application.Handlers
//{
//    public class GetUserPeopleQueryHandler : IRequestHandler<GetUserPeopleQuery, IList<PeopleVM>>
//    {
//        private readonly IApplicationDbContext _context;
//        private readonly IRabitMQProducer _rabitMQProducer;
//        public GetUserPeopleQueryHandler(IApplicationDbContext context, IRabitMQProducer rabitMQProducer)
//        {
//            _context = context;
//            _rabitMQProducer = rabitMQProducer;
//        }

//        public async Task<IList<PeopleVM>> Handle(GetUserPeopleQuery request, CancellationToken cancellationToken)
//        {
//            var people = await _context.Peoples.Include(i => i.Products)
//                .Where(i => i.CreatedBy == request.User).ToListAsync();
//            var vm = people.Select(i => new PeopleVM
//            {
//                Id= i.Id,
//                Name=i.Name,
//                Address=i.Address,
//                ZipCode=i.ZipCode,
//                Cardnumber=i.Cardnumber,
                                   
//                TotalAmount=i.TotalAmount,
                               
                
//                Products = i.Products.Select(i => new ProductVm
//                {
//                    Id = i.Id,
//                   Title=i.Title,
//                   Quanty=i.Quanty,
//                   Image=i.Image,
//                   Category=i.Category,
//                   Price=i.Price,
                
//                  Description=i.Description


                 
//                }).ToList()
//            }).ToList();
//            _rabitMQProducer.SendProductMessage(vm);
//            return vm;
//        }
//    }
//}
