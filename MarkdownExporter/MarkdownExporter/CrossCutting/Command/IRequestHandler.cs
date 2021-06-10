namespace MdExport.CrossCutting.Command
{
    public interface IRequestHandler<T>
    {
        void Handle(T request);
    }
}