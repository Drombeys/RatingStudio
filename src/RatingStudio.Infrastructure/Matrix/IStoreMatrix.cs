namespace RatingStudio.Infrastructure.Matrix;

public interface IStoreMatrix<out T, in U>
{
    IEnumerable<T[]> Store(U source);
}