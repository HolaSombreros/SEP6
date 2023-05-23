﻿namespace MovieManagement.Functions.Services;

public interface IRatingService
{
    Task<RatingDto> PutRatingAsync(RatingDto rating);
    Task<RatingDto> AddRatingAsync(RatingDto ratingDto);
    Task<IList<RatingQueryDto>> GetMovieRatingsAsync(IList<int> ratingList);
    Task DeleteRatingAsync(Guid ratingId);
    Task<RatingDto> GetRatingByIdAsync(Guid ratingId);
    Task<RatingDto> GetMovieRatingByUserAsync(int movieId, Guid userId);
    Task<IList<RatingDto>> GetMovieRatingsAsync(int movieId, Guid userId, int pageNumber, int pageSize);
}