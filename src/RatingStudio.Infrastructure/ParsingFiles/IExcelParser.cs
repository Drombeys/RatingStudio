namespace RatingStudio.Infrastructure.ParsingFiles;

public interface IExcelParser<T>
{
    /// <summary>
    /// Метод асинхронного парсинга
    /// </summary>
    /// <typeparam name="T">Объект</typeparam>
    /// <returns>Коллекция объектов</returns>
    Task<IList<T>> ParseAsync(FileInfo file);
}