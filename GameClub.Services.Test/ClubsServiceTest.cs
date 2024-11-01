using GameClub.Infrastructure.Models;
using GameClub.Repository.Abstractions;
using GameClub.Serivces;
using GameClub.Serivces.Abstractions;
using Moq;

namespace GameClub.Services.Test
{
    public class ClubsServiceTest
    {
      
        [Fact]
        
        public async Task CreateClub_NotUniqueName_ReturnsFailed()
        {
            var mockClubReplository = new Mock<IClubsRepository>();
            mockClubReplository.Setup(m => m.GetClubs(It.IsAny<Func<Club, bool>>())).Returns(new List<Club> { new Club()});
            var clubsService = new ClubsService(null, mockClubReplository.Object, null);
            // Act
            var createResult = await clubsService.CreateClubAsync(new Club { Name = "test" });
            // Assert
            Assert.False(createResult.IsSuccess);
        }
       
    }
}