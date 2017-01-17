using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users;
using System.Collections.Generic;

namespace HistoricBlog.DAL.Posts.Ratings
{
    public class Rating : BaseEntity
    {
        public int RatingValue { get; set; }
        public virtual User UserId { get; set; }
        public virtual Post PostId { get; set; }

        public override List<string> Validation()
        {
            List<string> errorsList = new List<string>();
            ValidateRatingValue(errorsList);
            
            return errorsList;
        }

        private void ValidateRatingValue(List<string> errorsList)
        {
            const int maxRate = 5;
            const int minRate = 1;

            var isInRange = RatingValue >= minRate && RatingValue <= maxRate;
            if(!isInRange) errorsList.Add($"Your rate has to be in range {minRate}-{maxRate}" );
        }
    }
}