using IO.KnowledgeSharingPlatform.Application.Handlers;
using IO.KnowledgeSharingPlatform.Application.Interfaces.Services;
using IO.KnowledgeSharingPlatform.Core.Model;
using IO.KnowledgeSharingPlatform.Core.Model.Requests;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace IO.KnowledgeSharingPlatform.Applination.UnitTests.Handlers
{
    public class GetTedTalkHandlerTests
    {
        private MockRepository mockRepository;

        private Mock<ITedTalkService> mockTedTalkService;

        public GetTedTalkHandlerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTedTalkService = this.mockRepository.Create<ITedTalkService>();
        }

        private GetTedTalkHandler CreateGetTedTalkHandler()
        {
            return new GetTedTalkHandler(
                this.mockTedTalkService.Object);
        }

        [Fact]
        public async Task Handle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var getTedTalkHandler = this.CreateGetTedTalkHandler();
            GetTedTalkRequest request = new GetTedTalkRequest { TedTalkFilter =Core.Model.Enums.TedTalkFilterType.Author, SearchQuery="aa"};
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);
            this.mockTedTalkService.Setup(a => a.Where(It.IsAny<Expression<Func<TedTalk, bool>>>())).Returns((new List<TedTalk>()).AsQueryable());

            // Act
            var result = await getTedTalkHandler.Handle(
                request,
                cancellationToken);

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}
