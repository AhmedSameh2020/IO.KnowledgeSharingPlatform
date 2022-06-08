using IO.KnowledgeSharingPlatform.Application.Handlers;
using IO.KnowledgeSharingPlatform.Application.Interfaces.Services;
using IO.KnowledgeSharingPlatform.Core.Model.Requests;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace IO.KnowledgeSharingPlatform.Applination.UnitTests.Handlers
{
    public class DeleteTedTalkHandlerTests
    {
        private MockRepository mockRepository;

        private Mock<ITedTalkService> mockTedTalkService;

        public DeleteTedTalkHandlerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTedTalkService = new Mock<ITedTalkService>();
        }

        private DeleteTedTalkHandler CreateDeleteTedTalkHandler()
        {
            return new DeleteTedTalkHandler(this.mockTedTalkService.Object);
        }

        [Fact]
        public async Task Handle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var deleteTedTalkHandler = this.CreateDeleteTedTalkHandler();
            DeleteTedTalkRequest request = new DeleteTedTalkRequest { Id = Guid.Empty };
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);
            this.mockTedTalkService.Setup(a => a.Delete(It.IsAny<Guid>()));

            // Act
            var result = await deleteTedTalkHandler.Handle(
                request,
                cancellationToken);

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}
