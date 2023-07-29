namespace CustomSerialize.Abstract
{

public interface ICustomSerialize<T>
{
    void CustomSerialize(T entity,string path="");
    T CustomDeserailize(string path="");
}
}
