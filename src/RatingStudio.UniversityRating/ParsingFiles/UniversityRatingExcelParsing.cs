using OfficeOpenXml;
using RatingStudio.Domain.Dto;
using RatingStudio.Infrastructure.ParsingFiles;

namespace RatingStudio.UniversityRating.ParsingFiles;

public class UniversityRatingExcelParsing : IExcelParser<UniversityRatingDto>
{
    private FileInfo? _file;
    
    #region Constructor

    static UniversityRatingExcelParsing()
    {
        //Устанавливаем лицензию
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }

    public UniversityRatingExcelParsing()
    {
        
    }

    #endregion
    
    public async Task<IList<UniversityRatingDto>> ParseAsync(FileInfo file)
    {
        _file = file ?? throw new ArgumentNullException(nameof(file));

        //Создаем пакет с путем до файла Excel
        using var package = new ExcelPackage(_file);

        //Загружаем данные из файла в пакет
        await package.LoadAsync(_file);

        //Загружаем данные из рабочей страницы c 1 страницы
        var worksheet = package.Workbook?.Worksheets[0];

        //С какой колонки читаем
        int col = 1;
        
        //Записываем значения из Excel в словарь
        #region Read Worksheets

        var rating = new List<UniversityRatingDto>();

        //счет строк в Excel начинается с 1, 2 строчки это шапка
        for(int row = 3; row <= 102; row++)
        {
            rating.Add(new UniversityRatingDto( 
                Name: worksheet?.Cells[row, col]?.Value.ToString() ?? "",
                ARWU: Convert.ToInt32(worksheet?.Cells[row, col + 1].Value ?? 0),
                QS: Convert.ToInt32(worksheet?.Cells[row, col + 2].Value ?? 0),
                THE: Convert.ToInt32(worksheet?.Cells[row, col + 3].Value ?? 0),
                ScimagoIR: Convert.ToInt32(worksheet?.Cells[row, col + 4].Value ?? 0),
                NTU: Convert.ToInt32(worksheet?.Cells[row, col + 5].Value ?? 0),
                URAP: Convert.ToInt32(worksheet?.Cells[row, col + 6].Value ?? 0),
                CWTS: Convert.ToInt32(worksheet?.Cells[row, col + 7].Value ?? 0),
                USNews: Convert.ToInt32(worksheet?.Cells[row, col + 8].Value ?? 0),
                MosIUR: Convert.ToInt32(worksheet?.Cells[row, col + 9].Value ?? 0)
                ));
        }
        
        #endregion
        
        return rating;
    }
}