namespace RatingStudio.Domain.Dto;

/// <summary>
/// Представление рейтинга университетов
/// </summary>
/// <param name="Name">Название учебного заведения</param>
/// <param name="ARWU">Рейтинг "ARWU"</param>
/// <param name="QS">Рейтинг "QS"</param>
/// <param name="THE">Рейтинг "THE"</param>
/// <param name="ScimagoIR">Рейтинг "ScimagoIR"</param>
/// <param name="NTU">Рейтинг "NTU"</param>
/// <param name="URAP">Рейтинг "URAP"</param>
/// <param name="CWTS">Рейтинг "CWTS"</param>
/// <param name="USNews">Рейтинг "USNews"</param>
/// <param name="MosIUR">Рейтинг "MosIUR"</param>
/// <param name="Rank">Ранг учебного заведения</param>
public record UniversityRatingDto
(
    string? Name,
    int? ARWU, 
    int? QS, 
    int? THE, 
    int? ScimagoIR, 
    int? NTU, 
    int? URAP, 
    int? CWTS, 
    int? USNews, 
    int? MosIUR, 
    double Rank = 0
);