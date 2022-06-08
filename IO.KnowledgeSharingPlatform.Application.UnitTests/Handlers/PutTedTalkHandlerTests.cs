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
    public class PutTedTalkHandlerTests
    {
        private MockRepository mockRepository;

        private Mock<ITedTalkService> mockTedTalkService;

        public PutTedTalkHandlerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTedTalkService = this.mockRepository.Create<ITedTalkService>();
        }

        private PutTedTalkHandler CreatePutTedTalkHandler()
        {
            return new PutTedTalkHandler(
                this.mockTedTalkService.Object);
        }

        [Fact]
        public async Task Handle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var putTedTalkHandler = this.CreatePutTedTalkHandler();
            PutTedTalkRequest request = new PutTedTalkRequest ();
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);
            this.mockTedTalkService.Setup(a => a.Where(It.IsAny<Expression<Func<TedTalk, bool>>>())).Returns((new List<TedTalk>() { new TedTalk()}).AsQueryable());
            this.mockTedTalkService.Setup(a => a.Update(It.IsAny<TedTalk>()));

            // Act
            var result = await putTedTalkHandler.Handle(
                request,
                cancellationToken);

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}
