using System.Data;
using System.Linq;

namespace POC
{
    public class FluentBuilder : IFluentWhereQueryProvider, IAmWhereBuilder, IFluentFieldFinder<>
    {
        public static IFluentQueryProvider For(object o)
        {
            return new FluentBuilder();
        }

    }

    public interface IFluentWhereQueryProvider : IFluentQueryProvider
    {
        IFluentWhereQueryProvider And();
        IFluentWhereQueryProvider Or();
        IFluentWhereQueryProvider Equals();
        IFluentWhereQueryProvider Field();
    }

    public interface IFluentFieldFinder<T> where T : IWherePartProvider
    {
        IFluentWhereComparer<T> Field();
    }
    public interface IFluentAndWhereQueryProvider : IWherePartProvider, IFluentQueryProvider
    {
        IFluentFieldFinder<IFluentAndWhereQueryProvider> And();
    }
    public interface IFluentOrWhereQueryProvider : IWherePartProvider,IFluentQueryProvider
    {
        IFluentFieldFinder<IFluentOrWhereQueryProvider> Or();
    }

    public interface IAmWhereBuilder : IFluentAndWhereQueryProvider, IFluentOrWhereQueryProvider
    {
        
    }
    public interface IWherePartProvider
    {
        
    }

    public interface IFluentWhereComparer<out T> where T : IWherePartProvider
    {
         T Equals();
    }

    public interface IFluentQueryProvider
    {
        IFluentQueryProvider Limit();
        IFluentWhereQueryProvider Where();
        IFluentQueryProvider Order();
        IFluentQueryProvider Execute();
    }
}