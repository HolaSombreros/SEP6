﻿namespace MovieManagement.Database.Repositories;

public interface IRatingRepository
{
    Task<RatingEntity?> GetMovieUserRating(int movieId, Guid userId);
    Task<List<RatingEntity>> GetAllMovieRatings(IList<int> ids);
    Task<RatingEntity?> UpdateAsync(RatingEntity entity, Guid id);
    Task<RatingEntity?> DeleteAsync(Guid id);
    Task<RatingEntity?> AddAsync(RatingEntity entity);
    Task<RatingEntity?> GetAsync(Guid id);
}