
using fakestoreapi.api.Controllers;
using fakestoreapi.application.Queries;
using fakestoreapi.application.ViewModels;
using fakestoreapi.domain.Entities.Domain.Entities;
using fakestoreapi.infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServices
{
    public class PostUnitTestController
    {
        private readonly People _people;
        private GetPeoplesByIdQuery repository;
        private readonly ApplicationDbContext _context;

        public PostUnitTestController(ApplicationDbContext context)
        {
            _context = context;
             
        }
        [Fact]
        public async void Task_GetPostById_Return_OkResult()
        {
            //Arrange  
            var controller = new PeopleController(repository);
            var postId = 2;

            //Act  
            var data = await controller.GetPost(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new PeopleController(repository);
            var postId = 3;

            //Act  
            var data = await controller.GetPost(postId);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new PeopleController(repository);
            int? postId = null;

            //Act  
            var data = await controller.GetPost(postId);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_MatchResult()
        {
            //Arrange  
            var controller = new PeopleController(repository);
            int? postId = 1;

            //Act  
            var data = await controller.GetPost(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<PostViewModel>().Subject;

            Assert.Equal("Test Title 1", post.Title);
            Assert.Equal("Test Description 1", post.Description);
        }

#endregion