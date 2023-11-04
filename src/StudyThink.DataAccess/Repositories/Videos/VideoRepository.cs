﻿using Dapper;
using StudyThink.DataAccess.Interfaces.Videos;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Videos;

namespace StudyThink.DataAccess.Repositories.Videos
{
    public class VideoRepository : BaseRepository, IVideoRepository
    {
        public async ValueTask<long> CountAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "select count(*) from videos";

                long result = await _connection.ExecuteScalarAsync<long>(query);

                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<bool> CreateAsync(Video model)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("@Name", model.Name);
                @params.Add("@VideoPath", model.VideoPath);
                @params.Add("@Length", model.Length);
                @params.Add("@CourseModulsId", model.CourseModulsId);
                @params.Add("@AdminId", model.AdminId);

                string query = "insert into videos (Name,VideoPath,Length,CourseModulsId,AdminId) values" +
                    "(@Name,@VideoPath,@Length,@CourseModulsId,@AdminId)";

                int result = await _connection.ExecuteAsync(query);

                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<bool> DeleteAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("@Id", Id);

                string query = @"delete from videos where Id = @Id";

                int result = await _connection.ExecuteAsync(query);

                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<IEnumerable<Video>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM videos order by Id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

                IEnumerable<Video>? videos = await _connection.ExecuteScalarAsync<IEnumerable<Video>>(query);

                return videos;
            }
            catch
            {
                return Enumerable.Empty<Video>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Video> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("@Id", Id);

                string query = "select * from videos where Id = @Id";

                Video? video = await _connection.ExecuteScalarAsync<Video>(query);

                return video;
            }
            catch
            {
                return new Video();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<IEnumerable<Video>> GetVideoByModulIdAsync(long modulId)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("@CourseModulsId", modulId);

                string query = "select * from videos where CourseModulsId = @CourseModulsId";

                IEnumerable<Video>? videos = await _connection.ExecuteScalarAsync<IEnumerable<Video>>(query);

                return videos;
            }
            catch
            {
                return Enumerable.Empty<Video>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<bool> UpdateAsync(Video model)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("@Name", model.Name);
                @params.Add("@VideoPath", model.VideoPath);
                @params.Add("@Length", model.Length);
                @params.Add("@CourseModulsId", model.CourseModulsId);
                @params.Add("@AdminId", model.AdminId);
                @params.Add("@UpdatedAt", model.UpdatedAt);

                string query = "update videos set Name = @Name,VideoPath = @VideoPath,Length = @Length,CourseModulsId = @CourseModulsId,AdminId = @AdminId" +
                    "UpdatedAt = @UpdatedAt";

                int result = await _connection.ExecuteAsync(query);

                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
    }
}
