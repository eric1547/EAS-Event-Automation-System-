// Just declaring a basic interface that can be used as parent latter.
// Just a rundown of what a interface is. In short, think of a class that is stripped of all its
// privileges aside from being a parent and being capable of having their insides changed
public interface IEventVisitor
{
    Task VisitAsync(Email email);
}
