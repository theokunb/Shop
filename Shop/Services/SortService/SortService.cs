using Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.SortService
{
    public class SortService
    {
        private readonly ISortRepository _sortRepository;

        public SortService(ISortRepository sortRepository)
        {
            _sortRepository = sortRepository;
        }

        public async Task<Sort> GetStoredSortAsync(IEnumerable<Sort> sortVariants, CancellationToken cancellationToken = default)
        {
            var sortModel = await _sortRepository.GetAsync(cancellationToken);

            if (sortModel == null)
                return null;

            return sortVariants.FirstOrDefault(element => element.Title == sortModel.Name);
        }

        public async Task StoreSortAsync(Sort sort, CancellationToken cancellationToken = default)
        {
            var sortModel = await _sortRepository.GetAsync(cancellationToken);

            if (sortModel == null)
            {
                sortModel = new Entities.SortModel
                {
                    Name = sort.Title
                };
                await _sortRepository.CreateAsync(sortModel, cancellationToken);
            }
            else
            {
                sortModel.Name = sort.Title;
                await _sortRepository.UpdateAsync(sortModel, cancellationToken);
            }
        }
    }
}
