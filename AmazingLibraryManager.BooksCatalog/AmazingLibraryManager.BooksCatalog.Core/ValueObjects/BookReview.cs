namespace AmazingLibraryManager.BooksCatalog.Core.ValueObjects
{
    public class BookReview
    {
        public BookReview(Guid userid, BookRating rating, string review)
        {
            if (rating.Equals(null)) 
                throw new InvalidOperationException("Rating cannot be null.");

            if (review.Equals(null)) 
                throw new InvalidOperationException("Review cannot be null.");

            if (string.IsNullOrEmpty(review)) 
                throw new InvalidOperationException("Review is invalid.");

            if (review.Length < 4) 
                throw new InvalidOperationException("Review is too short. Minimum 4 characters.");

            Id = Guid.NewGuid();
            UserId = userid;
            Rating = rating;
            Review = review;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public BookRating Rating { get; private set; }
        public string Review { get; private set; }
    }
}