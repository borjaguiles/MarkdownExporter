namespace MarkdownExporter.CrossCutting.Command
{
    public interface IRequestHandler<T>
    {
        void Handle(T request);
    }
}