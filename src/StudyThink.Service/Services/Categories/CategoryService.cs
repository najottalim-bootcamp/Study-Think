using AutoMapper;
using StudyThink.DataAccess.Interfaces.Categories;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Categories;
using StudyThink.Service.DTOs.Category;
using StudyThink.Service.Interfaces.Categories;

namespace StudyThink.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        this._repository = repository;
        this._mapper = mapper;
    }

    public async ValueTask<long> CountAsync() => await _repository.CountAsync();

    public async ValueTask<bool> CreateAsync(CategoryCreationDto model)
    {

        Category category = _mapper.Map<Category>(model);

        return await _repository.CreateAsync(category);
    }

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteRangeAsync(List<long> categoryIds)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Category>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Category> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(CategoryUpdateDto model)
    {
        throw new NotImplementedException();
    }
}
