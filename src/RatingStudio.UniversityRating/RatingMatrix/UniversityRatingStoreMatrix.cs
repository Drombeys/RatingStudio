using RatingStudio.Domain.Dto;
using RatingStudio.Infrastructure.Matrix;

namespace RatingStudio.UniversityRating.RatingMatrix;

public class UniversityRatingStoreMatrix : IStoreMatrix<int?, IList<UniversityRatingDto>>
{
    public IEnumerable<int?[]> Store(IList<UniversityRatingDto> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var matrix = new int?[source.Count][];

        for (int i = 0; i < source.Count; i++)
        {
            matrix[i] = new int?[9];
            matrix[i][0] = source[i].ARWU;
            matrix[i][1] = source[i].QS;
            matrix[i][2] = source[i].THE;
            matrix[i][3] = source[i].ScimagoIR;
            matrix[i][4] = source[i].NTU;
            matrix[i][5] = source[i].URAP;
            matrix[i][6] = source[i].CWTS;
            matrix[i][7] = source[i].USNews;
            matrix[i][8] = source[i].MosIUR;
        }

        return matrix;
    }
}
