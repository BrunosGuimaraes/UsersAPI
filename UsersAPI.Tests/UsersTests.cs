using Bogus;
using FluentAssertions;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Tests.Helpers;
using Xunit;

namespace UsersAPI.Tests
{
    public class UsersTests
    {
        [Fact]
        public async Task Users_Post_Returns_Created()
        {
            var faker = new Faker("pt_BR");
            var request = new UserAddRequestDto
            {
                Name = faker.Person.FullName,
                Email = faker.Person.Email,
                Password = "@Teste123",
                PasswordConfirm = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("api/users", content);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            var response = TestHelper.ReadResponse<UserResponseDto>(result);
            response.Id.Should().NotBeEmpty();
            response.Name.Should().Be(request.Name);
            response.Email.Should().Be(request.Email);
            response.CreatedAt.Should().NotBeNull();
        }

        [Fact(Skip = "Não implementado")]
        public void Users_Post_Returns_BadRequest()
        {

        }

        [Fact(Skip = "Não implementado")]
        public void Users_Put_Returns_Ok()
        {

        }

        [Fact(Skip = "Não implementado")]
        public void Users_Delete_Returns_Ok()
        {

        }

        [Fact(Skip = "Não implementado")]
        public void Users_Get_Returns_Ok()
        {

        }
    }
}
