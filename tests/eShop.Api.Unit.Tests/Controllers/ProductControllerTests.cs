using AutoMapper;
using eShop.Api.Controllers;
using eShop.Application.Features.Products;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Unit.Tests.Controllers;

[TestFixture]
public class ProductControllerTests
{
    private IMediator mediator = default!;
    private ProductController sut = default!;

    [SetUp]
    public void SetUp()
    {
        mediator = Substitute.For<IMediator>();
        sut = new ProductController(mediator, Substitute.For<IMapper>());
    }

    [Test]
    public async Task GetProducts_ReturnsExpectedType()
    {
        // Arrange
        var cancellationToken = new CancellationToken();

        // Act
        var response = await sut.GetProducts(cancellationToken);

        // Assert
        response
            .Should()
            .BeOfType<ActionResult<IEnumerable<ProductOutput>>>();
    }

    [Test]
    public async Task GetProducts_ReturnsExpectedResult()
    {
        // Arrange
        var cancellationToken = new CancellationToken();
        mediator
            .Send(Arg.Any<ProductsRequest>(), cancellationToken)
            .Returns(new List<ProductOutput> {
                new() {
                    Id = 1,
                    Description = "fake",
                    ImgUri = "uri",
                    Name = "name",
                    Price = 99
                }
            });
        var expected = new OkObjectResult(new List<ProductOutput> {
            new() {
                Id = 1,
                Description = "fake",
                ImgUri = "uri",
                Name = "name",
                Price = 99
            }
        });

        // Act
        var response = await sut.GetProducts(cancellationToken);

        // Assert
        response
            .Result
            .Should()
            .BeEquivalentTo(expected);
    }
}
