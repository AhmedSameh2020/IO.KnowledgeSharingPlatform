using IO.KnowledgeSharingPlatform.Application.Handlers;
using IO.KnowledgeSharingPlatform.Application.Interfaces.Services;
using IO.KnowledgeSharingPlatform.Core.Model;
using IO.KnowledgeSharingPlatform.Core.Model.Requests;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace IO.KnowledgeSharingPlatform.Applination.UnitTests.Handlers
{
    public class PostTedTalkHandlerTests
    {
        private MockRepository mockRepository;

        private Mock<ITedTalkService> mockTedTalkService;

        public PostTedTalkHandlerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTedTalkService = this.mockRepository.Create<ITedTalkService>();
        }

        private PostTedTalkHandler CreatePostTedTalkHandler()
        {
            return new PostTedTalkHandler(
                this.mockTedTalkService.Object);
        }

        [Fact]
        public async Task Handle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var postTedTalkHandler = this.CreatePostTedTalkHandler();
            PostTedTalkRequest request = new PostTedTalkRequest { TedTalk = new TedTalk()};
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);
            this.mockTedTalkService.Setup(a => a.Add(It.IsAny<TedTalk>())).Returns(new TedTalk());

            // Act
            var result = await postTedTalkHandler.Handle(
                request,
                cancellationToken);

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}
